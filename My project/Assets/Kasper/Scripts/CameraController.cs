using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region references
    public Camera cam;
    public Transform playerTransform;
    public Vector3 offset;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main; 
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = new Vector3(playerTransform.position.x + offset.x, playerTransform.position.y + offset.y, -10);
            
    }
}
