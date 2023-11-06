using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public CanvasBattleController controller;
    public Sprite sprite;
    public int vidaInimigo;
    public float barraVelocidade;

    public void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            int vidaPlayer = 0;
            if(other.TryGetComponent(out HeartSystem vida))
            {
                vidaPlayer = vida.vida;
            }
            
            if(other.TryGetComponent(out Player player))
            {
                player.DesabilitarMovimento();
            } else 
            {
                player.HabilitarMovimento();
            }

            controller.iniciarBatalha(this, player, vidaInimigo, barraVelocidade, sprite, vidaPlayer);
        }
    }
}
