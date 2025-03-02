using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visebler : MonoBehaviour
{
      public bool Active = true;
      public GameObject GObject;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
        {
            GObject.SetActive(Active);
        }
    }
}
