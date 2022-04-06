using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        AddVelocity();
    }

    void AddVelocity()
    {
        //rb.velocity = Vector2.one * speed;
        Vector2 direction = (transform.rotation * Vector2.right);
        rb.velocity =  direction * speed;
    }
}
