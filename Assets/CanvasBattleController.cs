using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasBattleController : MonoBehaviour
{
    public Slider barra;
    public Image spriteInimigo;
    public float incrementoDeBarraJogador;
    private float incrementoDeBarraInimigo = 0.10f;
    private float _barraVelocidade;
    public void iniciarBatalha(int vidaInimigo, float barraVelocidade, Sprite inimigo)
    {
        spriteInimigo.sprite = inimigo;
        _barraVelocidade = barraVelocidade;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        barra.value = barra.value - (incrementoDeBarraInimigo * _barraVelocidade * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            barra.value = barra.value + incrementoDeBarraJogador;
        }
    }
}
