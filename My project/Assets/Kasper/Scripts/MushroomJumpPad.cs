using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomJumpPad : MonoBehaviour
{
    #region variables
    public Rigidbody2D rb;
    public float bounceHeight;
    public CharacterScript cc;

    #endregion


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb.velocity = new Vector2(0, bounceHeight);
            //cc.IsNotGrounded();
        }
    }


}
