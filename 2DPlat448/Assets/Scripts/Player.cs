using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    public Transform playerBottom; //passed in a child object's transform on the bottom of the player for checking when the bottom collides
    bool canMove = true;
    public event System.Action GameOver;
    Rigidbody2D rb; //rigidbody object we will set to the Player rigidbody
     bool onGround; //used to check whether the player is on the ground or not
    bool onCheckpoint; //used to check whether or not the player is on a checkpoint
     public LayerMask ground; //mask for ground objects only (things that can be jumped off of)
    public LayerMask checkpoint; //mask for checkpoint platforms
    public LayerMask finishLine; //mask for the finish line, which ends the game
     float screenHalfWidth; //half the screen width
     public float speed; //speed we move around at
     public int jumpHeight; //how high we can jump
     public float click_time; //time when a key is clicked
    bool gameOver = false; //checks if player touched the finish line
    float screenHeight; //screen height
    bool is_right = false; //tracks last recorded left or right input
    bool is_left = false; //tracks last recorded left or right input
    bool is_up = false; //if neither left or right is pressed
    bool facing_right = true;

    // Start is called before the first frame update
    void Start()
     {
         rb = GetComponent<Rigidbody2D>(); //sets rb to the Player rigidbody
        rb.freezeRotation = true; //stop cube from rotating due to physics
        float halfPlayerWidth = transform.localScale.x / 2f; //gets half the player width (so we can offset this amount when going off screen)
         screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth; //get the screen half width and add the player half size
        screenHeight = Camera.main.orthographicSize * 2;
     }

     // Update is called once per frame
     void Update()
     {
        CheckGameOver(); //checks if the game is over, and if so starts the event
        CheckLeftRight(); //checks whether we are going left or right
        CheckFlipChar(); //checks whether to flip character sprite
        CheckOnGround(); //checks whether we are on a jumpable surface
        Movement(); //moves player
        Jumping(); //jumps  
    }
    void FixedUpdate()
    {
        
    }

    //Sets jumpHeight depending on how long a key was pressed (value of jumpHeight is limited between 10 to 30)
    void set_jumpHeight(float time)
    {
        jumpHeight = (int) (time * 30f);
        if (jumpHeight < 10) {
            jumpHeight = 10;
        }
        else if (jumpHeight > 30)
        {
            jumpHeight = 30;
        }
    }
    void CheckGameOver()
    {
        gameOver = Physics2D.OverlapArea(new Vector2(playerBottom.position.x - playerBottom.localScale.x, playerBottom.position.y + playerBottom.localScale.x), new Vector2(playerBottom.position.x + playerBottom.localScale.x, playerBottom.position.y - playerBottom.localScale.x), finishLine);
        if (gameOver == true && GameOver != null)
        {
            GameOver();
        }
    }
    void CheckLeftRight() //is up is true if neither left nor right buttons are held
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            is_left = true;
            is_up = false;
        }
        else
        {
            is_left = false;
            is_up = true;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            is_right = true;
            is_up = false;
        }
        else
        {
            is_right = false;
            is_up = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.tag == "Enemy")
        {
            FindObjectOfType<Game>().coroutineStarter();
        }
    }

    public void setMove(bool setCanMove)
    {
        canMove = setCanMove;
    }
    void Movement() //movement including looping when going off screen
    {
        float input = Input.GetAxisRaw("Horizontal"); //get direction input
        float velocity = 0;
        if (onGround && canMove == true)
        {
            velocity = input * speed; //so we know what direction to apply our speed in
            transform.Translate(Vector2.right * velocity * Time.deltaTime); //translate to the right (left if velocity is negative) at our velocity
        }

        if (transform.position.x > screenHalfWidth) //if we go beyond the right side of the screen, loop back to the left side
        {
            transform.position = new Vector2(-screenHalfWidth, transform.position.y);
        }
        if (transform.position.x < -screenHalfWidth) //if we go beyond the left side of the screen, loop back to the right side
        {
            transform.position = new Vector2(screenHalfWidth, transform.position.y);
        }
    }
    void Jumping() //jump (this should go in FixedUpdate but its kinda buggy in there for some reason)
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && onGround == true) //when space is first pressed down, start the timer
        {
            canMove = false;
            click_time = Time.time;
        }
        if (Input.GetKeyUp(KeyCode.Space) && onGround == true) // player has lifted key up, uppward force with set jumpHeight
        {
            canMove = true;
            set_jumpHeight(Time.time - click_time); //sets jump height based on how much time button is held down
            rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            if (is_right)
            {
                rb.AddForce((Vector2.right * jumpHeight) / 4, ForceMode2D.Impulse);
            }
            else if (is_left)
            {
                rb.AddForce((Vector2.left * jumpHeight) / 4, ForceMode2D.Impulse);
            }
            else if(is_up)
            {
                rb.AddForce((Vector2.up * jumpHeight) / 4, ForceMode2D.Impulse);
            }
        }
    }
    void CheckOnGround()
    {
        onGround = Physics2D.OverlapArea(new Vector2(playerBottom.position.x - playerBottom.localScale.x, playerBottom.position.y + playerBottom.localScale.x), new Vector2(playerBottom.position.x + playerBottom.localScale.x, playerBottom.position.y - playerBottom.localScale.x), ground);
        onCheckpoint = Physics2D.OverlapArea(new Vector2(playerBottom.position.x - playerBottom.localScale.x, playerBottom.position.y + playerBottom.localScale.x), new Vector2(playerBottom.position.x + playerBottom.localScale.x, playerBottom.position.y - playerBottom.localScale.x), checkpoint);//checks if our bottom object is overlapping any ground
        if (onCheckpoint)
            onGround = true;
    }

    void CheckFlipChar()
    {
        if(is_left && facing_right) {
            facing_right = !facing_right;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        else if(is_right && !facing_right) {
            facing_right = !facing_right;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

}
