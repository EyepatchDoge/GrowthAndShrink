using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;

    public bool isDialog;

    public Rigidbody2D rb;
 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        DialogOn();

    }

    // Update is called once per frame
    void Update()
    {
        if(isDialog == false){
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping",true);
        }

        }
    }
    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    void FixedUpdate()
    {
        //move our Character
        if(isDialog == false){
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
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
