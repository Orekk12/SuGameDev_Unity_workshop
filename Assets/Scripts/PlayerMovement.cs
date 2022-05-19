using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed = 1f;
    public Rigidbody2D rb;
    public Vector2 playerInputVel;

    private Vector3 defaultScale;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();

    }

    void ProcessInput()//1. Adým
    {
        playerInputVel = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        playerInputVel = Vector2.ClampMagnitude(playerInputVel, 1f);
        rb.velocity = playerInputVel * movespeed;//2. Adým

        //CheckDirection(playerInputVel.x);
    }
    void CheckDirection(float xValue)//3. Adým sonra aim ile deðiþtirilecek
    {
        if (xValue < -0.001f)
        {
            transform.localScale = new Vector3(-defaultScale.x, defaultScale.y, defaultScale.z);
            //transform.localScale.x *= -1; //Neden yapamadýðýmýzý anlat
        }
        else if(xValue > 0.001f)
        {
            transform.localScale = defaultScale;
        }
    }
}
