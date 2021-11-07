using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StakeableObject : MonoBehaviour
{
    //The room the object belongs to
    public Room myRoom;
    private GameObject player;
    //Whether the stake is in the object or not
    private bool staked;
    private InteractableObject interactionChecker;
    [SerializeField]
    private globalVars gVars;
    private void Start() {
        interactionChecker = GetComponentInChildren<InteractableObject>();
        player = GameObject.Find("Player");
    }

    private void Update() {
        float dist = Vector3.Distance(transform.position, player.transform.position);
        if(dist < 5 && Input.GetKeyDown(KeyCode.E) && gVars.stakeCount > 0){
            Debug.Log("PrintSuccessful");
            gVars.stakeCount--;
            StakeMe();
        }
    }

    //"Stakes" the room itself and flips the sake state. 
    public void StakeMe(){
        if(!staked){
            myRoom.StakeRoom();
        }else{
            myRoom.UnstakeRoom();
        }
        staked = !staked;
    }
}
