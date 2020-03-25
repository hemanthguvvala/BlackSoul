using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoilder : MonoBehaviour
{
    public Transform player;
    public int health = 50;
    public float speed = 10;
    Rigidbody2D rd;
    Animator Anime;
    bool Isflipped;
    public float Distance ;
    public float RebackPos ;
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }

    public void LookSoldier()
    {
        Vector3 flip = transform.localScale;
        flip.z *= -1f;
        if (transform.position.x > player.position.x && Isflipped)
        {
            transform.localScale = flip;
            transform.Rotate(0f, 180f, 0f);
            Isflipped = false;
        }
        else if (transform.position.x < player.position.x && !Isflipped)
        {
            transform.localScale = flip;
            transform.Rotate(0f, 180f, 0f);
            Isflipped = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > Distance)
        {
            Vector2 target = new Vector2(player.position.x, rd.position.y);
            Vector2 Newposition = Vector2.MoveTowards(rd.position, target, speed * Time.deltaTime);
            rd.MovePosition(Newposition);
            //Anime.SetBool("RunToPlayer", true);
            LookSoldier();
        }
        else
        {
           // Anime.SetBool("RunToPlayer", false);
            LookSoldier();
        }
    }
}
