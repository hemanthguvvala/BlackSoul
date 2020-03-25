using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierWeapon : MonoBehaviour
{
    public Transform player;
    Rigidbody2D rd;
    public GameObject hit;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerBlackSoul player = collision.GetComponent<PlayerBlackSoul>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }Destroy(gameObject);
    }
}
