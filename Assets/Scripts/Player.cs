using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float Speed;
    public float JumpForce;
    public bool isJumping;
    private Rigidbody2D rig;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
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
   }

   void OnCollisionExit2D(Collision2D collision)
   {
    if(collision.gameObject.layer == 8)
    {
        isJumping = true;
    }
   }

   
}
