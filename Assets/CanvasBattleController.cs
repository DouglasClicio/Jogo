using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CanvasBattleController : MonoBehaviour
{
    public HeartSystem heart;
    public static CanvasBattleController cb;
    public Slider barra;
    public Image spriteInimigo;
    public float incrementoDeBarraJogador;
    private float incrementoDeBarraInimigo = 0.10f;
    private float _barraVelocidade;

    public Text timeText;
    public float timeCount;
    public bool timeOver = false;
    public int playerVida;
    public int inimigoVida;

    private Vector3 originalPos;

    public void iniciarBatalha(int vidaInimigo, float barraVelocidade, Sprite inimigo, int vidaPlayer)
    {
        spriteInimigo.sprite = inimigo;
        _barraVelocidade = barraVelocidade;
        inimigoVida = vidaInimigo;
        playerVida = vidaPlayer;
    }

    public void refreshScreen()
    {
        timeText.text = timeCount.ToString("f0");
    }

    void TimeCount()
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
    }
    // Start is called before the first frame update
    void Start()
    {
        originalPos = barra.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        barra.value = barra.value - (incrementoDeBarraInimigo * _barraVelocidade * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            barra.value = barra.value + incrementoDeBarraJogador;
        }

        if(barra.value <= 0)
        {
            // diminuir vida do player
            playerVida --;
            // reinicar barra para o meio
            barra.transform.position = originalPos;
            // reiniciar contagem de tempo
            
        }

        if(barra.value >= 1)
        {
            // diminuir vida do inimigo
            inimigoVida --;
            // reiniciar barra para o meio
            transform.position = originalPos;
            // reiniciar contagem de tempo
        }

        if(playerVida <= 0)
        {
            // Gameover
        }

        if(inimigoVida <= 0)
        {
            // Fechar controlador de batalha
            // Destruit o inimigo no jogo
        }

        TimeCount();
    }

    
}
