using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class PlayerMovement : MonoBehaviour
{
    public GameObject[] lives;
    bool gameOver = false;
    public GameObject gameOverText;
    public Animator animator;
    bool facingRight = true;
    
    float jumpHeight = 1.5F;
    
    float gravityScale = 5;
    float fallGravityScale = 5;
    
    float moveHorizontal;
    float moveVertical;
    
    float speed;
    float timer = 2;
    float health;
    Rigidbody2D rb;
    public Slider slider;
    
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        speed = 4.5F;
        health = 10;
    }
    
    private void Update()
    {
        if(timer > 1F) {
            slider.value = 1;
        } else {
            slider.value = timer;
        }
        if(!gameOver) {
            timer += Time.deltaTime;
            moveHorizontal = Input.GetAxisRaw("Horizontal");
            moveVertical = Mathf.Abs(rb.velocity.y);
            
            // jump!
            if(Input.GetKeyDown(KeyCode.Space) && moveVertical < 0.01) {
                rb.gravityScale = gravityScale;
                float jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * rb.gravityScale) * -2) * rb.mass;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        
            if(rb.velocity.y > 0) {
                rb.gravityScale = gravityScale;
            } else {
                rb.gravityScale = fallGravityScale;
            }

            if(Input.GetMouseButtonDown(0) && timer > 1) {
                //animation of punch
                animator.SetBool("punch", true);
                timer = 0;
            }

            if(health == 9) lives[9].SetActive(false);
            else if(health == 8) lives[8].SetActive(false);
            else if(health == 7) lives[7].SetActive(false);
            else if(health == 6) lives[6].SetActive(false);
            else if(health == 5) lives[5].SetActive(false);
            else if(health == 4) lives[4].SetActive(false);
            else if(health == 3) lives[3].SetActive(false);
            else if(health == 2) lives[2].SetActive(false);
            else if(health == 1) lives[1].SetActive(false);
            else if(health <= 0) {
                lives[0].SetActive(false);
                gameOverText.SetActive(true);
                gameOver = true;
                //game over scene
            }
        }
        print(health);
        
    }
    
    void FixedUpdate() {
        if(!gameOver) {
            // move left and move right, also controls animations
            if(moveHorizontal > 0.1F || moveHorizontal < -0.1F) {
                if(moveHorizontal > 0.1F && facingRight == false) {
                    Flip();
                } else if(moveHorizontal < -0.1F && facingRight == true) {
                    Flip();
                }
                rb.velocity = new Vector2(moveHorizontal * speed, rb.velocity.y);
                animator.SetBool("walk", true);
            } else {
                animator.SetBool("walk", false);
            }
        }
        
    }
    
    void AlertObservers(string message) {
        if(message.Equals("PunchAnimationEnded")) {
            animator.SetBool("punch", false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Platform") {
            animator.SetBool("jump", false);
        }
    }
    void OnTriggerExit2D(Collider2D collision) {
        if(collision.gameObject.tag == "Platform" && moveVertical > .01) {
            animator.SetBool("jump", true);
        }
    }
    
    void Flip() {
        // flips the player so that he is facing the right direction
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
    
        facingRight = !facingRight;
    }

    public void SubtractHealth() {
        health -= 1;
    }

    public bool GetGameOver() {
        return gameOver;
    }
}
 
 
