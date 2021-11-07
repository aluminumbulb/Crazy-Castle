using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class PlayerPursuerBehavior : MonoBehaviour
{
    SphereCollider deathTrigger;
    // Start is called before the first frame update
    void Start()
    {
        deathTrigger = GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        }
    }
}
