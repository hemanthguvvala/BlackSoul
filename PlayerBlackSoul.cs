using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class PlayerBlackSoul : MonoBehaviour
{
    int health = 1000;
        
    Rigidbody2D rd;
    Animator Anime;
    float input, input1;
    public Slider healthbar;
    [SerializeField]
    private GameObject GameOverUi;

    public float speed;
    public void TakeDamage(int Damage)
    {
        health -= Damage;
        healthbar.value = health;
       // healthbar.SetMaxHealth(CurrentHealth);
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
        GameOverUi.SetActive(true);
    }
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
        Anime = GetComponent<Animator>();
        healthbar.value = health;
    }
    private void Update()
    {
        if (input != 0)
        {
            Anime.SetBool("isRun", true);
        }
        else
        {
            Anime.SetBool("isRun", false);
        }
        if (input1 != 0)
        {
            Anime.SetBool("isjumping", true);
        }
        else
        {
            Anime.SetBool("isjumping", false);
        }
        if (input > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else if (input < 0) {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (CrossPlatformInputManager.GetButtonDown("Fire"))
        {
            Anime.SetBool("isshooting", true);
        }
        else
        {
            Anime.SetBool("isshooting", false);
        }
    
}
// Update is called once per frame
void FixedUpdate()
    {
        input = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        input1 = CrossPlatformInputManager.GetAxisRaw("Vertical");
        print(input);
        print(input1);
        rd.velocity = new Vector2(input * speed, input1*speed);
    }
}
