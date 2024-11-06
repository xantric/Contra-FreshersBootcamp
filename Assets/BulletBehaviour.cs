using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (!collision.gameObject.CompareTag("Ground"))
            Debug.Log(collision.gameObject.tag);
    }
}