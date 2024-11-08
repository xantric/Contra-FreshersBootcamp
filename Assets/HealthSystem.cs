using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    float health = 100f;
    public float damagePerBullet = 10f;
    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Debug.Log("GameOver");//
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            health -= damagePerBullet;
        }
    }
}
