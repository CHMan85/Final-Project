using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{

    [Header("Stats")]
    public int health;

    [Header("Movement")]

    public float speed;
    public float maxSpeed;
    public int boostAmt;
    public int jumpForce;

    [Header("Outside Objects")]

    public GameController controller;
    public Text scoreText;
    public Text healthText;

    Rigidbody2D rb2d;
    Animator anim;
    SpriteRenderer spRen;
    

    [Header("Temp Objects")]

    //public MyBox myBox;

    [Header("Text Elements")]
    public int points = 0;
    //public Text pointText;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spRen = GetComponent<SpriteRenderer>();
        health = 3;
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    private void FixedUpdate() //
    {
        float move = Input.GetAxis("Horizontal") * speed;
        float dirY = rb2d.velocity.y;
        rb2d.velocity = new Vector2(move, dirY);
        if (move > 0f)
        {
            spRen.flipX = false;
            anim.SetBool("Running", true);
            //rb2d.MovePosition(transform.position + (new Vector3(move, 0) * Time.deltaTime * speed));

        }
        else if (move < 0f)
        {
            spRen.flipX = true;
            anim.SetBool("Running", true);
            //rb2d.MovePosition(transform.position + (new Vector3(move, 0) * Time.deltaTime * speed));
        }
        else
        {
            anim.SetBool("Running", false);
        }

        if(speed > 3f)
        {
            speed -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit Something");

        if (other.tag == "Box")
        {
            Debug.Log("You hit a Box");
            health -= 1;
            healthText.text = health.ToString();
            other.GetComponent<Box>().hitCharacter();
            if(health <= 0)
            {
                Debug.Log("Sending Signal to Controller to go to GameOverScreen");
                controller.GameOver(points);
            }
        }
        if (other.tag == "Point")
        {
            Debug.Log("You hit a Point");
            points += 1;
            scoreText.text = points.ToString();
            other.GetComponent<PointPellet>().hitCharacter();
        }
        if (other.tag == "Speed")
        {
            Debug.Log("You hit a Speed Boost");
            if (speed <= maxSpeed)
            {
                speed += boostAmt;
            }
            other.GetComponent<SpeedPellet>().hitCharacter();
        }
        if (other.tag == "Health")
        {
            Debug.Log("You hit a Health");
            health += 1;
            healthText.text = health.ToString();
            other.GetComponent<HealthPellet>().EatFood();
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            //Debug.Log("Floor Found");
            isGrounded = true;

        }
    }

}
