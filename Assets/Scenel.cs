using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenel : MonoBehaviour
{
   
    public int IDscene;
    void Start()
    {
         
    
        SceneManager.LoadScene(IDscene);
    
    }

}
