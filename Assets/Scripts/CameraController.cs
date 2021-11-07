using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float turnRate, minTurn, maxTurn, rayLength=3.0f;
    private float rotationX;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float yVal = Input.GetAxis("Mouse X") * turnRate;
        rotationX += Input.GetAxis("Mouse Y") * turnRate;

        rotationX = Mathf.Clamp(rotationX, minTurn, maxTurn);
        transform.eulerAngles = new Vector3(-rotationX, transform.eulerAngles.y+yVal,0);
    
        Debug.DrawLine(transform.position, transform.forward*rayLength);
    }

    public RaycastHit camHit(){
        RaycastHit retHit;
        Physics.Raycast(transform.position, transform.forward, out retHit, rayLength, LayerMask.GetMask("Clickable"));
        return retHit;
    }
}
