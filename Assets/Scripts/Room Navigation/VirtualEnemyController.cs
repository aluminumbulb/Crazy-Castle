using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualEnemyController : MonoBehaviour
{
    /*
    public Room currRoom;
    RoomsManager rm;
    private PlayerRoomNavigation player;
    public GameObject nme; //this will be the actual physical enemy
    public bool instantiated = false;
   
    // Start is called before the first frame update
    void Start()
    {
        //rm = FindObjectOfType<RoomsManager>();
        //player = FindObjectOfType<PlayerRoomNavigation>();
    }

    public void TakeTurn(){
        //update currRoom to determine relation to the player
        MoveRoom();
       
        bool overlap = player.currRoom == currRoom;
        
        if(overlap && !instantiated){
            Vector3 position = currRoom.transform.position;
            StartCoroutine(timedInstantiation(position));
        }

        //delete the entity if too far away
        else if(currRoom.distFromPlayer > 1 && instantiated){
            DestroyCreature();
        }
    }

    public void MoveRoom(){
        //Room circumstances already set
        //No need for an algorithm! We already know which way is the shortest!
        Room nextRoom = currRoom;
        int shortest = currRoom.distFromPlayer;
        foreach(Room room in currRoom.adjacentRooms){
            if(room.distFromPlayer<shortest){
                shortest = room.distFromPlayer;
                nextRoom = room;
            }
        }
        currRoom = nextRoom;
    }


    private IEnumerator timedInstantiation(Vector3 spawnPoint){
        Debug.Log("timedInstantiation");
        //Instatniate pursuer and place in correct region
        yield return new WaitForSeconds(0);
        GameObject enemy = Instantiate(nme);
        enemy.transform.position = spawnPoint;// - Vector3.up;
        instantiated = true;
    }

   
    public void DestroyCreature(){
        //Remove the previous pursuer from the scene
        Debug.Log("Creature is Dead");
        PursuerNavigation pursuer = FindObjectOfType<PursuerNavigation>();
        if(pursuer!=null){
            Destroy(pursuer.gameObject);
        }
        instantiated = false;
    }
     */
}
