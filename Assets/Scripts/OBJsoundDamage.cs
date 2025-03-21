using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJsoundDamage : MonoBehaviour
{
    public AudioClip sound;
    public AudioSource SRCA;
    public float DefVolume;

    private void Start() {
        SRCA.volume = PlayerPrefs.GetFloat("SoundEffects") * DefVolume;
        SRCA.clip = sound;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.relativeVelocity.magnitude > 2)
        {
            SRCA.Play();
        }
    }


}
