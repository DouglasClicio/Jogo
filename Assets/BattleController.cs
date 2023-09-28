using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public CanvasBattleController controller;
    public Sprite sprite;
    public int vida;
    public float barraVelocidade;
    public void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            controller.gameObject.SetActive(true);
            controller.iniciarBatalha(vida, barraVelocidade, sprite);
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
