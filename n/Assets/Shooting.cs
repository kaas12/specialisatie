using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float speed = 20f;
    public Transform ShootingPoint;
    public GameObject BulletPrefab;
    public AudioSource clip2;

    void Update() 
    {
        if (Input.GetKeyDown("space") && playerstats.ammo > 0)
        {
            Shoot();
            playerstats.ammo -= 1;
        }
    }

    public void Reload() 
    {
        playerstats.ammo = 6;
        clip2.Play();
        clip2.volume = 0.8f; // optional
        clip2.loop = false; // for audio looping
    }
    public void Shoot()
    {
        GameObject Bullet = Instantiate(BulletPrefab, ShootingPoint.position, ShootingPoint.rotation);
        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(ShootingPoint.right * 20f, ForceMode2D.Impulse);
    }
}

