using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
     Rigidbody2D rb; //rigidbody object we will set to the Player rigidbody
     bool onGround; //used to check whether the player is on the ground or not
     public Transform playerBottom; //passed in a child object on the bottom of the player for checking when the bottom collides
     public float checkRadius; //radius of the playerBottom object
     public LayerMask ground; //mask for ground objects only (things that can be jumped off of)
     float screenHalfWidth; //half the screen width
     public float speed; //speed we move around at
    public int jumpHeight; //how high we can jump

     // Start is called before the first frame update
     void Start()
     {
         rb = GetComponent<Rigidbody2D>(); //sets rb to the Player rigidbody
         float halfPlayerWidth = transform.localScale.x / 2f; //gets half the player width (so we can offset this amount when going off screen)
         screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth; //get the screen half width and add the player half size
     }

     // Update is called once per frame
     void Update()
     {
         float input = Input.GetAxisRaw("Horizontal"); //get direction input
         float velocity = input * speed; //so we know what direction to apply our speed in
         transform.Translate(Vector2.right * velocity * Time.deltaTime); //translate to the right (left if velocity is negative) at our velocity
         if (transform.position.x > screenHalfWidth) //if we go beyond the right side of the screen, loop back to the left side
         {
             transform.position = new Vector2(-screenHalfWidth, transform.position.y);
         }
         if (transform.position.x < -screenHalfWidth) //if we go beyond the left side of the screen, loop back to the right side
         {
             transform.position = new Vector2(screenHalfWidth, transform.position.y);
         }
         //jump (this should go in FixedUpdate but its kinda buggy in there for some reason)
         onGround = Physics2D.OverlapCircle(playerBottom.position, checkRadius, ground); //checks if our bottom object is overlapping any ground
         if (Input.GetKeyDown(KeyCode.Space) && onGround == true) //when space is first pressed down, add an upward force of our set jumpHeight
         {
             rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
         }
    }
    void FixedUpdate()
    {
        
    }
}
