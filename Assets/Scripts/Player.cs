using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
//using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float Speed;
    public float JumpForce;
    public bool isJumping;
    private Rigidbody2D rig;
    public Animator anim;

    private bool canMove = true;
    private bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
    {
        Move();
    }

        if (canJump)
    {
        Jump();
    }
    }

   void Move()
   {
    Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); //0f, 0f = 0y, 0z
    transform.position += movement * Time.deltaTime * Speed;

    if(Input.GetAxis("Horizontal") > 0f)
    {
        anim.SetBool("walk", true);
        transform.eulerAngles = new Vector3(0f,0f,0f);
    }
    
    if(Input.GetAxis("Horizontal") < 0f)
    {
        anim.SetBool("walk", true);
        transform.eulerAngles = new Vector3(0f,180f,0f);
    }
    
    if(Input.GetAxis("Horizontal") == 0f)
    {
        anim.SetBool("walk", false);
    }
    
   }

   void Jump()
   {
    if(Input.GetButtonDown("Jump") && !isJumping)
    {
        rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
    }
   }

   void OnCollisionEnter2D(Collision2D collision)
   {
    if(collision.gameObject.layer == 8)
    {
        isJumping = false;
    }

    if(collision.gameObject.tag == "Spike")
    {
        GameController.instance.ShowGameOver();
        Destroy(gameObject);
    }

    if(collision.gameObject.tag == "Finale")
    {
        GameController.instance.showEndGame();
    }
   }

   void OnCollisionExit2D(Collision2D collision)
   {
    if(collision.gameObject.layer == 8)
    {
        isJumping = true;
    }
   }

    internal void DesabilitarMovimento()
    {
        //throw new NotImplementedException();
        canMove = false;
        canJump = false;
    }

    internal void HabilitarMovimento()
    {
        canMove = true;
        canJump = true;
    }
}
