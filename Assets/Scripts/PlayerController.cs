using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;                //Floating point variable to store the player's movement speed.
    public Text countText;            //Store a reference to the UI Text component which will display the number of pickups collected.
    public Text winText;            //Store a reference to the UI Text component which will display the 'You win' message.
    public Text livesText;

    private Rigidbody2D rb2d;        //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private int count;                //Integer to store the number of pickups collected so far.
    private int lives;

    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        lives = 3;
        SetCountText();
    }


    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }






    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetCountText();
        }

        {
            
            if (other.gameObject.CompareTag ("Enemy"))
                if (lives <= 0)
            Destroy(gameObject);
        }

    }


    void SetCountText()
    {

        countText.text = "Score: " + count.ToString();
        if (count == 12)
        {
            transform.position = new Vector2(50.0f, 50.0f);
        }

        {
            if (count >= 20)

            {
                winText.text = "You have won the game!" + "\n" + "Game created by Ramon Vega!";
            }


            {
                livesText.text = "Lives: " + lives.ToString();
                if (lives <= 0)

                    
                {
                    
                    winText.text  = "You have lost the game!" + "\n" + "Game created by Ramon Vega!";
                }

                

            }
        }
    }
}
