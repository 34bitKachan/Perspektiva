using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLoaderVol : MonoBehaviour
{
    public float DefVolume;
    public bool Fon = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Fon)
        {
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SoundEffects") * DefVolume;
        }
        else
        {
            GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Sound") * DefVolume;
        }
      
    }
}
