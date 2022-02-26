using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityTimer;

//Heavily derived from Brackeys Camera Tutorials and Unity Documentation on Vector3.SmoothDamp
[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    private Camera cam;

    //Setup for SmoothDamp
    List<GameObject> targetList = new List<GameObject>();
    List<GameObject> reserveList = new List<GameObject>();
    public float smoothSpeed = 0.3f;
    private Vector3 velocity = Vector3.zero;

    public float minSize = 5f;
    public float maxSize = 40f;
    public float zoomLimiter = 50f;
    public float zoomSpeed = 0.2f;

    bool cameraIsMoving = true;

    public Vector3 offset; //Camera offset from target
    void Start()
    {
        cam = GetComponent<Camera>();
        targetList.Add(GameObject.Find("Character_Obj"));
    }

    void FixedUpdate() {
        /*
        if (target != null) {
            // Define a target position offset from the the target transform
            Vector3 targetPosition = target.TransformPoint(offset);

            // Smoothly move camera towards target position
            Vector3 SmoothVector = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);
            transform.position = new Vector3 (SmoothVector.x, SmoothVector.y, transform.position.z);
        }
        */

        if (targetList.Count > 0 && cameraIsMoving) {
            SmoothToTarget();
            ZoomToTarget();
        }
        if (Input.GetKeyDown(KeyCode.K)) {
            cameraIsMoving = false;
            for (int i = 1; i < targetList.Count; i++) {
                reserveList.Add(targetList[i]);
                targetList.RemoveAt(1);
            }
            InstantSnap();
            Timer.Register (0.5f, () => {
                cameraIsMoving = true;
                targetList.AddRange(reserveList);
                reserveList.Clear();
            });
        }
    }

    #region Target Management
    public void AddTarget(GameObject target)
    {
        targetList.Add(target);
    }
    public void RemoveTarget(GameObject target)
    {
        targetList.Remove(target);
    }
    public void RemoveAllTargets()
    {
        targetList.Clear();
    }
    /*
    public void SetTarget(GameObject target)
    {
        this.target = target is null ? null : target.transform;
    }
    public void ResetTarget()
    {
        this.target = null;
    }
    */
    #endregion

    void SmoothToTarget()
    {
        Vector3 targetPosition = GetCenterPoint() + offset;
        Vector3 SmoothVector = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);
        transform.position = new Vector3(SmoothVector.x, SmoothVector.y, transform.position.z);
    }
    void ZoomToTarget()
    {
        float newZoom = Mathf.Lerp(minSize, maxSize, GetGreatestDistance() / zoomLimiter);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime / zoomSpeed);

        //cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);    //3D
    }
    void TiltToTarget()
    {
        //smooth tilt to specified rotation
    }
    void InstantSnap()
    {
        Vector3 targetPosition = GetCenterPoint() + offset;
        transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
        float newZoom = Mathf.Lerp(minSize, maxSize, GetGreatestDistance() / zoomLimiter);
        cam.orthographicSize = newZoom;
    }
    Vector3 GetCenterPoint()
    {
        var bounds = new Bounds(targetList[0].transform.position, Vector3.zero); //Bounds needs these arguments passed in order for the camera to work, gotta find out why
        foreach (GameObject obj in targetList) { bounds.Encapsulate(obj.transform.position); }
        return bounds.center;
    }
    float GetGreatestDistance()
    {
        var bounds = new Bounds(targetList[0].transform.position, Vector3.zero);
        foreach (GameObject obj in targetList) { bounds.Encapsulate(obj.transform.position); }
        return bounds.size.x;
    }
}


