using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class CanvasBattleController : MonoBehaviour
{

    public HeartSystem heartPlayer;
    public HeartSystem heartInimigo;

    public Slider barra;
    public Image spriteInimigo;
    
    public float incrementoDeBarraJogador;
    private float incrementoDeBarraInimigo = 0.10f;
    private float _barraVelocidade;

    public Text timeText;
    //public float timeCount;
    public bool timeOver = false;
    private int playerVida;
    private int inimigoVida;

    private Vector3 originalPos;
    private bool EstaBatalhando = false;
    private BattleController ultimoIniciador;
    private Player player;

    public void iniciarBatalha(BattleController iniciador, Player playerRef, int vidaInimigo, float barraVelocidade, Sprite inimigo, int vidaPlayer)
    {
        if (!EstaBatalhando)
        {
        ultimoIniciador = iniciador;
            player = playerRef;
            player.DesabilitarMovimento();
            spriteInimigo.sprite = inimigo;
            _barraVelocidade = barraVelocidade;
            inimigoVida = vidaInimigo;
            playerVida = vidaPlayer;
            barra.value = 0.5f;
            EstaBatalhando = true;
            //timeCount = 15;
            this.gameObject.SetActive(true);
        }
    }

/**    public void refreshScreen()
    {
        timeText.text = timeCount.ToString("f0");
    }
**/
/**    void TimeCount()
    {
        timeOver = false;

        if(!timeOver && timeCount > 0)
        {
            timeCount -= Time.deltaTime;
            refreshScreen();

            if(timeCount <= 0)
            {
                timeCount = 0;
                timeOver = true;
            }
        }
    }**/
    // Start is called before the first frame update
    void Start()
    {
        barra.value = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!EstaBatalhando)
        {
            gameObject.SetActive(false);
            return;
        }

        barra.value = barra.value - (incrementoDeBarraInimigo * _barraVelocidade * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            barra.value = barra.value + incrementoDeBarraJogador;
        }

        if(barra.value <= 0f)
        {
            // diminuir vida do player
            playerVida --;
            heartPlayer.vida = playerVida;
            // reinicar barra para o meio
            barra.value = 0.5f;
            

        }

        if(barra.value >= 1f)
        {
            // diminuir vida do inimigo
            inimigoVida --;
            heartInimigo.vida = inimigoVida;
            // reiniciar barra para o meio
            barra.value = 0.5f;
        
        }

        if(playerVida <= 0)
        {
            // Gameover
            EstaBatalhando = false;
            GameController.instance.ShowGameOver();
            gameObject.SetActive(false);
        }

        if(inimigoVida <= 0)
        {
            // Fechar controlador de batalha
            EstaBatalhando = false;
            GameController.instance.showVictoryScreen();
            GameController.instance.PauseGame();
            player.HabilitarMovimento();
            // Destruit o inimigo no jogo
            ultimoIniciador.gameObject.SetActive(false);
        }



        //TimeCount();
    }

    
}
