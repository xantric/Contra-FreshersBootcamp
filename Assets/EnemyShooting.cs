using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform GunLocation;
    public GameObject bullets;
    GameObject player;
    public float speed;

    float direction;

    public float shootingCooldown = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        shootingCooldown -= Time.deltaTime;

        if(shootingCooldown <= 0)
        {
            direction = player.transform.position.x - transform.position.x;
            if (direction < 0)
                direction = -1.0f;
            else
                direction = 1.0f;

            transform.localScale = new Vector3
                (
                direction * Mathf.Abs(transform.localScale.x), 
                transform.localScale.y,
                transform.localScale.z
                );
            GameObject bulletSpawned = Instantiate(bullets, GunLocation.position, Quaternion.identity);
            bulletSpawned.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * direction, 0);
            shootingCooldown = 2.0f;
        }
    }
}
