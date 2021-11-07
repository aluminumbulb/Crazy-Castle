using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Controlls room navigation aspects of the player character
*/
public class PlayerRoomNavigation : MonoBehaviour
{
    public Room currRoom, prevRoom = null;
    public Teleport lastUsedTP = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    /*
    Made to tidy up the work of swaping rooms if called from other functions
    only if there is a new room to change to.
    Returns true of successfully swappped rooms, else false
    */
    public bool UpdateRoom(Room newRoom){
        //Debug.Log("Update room called with: "+newRoom.gameObject.name);
        if(newRoom != currRoom){
            prevRoom = currRoom;
            currRoom = newRoom;
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
