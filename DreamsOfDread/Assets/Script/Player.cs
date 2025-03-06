using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float jumpForce;

    public bool isJump;
    public bool doubleJump;

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
        Ataque();

        
    }

    void Move()
    {
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movimento * Time.deltaTime * Speed;

        if(Input.GetAxis("Horizontal") > 0f)
        {            
            //eulerAngles serve para a rotação
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            anim.SetBool("andando", true);
        }

        if(Input.GetAxis("Horizontal") < 0f)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            anim.SetBool("andando", true);
        }

        if(Input.GetAxis("Horizontal") == 0f)
        {
            anim.SetBool("andando", false);
        }

    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(isJump == false)
            {
                rig.AddForce(new Vector3(0f, jumpForce), ForceMode2D.Impulse);
                isJump = true;
                doubleJump = true;
                anim.SetBool("pulo", true);
            }

            else
            {
                if(doubleJump)
                {
                    rig.AddForce(new Vector3(0f, jumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                    anim.SetBool("pulo", true);

                }
            }
        }

    }

    void Ataque()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetBool("ataque", true);

        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            anim.SetBool("ataque", false);
        }
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.tag){}

        /*if(collision.gameObject.tag == "Over")
        {
            Destroy(gameObject);
        }*/

        if(collision.gameObject.tag == "Chao")
        {
            isJump = false;
            anim.SetBool("pulo", false);
        }

        if(collision.gameObject.tag == "Vitoria")
        {
            Destroy(gameObject);
            GameController.instance.ShowVitoria();
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Chao")
        {
            isJump = true;
        }
    }
}
