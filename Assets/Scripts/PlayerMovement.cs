using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed = 1f;
    public Rigidbody2D rb;
    public Vector2 playerInputVel;

    private Vector3 defaultScale;

    public bool inputActive = true;

    [Header("- - - Dash - - -")]

    public float dashSpeedMultiplier = 3f;
    public float dashTime = 0.4f;
    public float dashCd = 2f;
    float lastDashTime = -99f;
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
        if (Input.GetKey(KeyCode.Space) && CheckDashCD())
        {
            StartCoroutine(Dash());
        }
        if (inputActive)
        {
            playerInputVel = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            playerInputVel = Vector2.ClampMagnitude(playerInputVel, 1f);
            rb.velocity = playerInputVel * movespeed;//2. Adým
        }
        

        //CheckDirection(playerInputVel.x);
    }

    IEnumerator Dash()
    {
        inputActive = false;
        rb.velocity = rb.velocity * dashSpeedMultiplier;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        lastDashTime = Time.time;
        Debug.Log("dashing");
        yield return new WaitForSeconds(dashTime);
        gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
        inputActive = true;
    }

    bool CheckDashCD()
    {
        if (lastDashTime + dashCd <= Time.time)
        {
            return true;
        }

        return false;
    }
}
