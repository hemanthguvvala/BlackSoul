using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EnemyBoosWhiteMan : MonoBehaviour
{
    int health = 2000;
    public float speed;
    public float distance;
    public Transform player;
    public float startShoot, TimeBetweenShots;
    public GameObject EnemyBullet;
    public Transform firepoint;
    public bool IsFlipped = false;
    public Slider healthbar;
    Animator Anime;
    Rigidbody2D rd;
    [SerializeField]
    private GameObject Win;
    public void PlayerLook()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
       if(transform.position.x>player.position.x && IsFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0, 180, 0);
            IsFlipped =false;
        }
        else if (transform.position.x < player.position.x && !IsFlipped)
            {
                transform.localScale = flipped;
                transform.Rotate(0, 180, 0);
                IsFlipped = true;
            }
        
    }
    public void TakeDamage(int Damage)
    {
        health -= Damage;
        healthbar.value = health;
        // healthbar.SetHealth(CurrentHealth);
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
        Win.SetActive(true);
    }
    // Start is called before the first frame update

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        startShoot = TimeBetweenShots;
        rd = GetComponent<Rigidbody2D>();
        Anime = GetComponent<Animator>();
        healthbar.value = health;
        // healthbar.SetMaxHealth(Maxhealth);

    } // Update is called once per frame
        void Update()
        {
        if (Vector2.Distance(transform.position, player.position )   >distance)
        {
            Vector2 target = new Vector2(player.position.x, rd.position.y);
            Vector2 Newposition = Vector2.MoveTowards(rd.position, target, speed * Time.deltaTime);
            rd.MovePosition(Newposition);
            Anime.SetBool("RunToPlayer",true);
            PlayerLook();
        }
        else
        {
            Anime.SetBool("RunToPlayer", false);
            PlayerLook();
        }
            if (TimeBetweenShots <= 0)
            {
                Instantiate(EnemyBullet, firepoint.position, firepoint.rotation);
                TimeBetweenShots = startShoot;
            }
            else
            {
                TimeBetweenShots -= Time.deltaTime;
            }
        }
    }
