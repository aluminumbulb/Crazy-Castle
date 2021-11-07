using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableItem : MonoBehaviour
{
    Player p;
    
    private void Start() {
        p = FindObjectOfType<Player>();
    }

    public void pickup() {
        p.HasOrb = true;
        Destroy(this.gameObject);
    }
}
