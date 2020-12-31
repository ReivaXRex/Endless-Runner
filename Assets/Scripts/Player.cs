using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   
    Rigidbody2D rb;
    [SerializeField] Transform rayCastOrigin;
    [SerializeField] Animator anim;
    [SerializeField] GameObject Shield;
    [SerializeField] SFXManager sfxManager;

    public int collectedCoins;

    [SerializeField] float jumpForce = 5;
    float lastYPos;
    public float distanceTravelled;
    
    [SerializeField] bool isGrounded;
    [SerializeField] bool canDoubleJump = false;
    [SerializeField] bool hasShield = false;
    bool jump;
    bool isFalling;
    public bool isAlive; 

    void Start()
    {
        // Set the references to their components.
        rb = GetComponent<Rigidbody2D>();
        lastYPos = transform.position.y;
    }
   
 
    void Update()
    {
        if (isAlive == true)
        {
            distanceTravelled += Time.deltaTime;
            CheckForInput();
            CheckYPos();
        }
        // CheckForInput();
      
    }
   
    void FixedUpdate()
    {
        CheckForGrounded();
        AddJumpForce();
      
    }

    void CheckForInput()
    {
        // Jump when the 'Space' key is pressed by adding an upward force to the Rigidbody2D.
        if (isGrounded == true || canDoubleJump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (canDoubleJump == true && isGrounded == false)
                {
                    sfxManager.PlaySFX("DoubleJump");
                    canDoubleJump = false;
                }
                else
                {
                    sfxManager.PlaySFX("Jump");
                }

                jump = true;
               // sfxManager.PlaySFX("Jump");
                anim.SetTrigger("Jump");
            }
           
        }
    }

    void AddJumpForce()
    {
        if (jump == true)
        {
            jump = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void CheckForGrounded()
    {
        // Create a ray downwards from the rayCastOrigin point and store the data hit in a variable.
        RaycastHit2D hit = Physics2D.Raycast(rayCastOrigin.position, Vector2.down);

        // Check to see if the ray has hit anything if not..
        if (hit.collider != null)
        {
            // Check to make sure it's off the ground..
            if (hit.distance < 0.1f)
            {
                // if it isn't
                isGrounded = true;
                anim.SetBool("isGrounded", true);
                if (isFalling == true)
                {
                    sfxManager.PlaySFX("Land");
                }
                
            }
            else
            {
                isGrounded = false;
            }

        }
        
        else
        {
            // if it is
            isGrounded = false;
            anim.SetBool("isGrounded", false);
        }
    }

    void CheckYPos()
    {
        if (transform.position.y < lastYPos)
        {
            anim.SetBool("isFalling", true);
            isFalling = true;
        }
        else
        {
            anim.SetBool("isFalling", false);
            isFalling = false;
        }

        lastYPos = transform.position.y;

        if (transform.position.y < -6.5)
        {
            isAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            if (hasShield == true)
            {
                Shield.SetActive(false);
                hasShield = false;
                sfxManager.PlaySFX("ShieldBreak");
                Destroy(collision.gameObject);
            }
            else
            {
                
                isAlive = false;
            }

            
        }
        
      //  Debug.Log("Collision");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Collectable")
        {
            collectedCoins++;
            sfxManager.PlaySFX("Coin");
            Destroy(collision.gameObject);
        }

        if (collision.transform.tag == "Double Jump")
        {
            canDoubleJump = true;
            sfxManager.PlaySFX("PowerupDoubleJump");
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Shield"))
        {
            hasShield = true;
            Shield.SetActive(true);
            sfxManager.PlaySFX("PowerupShield");
            Destroy(collision.gameObject);
        }
    }
}
