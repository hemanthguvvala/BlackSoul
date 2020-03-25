using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class weapon : MonoBehaviour
{
    public Transform firepoint;
    // Start is called before the first frame update

    // Update is called once per frame
    public GameObject bullet;
    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire"))
        {
            shoot();
        }
        
    }
    void shoot()
    {
        Instantiate(bullet,firepoint.position,firepoint.rotation);
    }
}
