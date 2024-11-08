using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;
    private Rigidbody2D rb;
    public float jumpSpeed;
    public bool onGround;
    Animator animator;
    public PauseMenu pauseMenu;//
    public AudioSource jumpSound;
        void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
        animator = GetComponent<Animator>();     
    }

    // Update is called once per frame
    void Update()
    {
        if(pauseMenu.isPaused)//
        {
            return;
        }

        // Horizontal Movement
        float getXAxis = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(getXAxis * moveSpeed, rb.velocity.y);
        if (getXAxis != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(getXAxis), 1, 1) * Mathf.Abs(transform.localScale.x);
            animator.SetBool("IsRunning", true);
        }
        else
        {
            animator.SetBool("IsRunning", false);
        }

        // Jump
        float getYAxis = Input.GetAxisRaw("Vertical");
        if(getYAxis>0 && onGround)
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed + rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }
}
