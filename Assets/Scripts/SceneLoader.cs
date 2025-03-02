using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int sceneIDtrigger;
    public void Load(int IDscene)
    {
        SceneManager.LoadScene(IDscene);
    }
    public void ExitApp()
    {
        Application.Quit();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
           Load(sceneIDtrigger);
            
        }
    }
}
