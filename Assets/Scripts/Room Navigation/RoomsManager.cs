using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsManager : MonoBehaviour
{
    /*
    Room[] allRooms;
    PlayerRoomNavigation player;
    VirtualEnemyController ve;
    // Start is called before the first frame update
    void Start()
    {
        allRooms = FindObjectsOfType<Room>();
        player = FindObjectOfType<PlayerRoomNavigation>();
        //ve = FindObjectOfType<VirtualEnemyController>();
        //Not normally where this would run, but just a test:
        //StartCoroutine(quickTester());
    }

    private IEnumerator quickTester(){
        for(int i = 0; i<2; i++){
            yield return new WaitForSeconds(1);
            OnPlayerExit();
        }
    }

    public void ResetRoomDistances(){
        foreach(Room room in allRooms){
            room.distFromPlayer = int.MaxValue;
        }
    }


    public void OnPlayerExit(){
        //function to have player update room (or mabye call this function from the player after updated)
        //With the player moved, reset everything in the scene
        setRoomConditions();
        //move the monster
        //ve.TakeTurn();
    }

    //BFS code courtesy of koderdojo.com
    public void setRoomConditions(){
    //To make this work, we have to initialize all room's distanceFromPlayers to inf
        ResetRoomDistances();
    //Run a version of BFS that starts from the current room,
        HashSet<Room> visited = new HashSet<Room>();

        //skipped check for player's existance
        Queue<Room> queue = new Queue<Room>();
        //Begin search from the room the player is in
        queue.Enqueue(player.currRoom);
        //Set the room the player is in to 0 for 0 distance
        player.currRoom.distFromPlayer = 0;
        //Flag for if the enemy's room has been found yet
        bool enemyFound = false;
        while (queue.Count > 0){

            Room inspRoom = queue.Dequeue();

            if (visited.Contains(inspRoom)){
                continue;
            }

            visited.Add(inspRoom);
            //Add exits of the room here
            //Enemy check:
            if (inspRoom == ve.currRoom){
                enemyFound = true;
            }
            foreach(Room neighbor in inspRoom.adjacentRooms){
                if(!visited.Contains(neighbor)){
                    //Update distFromPlayer for touched locations
                    neighbor.distFromPlayer = inspRoom.distFromPlayer + 1;
                    if(!enemyFound){
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
    }
    */
}
