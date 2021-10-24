using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
private Rigidbody2D rd2d;

public float speed;

public Text score;

private int scoreValue = 0;

public Text wintext;

public Text lives;

private int livesValue = 3;

public Text losetext;

public AudioClip one;

public AudioClip two;

public AudioSource music;

// Start is called before the first frame update
void Start()
{
rd2d = GetComponent<Rigidbody2D>();
score.text = scoreValue.ToString();
lives.text = livesValue.ToString();
music.clip = one;
music.Play();
music.loop = true;


wintext.text = "";
losetext.text = "";
}

// Update is called once per frame
void FixedUpdate()
{
float hozMovement = Input.GetAxis("Horizontal");
float vertMovement = Input.GetAxis("Vertical");
rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
}

private void OnCollisionEnter2D(Collision2D collision)
{
if (collision.collider.tag == "Coin")
{
scoreValue += 1;
score.text = scoreValue.ToString();
Destroy(collision.collider.gameObject);

if (scoreValue == 4)
{
    transform.position = new Vector2(52.6f, 5f);
}
if (scoreValue == 8)
    {
        music.Stop();
        music.clip = two;
        music.Play();
        
    
        Destroy(rd2d);
        wintext.text = "You Win! Made By Elijah Bonnett";
        
    }


}
if (collision.collider.tag == "Enemy")
{
    livesValue -= 1;
    lives.text = livesValue.ToString();
    Destroy(collision.collider.gameObject);
if (livesValue == 0)
{
    Destroy(rd2d);
    losetext.text = "You Lose";
}
}


}



private void OnCollisionStay2D(Collision2D collision)
{
if (collision.collider.tag == "Ground")
{
if (Input.GetKey(KeyCode.W))
{
rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse); //the 3 in this line of code is the player's "jumpforce," and you change that number to get different jump behaviors. You can also create a public variable for it and then edit it in the inspector.
}
}
}

}
