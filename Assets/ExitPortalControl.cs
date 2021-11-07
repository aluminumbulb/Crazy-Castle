using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class ExitPortalControl : MonoBehaviour
{
    private void OnTriggerEnter(){
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
