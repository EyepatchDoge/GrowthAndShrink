using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowShrinkObject_Box : MonoBehaviour
{
    //Constants
    public enum ObjectState {SMALL, BIG}

    //Values
    [SerializeField]
    public ObjectState objectState = ObjectState.SMALL;
    [SerializeField]
    private Vector2 smallBoxColliderSize;
    [SerializeField]
    private Vector2 smallBoxColliderOffset;
    [SerializeField]
    private Vector2 bigBoxColliderSize;
    [SerializeField]
    private Vector2 bigBoxColliderOffset;

    private bool isAnimating;

    //Object Components
    private BoxCollider2D boxCollider;
    private Animator animator;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        SetupDefaultState();
    }

    void OnMouseDown() 
    {
        SwapState();
    }

    private void SetupDefaultState()
    {
        if (!isAnimating)
        {
            isAnimating = true;
            if (objectState == ObjectState.SMALL)
            {
                ShrikObject();
            }
            else 
            {
                GrowObject();
            }
        }
    }

    void SwapState()
    {
        if (!isAnimating)
        {
            isAnimating = true;
            if (objectState == ObjectState.SMALL)
            {
                GrowObject();
            } 
            else 
            {
                ShrikObject();
            }
        }
    }

    public void GrowObject()
    {
        ChangeObjectSize(true, ObjectState.BIG);
    }

    public void ShrikObject()
    {
        ChangeObjectSize(false, ObjectState.SMALL);
    }

    public void ChangeObjectSize(bool setSize, ObjectState newState)
    {
         objectState = newState;
         animator.SetBool("sizeState", setSize);
         UpdateColliders();
    }

    public void UpdateColliders()
    {
        if(objectState == ObjectState.BIG)
        {
            boxCollider.size = bigBoxColliderSize;
            boxCollider.offset = bigBoxColliderOffset;
        }
        else
        {
            boxCollider.size = smallBoxColliderSize;
            boxCollider.offset = smallBoxColliderOffset;
        }
    }

    void DoneAnimating()
    {
        isAnimating = false;
    }

   
}
