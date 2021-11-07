using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Rooms act as nodes on a larger room grid, and should
    be attatched to the spaces they represent.
*/
public class Room : MonoBehaviour
{
    
    //Will need a list of portals "normally" associated w/Rooms
    public Teleport[] adjacentHallways;

    /*
    Sends a signal to all teleporters which lead into this room
    */
    public void StakeRoom(){
        foreach(Teleport tp in adjacentHallways){
            tp.OpenToStakedRoom();
        }
    }

    public void UnstakeRoom(){
        foreach(Teleport tp in adjacentHallways){
            tp.CloseStakedRoom();
        }
    }
    
}


/*
//A constant list of rooms this room is connected to "normally"
    //public Room[] adjacentRooms;

    //Will need a list of possible exits to be teleported to
    //public List<Room> possibleExits;
    
    //private RoomsManager rm;
//rm = FindObjectOfType<RoomsManager>();
    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            PlayerRoomNavigation player = other.gameObject.GetComponent<PlayerRoomNavigation>();
            if(player == null){
                return;//never know, could happen
            }
            
            if(player.UpdateRoom(this)){
                rm.OnPlayerExit();
            }
        }
    }
*/