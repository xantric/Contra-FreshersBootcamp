using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject Bullet;
    public float Speed;
    public Transform GunLocation;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            GameObject bulletClone = Instantiate(Bullet, GunLocation.position, Quaternion.identity);
            bulletClone.GetComponent<Rigidbody2D>().velocity = new Vector2(Speed * transform.localScale.x, 0);// Direction of firing?
        }
    }
}
