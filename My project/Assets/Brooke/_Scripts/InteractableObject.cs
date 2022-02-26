using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
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

    public bool isAnimating;

    //Object Components
    private BoxCollider2D boxCollider;
    private Animator animator;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    void OnMouseDown() {
        SwapState();
    }

    void SwapState(){
        if (!isAnimating){
            isAnimating = true;
            if (objectState == ObjectState.SMALL){
                objectState = ObjectState.BIG;
                animator.SetBool("sizeState", true);
                boxCollider.size = bigBoxColliderSize;
                boxCollider.offset = bigBoxColliderOffset;
            } else {
                objectState = ObjectState.SMALL;
                animator.SetBool("sizeState", false);
                boxCollider.size = smallBoxColliderSize;
                boxCollider.offset = smallBoxColliderOffset;
            }
        }
    }

    void DoneAnimating(){
        isAnimating = false;
    }
}
