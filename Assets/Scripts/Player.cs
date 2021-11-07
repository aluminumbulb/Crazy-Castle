using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player : MonoBehaviour
{
    //For orb pickup (sorry, lazy today)
    public bool HasOrb = false;
    

    //inspector variables
    [SerializeField]
    private globalVars gVars;
    [SerializeField]
    private float speed;

    //non inspector variables
    private Rigidbody rb;
    private float moveH = 0, moveV=0;
    private float prevH, prevV, currH, currV;

    //if we don't end up using AddForce, we can delete this var
    private Vector3 moveInput;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {  
        prevH = moveH;
        prevV = moveV;
        //getting user input (wasd or arrow keys)
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");
        currH = moveH;
        currV = moveV;
        //moving it proportionally to the camera
        var camera = Camera.main;
        var forward = camera.transform.forward;
        var right = camera.transform.right;
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        if (currH > prevH && currV > prevV){
            moveV = moveV /2;
            moveH = moveH /2;
        }
        var moveDir = forward * moveV + right * moveH;
        //print(moveDir);
        //applying it to the players transform values
        transform.Translate(moveDir * speed * Time.deltaTime);

        //sprinting
        if(Input.GetKey(KeyCode.LeftShift)){
            speed = 10;
        }
        else{
            speed = 5;
        }
        /*Quick note:
            for some reason rb.AddForce isn't working on the player
            but it works on other objects so I might be miss-understanding
            something you are doing with the AI
        */
        //moveInput = new Vector3(forward * moveH, 0.0f, right * moveV);
        //rb.AddForce(moveDir*speed);

        //respawn code (for while we are testing)
        if(transform.position.y < -10){
            transform.position = new Vector3(0,1,0);
            //resets velocity so we don't go flying when we respawn
            rb.velocity = Vector2.zero;
        }
        
        //Moved staking code to PlayerActivation - Adrian
        
    }
    

}
