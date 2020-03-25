using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBullet : MonoBehaviour
{
    float speed = 20;
    public Rigidbody2D rd;
    int Damage = 25;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        rd.velocity = transform.right * speed;
    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerBlackSoul enemy = hitInfo.GetComponent<PlayerBlackSoul>();
        if (enemy != null)
        {
            enemy.TakeDamage(Damage);
        }
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
