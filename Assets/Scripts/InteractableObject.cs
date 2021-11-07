using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractableObject : MonoBehaviour
{
    public bool canClick;
    private SphereCollider trigger;
    
    private void Start() {
        trigger = GetComponent<SphereCollider>();
    }
}
