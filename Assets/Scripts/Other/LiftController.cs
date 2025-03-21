using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftController : MonoBehaviour
{
    public ElectricalSystem elk;
    
    public GameObject _start;
     public GameObject _plat;
    public GameObject _end;
    public GameObject PlayerFixt;
    public GameObject Player;
    public float speed = 1;
    bool flag =false;

    public bool invert = false;
    
    void FixedUpdate()
    {
        if(invert)
        {
            if(!elk.Active)
        {
            if(_plat.transform.position.y <= _end.transform.position.y)
            {
                _plat.transform.position += Vector3.up * speed * Time.fixedDeltaTime;
                
                //if(flag)Player.transform.position = new Vector3(Player.transform.position.x,PlayerFixt.transform.position.y,Player.transform.position.z);
            }
            
        }
        if(elk.Active)
        {
            if(_plat.transform.position.y >= _start.transform.position.y)
            {
                _plat.transform.position -= Vector3.up * speed * Time.fixedDeltaTime;
               // if(flag)Player.transform.position = new Vector3(Player.transform.position.x,PlayerFixt.transform.position.y,Player.transform.position.z);
            }
            
        }
        }
        else
        {
        if(elk.Active)
        {
            if(_plat.transform.position.y <= _end.transform.position.y)
            {
                _plat.transform.position += Vector3.up * speed * Time.fixedDeltaTime;
                
                //if(flag)Player.transform.position = new Vector3(Player.transform.position.x,PlayerFixt.transform.position.y,Player.transform.position.z);
            }
            
        }
        if(!elk.Active)
        {
            if(_plat.transform.position.y >= _start.transform.position.y)
            {
                _plat.transform.position -= Vector3.up * speed * Time.fixedDeltaTime;
               // if(flag)Player.transform.position = new Vector3(Player.transform.position.x,PlayerFixt.transform.position.y,Player.transform.position.z);
            }
            
        }
        }


        
        
    }
    private void OnCollisionEnter(Collision other) {

        if(other.gameObject.tag == "Player")flag = true;
    }
    private void OnCollisionExit(Collision other) {

        if(other.gameObject.tag == "Player")flag = false;
    }
}
