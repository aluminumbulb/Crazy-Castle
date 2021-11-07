using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PursuerNavigation : MonoBehaviour
{
    [SerializeField]
    private GameObject stake;
    [SerializeField]
    private globalVars gVars;
    PlayerRoomNavigation player;
    NavMeshAgent myAgent;
    private float speedChangeAmount = 0;
    private float speedFactor = 1.1f;
    public float minSpeed = 1.5f, maxSpeed =3.5f;
    private bool pop = false;
    // Start is called before the first frame update
    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerRoomNavigation>();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Add a "turn toward" function
        myAgent.destination = player.transform.position;
        
        //print(myAgent.speed);
        //lowering speed if the monster is staked
        if(gVars.isStaked){
            //speedChangeAmount = 1.5f;
            if(pop == false){
                myAgent.speed = minSpeed;  //replace 2 with speedChangeAmount if you get the speed up working
            }
            pop = true;
            print(pop);
        }
        else{
            //if(myAgent.speed<maxSpeed){
                myAgent.speed = maxSpeed;
                if(pop){
                    Instantiate(stake, transform.position, Quaternion.identity);
                    pop = false;
                }
                
                //this code doesn't work unfortunately, same issue I was having
                //float newSpeed = myAgent.speed * speedFactor ;
                //myAgent.speed = Mathf.Clamp(newSpeed , minSpeed, maxSpeed);
            //}
            //close to working, just need to figure out how to make speedChangeAmount increase over a slower period of time
            /*
            if(myAgent.speed == 1.5f){
                speedChangeAmount = 0;
            }
            if(speedChangeAmount > 0){
                myAgent.speed = myAgent.speed + speedChangeAmount;
                if(myAgent.speed >= 3.5f){
                    myAgent.speed = 3.5f;
                }
                speedChangeAmount += .1f * Time.deltaTime;
                if (speedChangeAmount < .1){
                    speedChangeAmount = 0;
                }
                */
                //myAgent.speed = 3.5f;   //if you get speed up working, delete this line
            }
            //if(pop){
                //pop = false;
                
                //instiate stake prefab at enemies position
                //waiting for the stake prefab to be finished before writing this, but it should be 1-2 lines of code tops
            //}
        }
    }
    //TODO: Something should delete this game object if the player enters another room?
    //maybe only if player is not in adjacent room.
