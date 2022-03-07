using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    #region references
    public int movementSpeed;
  
    public float jumpHeight = 1.0f;

    public Rigidbody2D rb;

    public bool isDialog;

    //public bool isGrounded;

    public LayerMask groundLayer;

    #endregion

    public bool IsGrounded()
    {

        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1.2f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        Debug.DrawRay(position, direction, Color.green);
       
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }
    
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
        if (Input.GetButtonDown("Jump") && !IsGrounded())
        {
            return;
        }
        else if(Input.GetButton("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(0, jumpHeight);
        }
    }

    public void DialogOn()
    {
        isDialog = true;
        rb.velocity = new Vector2(0,0);
    }

    public void DialogOff()
    {
        isDialog = false;
    }

    /*
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground") && isGrounded == false)
        {
            IsGrounded();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground") && isGrounded == true)
        {
            IsNotGrounded();
        }
    }

    public void IsGrounded()
    {
        isGrounded = true;
    }

    public void IsNotGrounded()
    {
        isGrounded = false;
    }
    */
}
