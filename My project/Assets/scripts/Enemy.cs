using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private bool isRight;

    private Rigidbody2D rig;
   
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        isRight = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ///translata o ponto atual ao ponto b
        transform.Translate(Vector2.right * speed * Time.fixedDeltaTime);
    }
    public void Flip()
    {
        ///isso embaixo é um operador ternario,significa que ele vai fazer uma verificação antes de definir um valor,
        ///é como se fosse um if else de uma linha só,ou seja,ele vai verificar se o angulo y atual do inimigo é 0
        ///se sim,então se torna 180,senão se torna 0
        float angle = transform.eulerAngles.y == 0 ? 180 : 0;
        transform.eulerAngles = new Vector3(0, angle, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
