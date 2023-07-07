using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samurai : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public float timeToExitAttack;

    public GameObject hitBoxDaEspada;
    public Transform hand;
    
    private bool isJump;
    private bool isAttacking;

    private Rigidbody2D rig;
    private Animator anim;

    private float movement;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Espadada();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        movement = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        if(movement > 0)
        {
            anim.SetBool("isRun", true);   
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if(movement < 0)
        {
            anim.SetBool("isRun", true);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if(movement == 0)
        {
            anim.SetBool("isRun", false);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if(isJump == false)
            {
                anim.SetBool("isJump", true);
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isJump = true;
            }
        }
    }

    void Espadada()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(isAttacking == false)
            {
                isAttacking = true;
                anim.SetBool("isAttack", true);
                GameObject Golpe = Instantiate(hitBoxDaEspada, hand.position, hand.rotation);
                Invoke(nameof(exitAttack),timeToExitAttack);


                if(movement > 0)
                {
                    Golpe.transform.eulerAngles = new Vector3(0, 0, 0);
                }

                if(movement < 0)
                {
                    Golpe.transform.eulerAngles = new Vector3(0, 180, 0);
                }
            }
        }
    }

    void exitAttack()
    {
        isAttacking = false;
        anim.SetBool("isAttack", false);
    }

     void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.layer == 6)
        {
            isJump = false;
            anim.SetBool("isJump", false);
        }
    }
}
