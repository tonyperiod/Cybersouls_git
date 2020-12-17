using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothness;
    private Vector3 cameraPosition;




    // Start is called before the first frame update
    void Start()
    {
        offset = target.position-transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
        cameraPosition = target.position - offset;

       transform.position = Vector3.Slerp(transform.position, cameraPosition, smoothness* Time.fixedDeltaTime);
        

    }
}
