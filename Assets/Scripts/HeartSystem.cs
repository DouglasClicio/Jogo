using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    Player player;
    public bool isDead;
    public int vida;
    public int vidaMaxima;

    public Image[] coracao;
    public Sprite cheio;
    public Sprite vazio;
    public GameObject gameOver;
    public static HeartSystem instance;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthLogic();
        DeadState();
    }

    void HealthLogic()
    {
        
        if(vida > vidaMaxima)
        {
            vida = vidaMaxima;
        }
        
        for(int i = 0; i < coracao.Length; i++)
        {
            if(i < vida)
            {
                coracao[i].sprite = cheio;
            }
            else
            {
                coracao[i].sprite = vazio;
            }

            if(i < vidaMaxima)
            {
                coracao[i].enabled = true;
            }
            else
            {
                coracao[i].enabled = false;
            }
        }
    }
    

    void DeadState()
    {
        if(vida <= 0)
        {
            isDead = true;
            player.anim.SetBool("IsDead", isDead);
            GetComponent<Player>().enabled = false;
            Destroy(gameObject, 1.0f);
        }
    }

}
