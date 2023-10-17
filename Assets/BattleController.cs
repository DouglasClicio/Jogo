using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public CanvasBattleController controller;
    public HeartSystem heart;
    public Sprite sprite;
    public int vidaInimigo;
    public int vidaPlayer;
    public float barraVelocidade;

    

    public void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //int vidaPlayer;
            if(other.TryGetComponent(out HeartSystem vida))
            {
                vidaPlayer = vida.vida;
            }
            controller.gameObject.SetActive(true);
            controller.iniciarBatalha(vidaInimigo, barraVelocidade, sprite, vidaPlayer);
        }
    }

    

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
