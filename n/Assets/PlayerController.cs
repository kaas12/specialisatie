using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{
    public Transform ply;
    public float speed = 4;
    public Text countText;
    public Text WinText;
    public Rigidbody2D rb;
    public Text EnemyText;
    public Text Ammo;
    public AudioSource clip;
    public Transform Ps;
    public Transform Pr;
    public float volume;
    public enum gameState
    {
        BeginScreen,
        Level1,
        PauseScreen
    }
    private gameState game = gameState.BeginScreen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            game = gameState.Level1;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            game = gameState.PauseScreen;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            game = gameState.BeginScreen;
        }
        if (game == gameState.Level1)
        {
            countText.text = "= " + playerstats.score;
            EnemyText.text = "= " + playerstats.enemys;
            Ammo.text = "= " + playerstats.ammo + " / 6";
            Movement();
            Ps.position = new Vector2(11, 0);
            Pr.position = new Vector2(11, 0);
        }
        else if (game == gameState.PauseScreen) 
        {
            Ps.position = new Vector2(0, 0);
            countText.text = "";
            EnemyText.text = " ";
            Ammo.text = " ";
        }
        else if (game == gameState.BeginScreen)
        {
            Pr.position = new Vector2(0, 0);
            countText.text = "";
            EnemyText.text = " ";
            Ammo.text = " ";
        }


    }
    public void Movement() 
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");



        if (inputX < -0.1)
        {
            ply.transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            playerstats.angle = 180;
            rb.velocity = new Vector2(-speed, 0);
        }
        if (inputX > 0.1)
        {
            ply.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            playerstats.angle = 0;
            rb.velocity = new Vector2(speed, 0);
        }
        if (inputY < -0.1)
        {
            ply.transform.rotation = Quaternion.Euler(0f, 0f, 270f);
            playerstats.angle = 270;
            rb.velocity = new Vector2(0, -speed);

        }
        if (inputY > 0.1)
        {
            ply.transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            playerstats.angle = 90;
            rb.velocity = new Vector2(0, speed);
        }
        if (inputX < 0.1 && inputX >- 0.1 && inputY < 0.1 && inputY > -0.1)
        {
            rb.velocity = new Vector2(0, 0);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            playerstats.score++;
            Destroy(collision.gameObject);
            clip.Play();
            clip.volume = 0.2f; // optional
            clip.loop = false; // for audio looping
        }
        if (collision.gameObject.tag == "End")
        {
             game = gameState.BeginScreen;
            Debug.Log("hi");
        }
       
    }

}

 
