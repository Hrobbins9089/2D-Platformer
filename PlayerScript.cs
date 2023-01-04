
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;
    public float moveSpeed;
    public bool facingRight;
    [SerializeField]
    private Transform[] groundPoints; // created an array of groundpoints(game objects) to collide with ground

    [SerializeField]
    private float groundRadius;// creates size of colliders 

    [SerializeField]
    private LayerMask whatIsGround; // defines what is ground
    private bool isGrounded; // can be set to true or false based on our position
    private bool jump;// can be set to true or false when pressing space key 

    [SerializeField]
    private float jumpforce;// how high we want to launch

    public bool isAlive;

    public GameObject reset;

    private Slider healthBar;
    public float health = 3f;
    private float healthburn = 1f;
    public Vector3 Velocity;
    private double _decelerationTolerance = 12.0;




    // Start is called before the first frame update
    void Start()
    {
        facingRight = true;
        myRigidbody = GetComponent<Rigidbody2D>(); //a variable to control the Player's body
        myAnimator = GetComponent<Animator>();//a variable to control the animation of player
        isAlive = true;
        reset.gameObject.SetActive(false);
        healthBar = GameObject.Find("health slider").GetComponent<Slider>();
        healthBar.minValue = 0f;
        healthBar.maxValue = health;
        healthBar.value = healthBar.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); //variable thst stores the value of our horizontal movement
        //Debug.Log(horizontal);
        if (isAlive == true)
        {
            PlayerMovement(horizontal);//function that controls player on the X axis
            Flip(horizontal);
            isAlive = Vector3.Distance(myRigidbody.velocity, Velocity) < _decelerationTolerance;
            Velocity = myRigidbody.velocity; 
        }
        else
        {
            return;
        }
        HandleInput();
        isGrounded = IsGrounded();
    }
    // function definitions
    private void PlayerMovement(float horizontal)
    {
        if (isGrounded && jump)
        {
            isGrounded = false;
            jump = false;
            myRigidbody.AddForce(new Vector2(0, jumpforce));
        }
        myRigidbody.velocity = new Vector2(horizontal * moveSpeed, myRigidbody.velocity.y);//adds velocity to the players body
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
    }


    private void HandleInput ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            myAnimator.SetBool("jumping", true);
        }
    }


    private void Flip(float horizontal)
    {
        if (horizontal < 0 && facingRight || horizontal >= 0 && !facingRight)
        {
            facingRight = !facingRight; //resets the bool to the opposite
            Vector2 theScale = transform.localScale; //creating a vector 2 and storing it
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        else
        {

        }
    }

    public void ImDead()
    {
        isAlive = false;
        myAnimator.SetBool("dead", true);
        reset.gameObject.SetActive(true);
        health = 0;
        healthBar.value = health;
    }
       void OnCollisionEnter2D(Collision2D target)
    {
        
        if (target.gameObject.tag == "ground")
        {
            myAnimator.SetBool("jumping", false);
        }
        if (target.gameObject.tag == "deadly")
        {
            ImDead();
        }
        if (target.gameObject.tag == "small damage")
        {
            UpdateHealth();

        }

        if (target.gameObject.tag == "medium damage")
        {
            UpdateHealth2();

        }
    }

    //function to test for collisions between the array of groundPoints and the Ground LayerMask

    private bool IsGrounded()
    {
        if (myRigidbody.velocity.y <= 0)
        {
            //if the player is not moving vertically, test each of the Player's groundPoints for collision with Ground
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
                for (int i = 0; 1 < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject) //if any of the colliders in the array of groundPoints comes into contact with another gameobject, return true.
                    {
                        return true;
                    }
                }
            }
        }
        return false; //if the player is not moving along the y axis, return false.
    }

    void UpdateHealth()
    {
        if (health > 0)
        {
            health -= healthburn; //health = health - healthburn
            healthBar.value = health; 
        }
        if (health <= 0)
        {
            ImDead();
        }
    }

    void UpdateHealth2()
    {
        if (health > 0)
        {
            health -= healthburn * 2; //health = health - healthburn
            healthBar.value = health;
        }
        if (health <= 0)
        {
            ImDead();
        }
    }
}
