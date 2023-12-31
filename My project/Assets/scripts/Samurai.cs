using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samurai : MonoBehaviour
{

    public int health = 3;
    public float speed;
    public float jumpForce;
    public float timeToExitAttack;
    public int mainLife;

    public Vector3 posInicial;

    public GameObject hitBoxDaEspada;
    public Transform hand;
    public AudioSource sound;
    
    public bool isJump;
    private bool isAttacking;

    private Rigidbody2D rig;
    public Animator anim;

    private float movement;
    
    // Start is called before the first frame update
    void Start()
    {
        mainLife = 3;
        
        posInicial = new Vector3(-1, -1, 0);
        transform.position = posInicial;
        
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource>();
        
        GameController.instance.UpdateLives(health);
        GameController.instance.UpdateMainLives(mainLife);
        
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
                sound.Play();
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
                
            }
        }
    }
    
    public void SpawnEspadaHitbox()
    {
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

    public void Damage(int dmg)
    {
        health -= dmg;
        GameController.instance.UpdateLives(health);
        anim.SetTrigger("takingDamage");

        if (health <= 0)
        {
            StartCoroutine(Death());
            mainLife--;
            GameController.instance.UpdateMainLives(mainLife);
            if (mainLife <= 0)
            {
                GameController.instance.GameOver();
            }
        }
    }

    public IEnumerator Death()
    {
        transform.position = posInicial;
        yield return null;
        health = 3;
        GameController.instance.UpdateLives(health);
    }

    public void IncreaseLife(int value)
    {
        health += value;
        GameController.instance.UpdateLives(health);
    }

    void exitAttack()
    {
        isAttacking = false;
        anim.SetBool("isAttack", false);
    }
    
    
}
