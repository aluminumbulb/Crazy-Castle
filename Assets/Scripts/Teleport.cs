using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Teleport : MonoBehaviour
{
    [SerializeField] Teleport[] destinations;
    public Teleport neighbor;
    public enum Direction { up=0, right=1, down=2, left=3 }
    public Direction dir;
    private Teleport dest;
    //an overrulling teleport determined by staking:
    public Teleport pt = null;
    private Transform p;
    private Transform m;
    private VirtualEnemyController vc;
    private float distance;
    private const float CLOSE = 5;
    private const float FAR = 25;

    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").transform;
        m = GameObject.FindGameObjectWithTag("Enemy").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        // get the proper destination
        distance = Vector3.Distance(p.position, m.position);
        if (distance < CLOSE)
        {
            // other side of room
            dest = destinations[0];
        }
        else if (distance < FAR)
        {
            // far, far away
            dest = destinations[1];
        }
        else{
            // no teleport
            dest = destinations[2];
        }

        // if pt(staked room) in destinations, go there
        if (destinations.Contains(pt)){
            dest = pt;
        }

        //print(this.name + ' ' + this.dir + " : " + dest.name + ' ' + dest.dir);
        neighbor.gameObject.SetActive(false);
        if (other.GetComponent<Player>() && dest != this.neighbor)
        {
            float xOffset = 0;
            float zOffset = 0;
            Camera camera = other.GetComponentInChildren<Camera>();
            var thisDir = (int)this.dir;
            var thatDir = (int)dest.dir;

            // If the hallways go in same directions:
            if (this.dir == dest.dir)
            {
                xOffset = -(other.transform.position.x - this.transform.position.x);
                zOffset = -(other.transform.position.z - this.transform.position.z);
            }
            // If the hallways go in the opposite direction:
            else if ((int)this.dir % 2 == (int)dest.dir % 2)
            {
                xOffset = other.transform.position.x - this.transform.position.x;
                zOffset = other.transform.position.z - this.transform.position.z;
            }
            // If the exit hallway is to the right of enter hallway:
            else if (thisDir + 1 == thatDir || (thisDir == 3 && thatDir == 0))
            {
                xOffset = -(other.transform.position.z - this.transform.position.z);
                zOffset = other.transform.position.x - this.transform.position.x;

            }
            // If the exit hallway is to the left of enter hallway:
            else
            {
                xOffset = other.transform.position.z - this.transform.position.z;
                zOffset = -(other.transform.position.x - this.transform.position.x);
            }

            switch (thatDir)
            {
                case 0:
                    xOffset += 2;
                    break;
                case 1:
                    zOffset -= 2;
                    break;
                case 2:
                    xOffset -= 2;
                    break;
                case 3:
                    zOffset += 2;
                    break;
            }

            var oldY = other.gameObject.transform.position.y;
            other.gameObject.transform.position = dest.gameObject.transform.position;
            other.gameObject.transform.position = new Vector3(
                other.gameObject.transform.position.x + xOffset,
                oldY,
                other.gameObject.transform.position.z + zOffset
            );

            camera.transform.eulerAngles = new Vector3(
                camera.transform.eulerAngles.x,
                camera.transform.eulerAngles.y + 
                (dest.gameObject.transform.eulerAngles.y - this.gameObject.transform.eulerAngles.y + 180),
                camera.transform.eulerAngles.z
            );


            dest.gameObject.SetActive(false);
            dest.neighbor.gameObject.SetActive(false);
            StartCoroutine(ReactivateDestination());
        }
    }

    IEnumerator ReactivateDestination() {
        yield return new WaitForSeconds(2);
        dest.gameObject.SetActive(true);
        dest.neighbor.gameObject.SetActive(true);
        neighbor.gameObject.SetActive(true);
    }

    public void OpenToStakedRoom(){
        //Get all teleport objects
        Teleport[] allTeleports = FindObjectsOfType<Teleport>();
        foreach(Teleport tp in allTeleports){
            //see if any lead into this room
            if(Array.Exists(tp.destinations, x => x==this)){
                Debug.Log("Stake Successful");  //this seems to be happening too many times
                //update their pt, preferred teleport
                tp.pt=this;
            }
        }
    }

    public void CloseStakedRoom(){
        Teleport[] allTeleports = FindObjectsOfType<Teleport>();
        foreach(Teleport tp in allTeleports){
            //check to see who has this room as their preferred
            if(tp.pt == this){
                Debug.Log("Stake Cleared");
                tp.pt=null;
            }
        }
    }
}
