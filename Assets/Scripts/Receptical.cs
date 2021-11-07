using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receptical : MonoBehaviour
{
    Player p;
    public ExitPortalControl portal;
    private void Start() {
        p = FindObjectOfType<Player>();
       // portal = FindObjectOfType<ExitPortalControl>();
    }

    private void OnMouseDown() {
        if(p.HasOrb){
            portal.gameObject.SetActive(true);
        }
    }
}
