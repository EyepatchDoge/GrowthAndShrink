using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    //Values
    [SerializeField]
    public enum ObjectState {SMALL, BIG}

    //Object Components
    private BoxCollider2D boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }

    void SwapState(){

    }
}
