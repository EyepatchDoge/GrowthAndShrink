using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public int movementSpeed;
  
    public float jumpHeight = 1.0f;

    public Rigidbody2D rb;

    public bool isDialog;
    public float distance = 1.2f;

    //public bool isGrounded;

    public LayerMask groundLayer;
    public Animator animator;

    public bool IsGrounded()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        Debug.DrawRay(position, direction, Color.green);
       
        if (hit.collider != null)
        {
            Debug.Log("grounded");
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
            AnimMove();
            Move();
            Jump();

        }
        
    }


    public void Move()
    {
        float hort = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(hort * movementSpeed, rb.velocity.y);
        
    }

    public void AnimMove(){
        if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D))
        {
            animator.SetBool("run", true);
        }

        else if(Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("run", false);
        }
    }
 

    public void Jump()
    {
        
        if(Input.GetButton("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(0, jumpHeight);
            animator.SetTrigger("jumping");

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
    
}
