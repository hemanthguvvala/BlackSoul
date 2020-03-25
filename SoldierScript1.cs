using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierScript1 : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 100;
    float input,input1;
    public Rigidbody2D rd;
    float speed =20f;

    
    public void TakeDamage(int Damage)
    {
        health -= Damage;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    void Start()
    {
        rd = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        input = Input.GetAxisRaw("Horizontal");
        input1 = Input.GetAxisRaw("Vertical");
        rd.velocity = new Vector2(input * speed,input1*speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
