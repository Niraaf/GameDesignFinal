    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class FirstEnemy : MonoBehaviour
    {
    public Animator animator;
    public GameObject player;
    Rigidbody2D rb;
    float moveHorizontal;
    float direction;
    float speed;
    
    float jumpHeight = 1.5F;
    
    float gravityScale = 5;
    float fallGravityScale = 5;

    bool facingRight = false;
    float health;
    bool playerFacingRight;
    float timer = 2;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        moveHorizontal = player.transform.position.x - transform.position.x;
        speed = 2F;
        rb = GetComponent<Rigidbody2D>();
        health = 2;
        playerFacingRight = Input.GetAxisRaw("Horizontal") > 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(!player.GetComponent<PlayerMovement>().GetGameOver()) {
            timer += Time.deltaTime;
            if(Input.GetAxisRaw("Horizontal") > 0) playerFacingRight = true;
            else if (Input.GetAxisRaw("Horizontal") < 0) playerFacingRight = false;
            moveHorizontal = player.transform.position.x - transform.position.x;
            if(moveHorizontal > 0) {
                direction = 1;
            } else {
                direction = -1;
            }

            if(rb.velocity.y > 0.1 || rb.velocity.y < -0.1) {
                animator.SetBool("jump", true);
            } else {
                animator.SetBool("jump", false);
            }

            if(rb.velocity.y > 0) {
                rb.gravityScale = gravityScale;
            } else {
                rb.gravityScale = fallGravityScale;
            }
            if(Input.GetMouseButtonDown(0) && timer > 1) {
                if(((moveHorizontal < 2 && moveHorizontal > 0) && playerFacingRight == false) || ((moveHorizontal > -2 && moveHorizontal < 0) && playerFacingRight == true)) {
                    print("punch hit!");
                    health -= 1;
                }
                timer = 0;
            }
            if(health <= 0) {
                //death animation
                //despawn enemy
                this.gameObject.SetActive(false);
            }
        }
        
    }
    
    void FixedUpdate() {
        if(!player.GetComponent<PlayerMovement>().GetGameOver()) {
            if(animator.GetBool("attack") == false) {
                if(direction > 0 && facingRight == false) Flip();
                if(direction < 0 && facingRight == true) Flip();
                if(Mathf.Abs(moveHorizontal) > 2) {
                    rb.velocity = new Vector2(direction * speed, rb.velocity.y);
                    animator.SetBool("walk", true);
                } else {
                    animator.SetBool("walk", false);
                    animator.SetBool("attack", true);
                }
            }
        }
    }
    
    void AlertObservers(string message) {
        if(message.Equals("AttackAnimationEnded")) {
            animator.SetBool("attack", false);
        }

        if(message.Equals("CheckIfHit") && (((moveHorizontal < 2 && moveHorizontal > 0) && direction > 0) || (moveHorizontal > -2 && moveHorizontal < 0) && direction < 0)) {
            //minus health
            player.GetComponent<PlayerMovement>().SubtractHealth();
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Platform") {
            rb.gravityScale = gravityScale;
            float jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * rb.gravityScale) * -2) * rb.mass;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void Flip() {
            // flips the player so that he is facing the right direction
            Vector3 currentScale = gameObject.transform.localScale;
            currentScale.x *= -1;
            gameObject.transform.localScale = currentScale;
        
            facingRight = !facingRight;
        }
    }
    
    
