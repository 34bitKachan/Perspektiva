using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityRush : MonoBehaviour
{
   private void OnTriggerEnter(Collider other) {
    if(other.GetComponent<Rigidbody>())
    {
        other.GetComponent<Rigidbody>().useGravity = false;
    }
   }
   private void OnTriggerExit(Collider other) {
    if(other.GetComponent<Rigidbody>())
    {
        other.GetComponent<Rigidbody>().useGravity = true;
    }
   }
   private void OnTriggerStay(Collider other) {
    if(other.GetComponent<Rigidbody>())
    {
        other.GetComponent<Rigidbody>().useGravity =false;
    }
   }
}
