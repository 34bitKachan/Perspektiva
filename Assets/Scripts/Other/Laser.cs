using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject _start;
    public GameObject lr;
    public GameObject _end;
    GameObject Buff;

   private void Start() {
   
   }
    void Update()
    {
        Ray ray = new Ray(_start.transform.position,-transform.forward);
        RaycastHit hit;
        Physics.Raycast(ray,out hit);
        Buff = hit.collider.gameObject;
        if(hit.collider.gameObject.tag == "Finish"){
            _end.GetComponent<ElectricalSystem>().Active =true;lr.SetActive(true);
        }
        else
        {
            lr.SetActive(false);
            _end.gameObject.GetComponent<ElectricalSystem>().Active =false;
        }    


    }
}
