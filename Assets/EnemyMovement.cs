using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed;
    public bool onGround;
    public float minDistance;

    private Rigidbody2D rb;
    private Transform playerTransform;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity != new Vector2(0,0))     animator.SetBool("IsRunning", true);
        else                                    animator.SetBool("IsRunning", false);

        if(playerTransform == null)
        {
            Debug.Log("Shutting Down enemy");
            Destroy(gameObject);
        }
        else
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            if (Mathf.Abs(playerTransform.position.x - transform.position.x) < minDistance) 
                direction = new Vector2(0, 0);
            else if(!onGround)
            {
                rb.AddForce(new Vector2(direction.x * moveSpeed,0), ForceMode2D.Impulse);
            }
            else rb.AddForce(direction * moveSpeed, ForceMode2D.Impulse);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            onGround = false;
        }
    }

}
