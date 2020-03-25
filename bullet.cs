using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bullet : MonoBehaviour
{
     float speed=20;
   public Rigidbody2D rd;
    int Damage = 40;
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        rd.velocity = transform.right*speed;
    }
     void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyBoosWhiteMan enemy=hitInfo.GetComponent<EnemyBoosWhiteMan>();
        if (enemy!= null)
        {
            enemy.TakeDamage(Damage);
        }
        Instantiate(explosion,transform.position,transform.rotation);
        Destroy(gameObject);
    }

}
