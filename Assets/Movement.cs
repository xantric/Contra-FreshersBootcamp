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
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();       
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal Movement
        float getXAxis = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(getXAxis * moveSpeed, rb.velocity.y);
        if (getXAxis != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(getXAxis), 1, 1);
        }

        // Jump
        float getYAxis = Input.GetAxisRaw("Vertical");
        if(getYAxis>0 && onGround)
        {
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
