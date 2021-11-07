using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActivation : MonoBehaviour
{
    public CameraController eyeballs;
    // Start is called before the first frame update

    public globalVars gVars;
    private bool shouldStartDelay = false;
    private int stakes = 3;
    private PursuerNavigation monster;

    [SerializeField]
    private Text tb;
    void Start()
    {
        gVars.isStaked = false;
        monster = FindObjectOfType<PursuerNavigation>();
    }

    // Update is called once per frame
    void Update()
    {

    tb.text = "Stakes: " + stakes;
        //On click or activation
        if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.E)){
           RaycastHit hit = eyeballs.camHit();
           if(hit.transform!=null){
               //Goes through list of clickable things to run the appropriate code
               PickupableItem item = hit.transform.GetComponent<PickupableItem>();
               if(item!=null){
                   item.pickup();
               }

                //Have we just clicked the pursuer?
               PursuerNavigation pursuer = hit.transform.GetComponent<PursuerNavigation>();
               if(pursuer!=null){
                   StakeMonster();
               }
           }
        }

        //Cast a ray to determine what it is we're even talking about
        //Check to see if this thing would react to being clicked
        //Make sure we're at an appropriate distance

        //float dist = Vector3.Distance(transform.position, monster.transform.position);
        //print(dist);
        //placing the stake in the monster
        //if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.E) && dist < 6 && dist > 0 && stakes > 0){
            //StakeMonster
        //}

        if(shouldStartDelay){
            shouldStartDelay = false;
            StartCoroutine(stakePopOut());
        }
    }

    private void OnApplicationQuit() {
        gVars.isStaked = false;
    }

    //pops stake out after x seconds (in this case, 3)
    IEnumerator stakePopOut(){
        yield return new WaitForSeconds(3.0f);
        gVars.isStaked = false;
    }

    
    private void OnTriggerEnter(Collider col) {
        if(col.gameObject.CompareTag("Stake")){
            Destroy(col.gameObject);
            gVars.stakeCount++;
            //print(stakes);
        }
    }
    
    private void StakeMonster(){
        if(stakes > 0){
            stakes--;
            gVars.isStaked = true;
            shouldStartDelay = true;
        }
    }

}
