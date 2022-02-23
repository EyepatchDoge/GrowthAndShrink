using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    #region references
    public int movementSpeed;
  
    public float jumpHeight = 1.0f;

    private Rigidbody2D rb;

    public bool isDialog;

    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DialogOn();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDialog == false)
        {
            Move();
            Jump();
        }
    }

    public void Move()
    {
        float hort = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(hort * movementSpeed, rb.velocity.y);
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(0, jumpHeight);
        }
    }

    public void DialogOn()
    {
        isDialog = true;
    }

    public void DialogOff()
    {
        isDialog = false;
    }
}
