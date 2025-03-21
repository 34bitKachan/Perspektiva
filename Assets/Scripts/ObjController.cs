using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjController : MonoBehaviour
{
    public GameObject Obj;
    public GameObject Pointer;
    public GameObject UIobj;

    public GameObject eff1;
    public GameObject eff2;
    public GameObject eff3;

    public ParticleSystem pr1;

    bool flagObj;
    int mode;
    public float speedpod =5;

Vector3 scll;
  
    void Start()
    {
        
    }

    
    void LateUpdate()
    {
   
        Ray ray = new Ray(transform.position,transform.forward);
        


        RaycastHit hit;
        Physics.Raycast(ray,out hit);

        if(!flagObj)
        {
            if(hit.collider.gameObject.tag == "Obj" || hit.collider.gameObject.tag == "Lens" || hit.collider.gameObject.tag == "ObjS")
             {
                      UIobj.SetActive(true);   
                     if(hit.collider.gameObject.tag != "ObjS")
                     {
                        if(Input.GetMouseButtonDown(0))
                        {
                             Obj = hit.collider.gameObject;
                             //Obj.GetComponent<BoxCollider>().enabled = false;
                            Obj.layer = LayerMask.NameToLayer("Ignore Raycast");
                             flagObj = true;
                             UIobj.SetActive(false);  
                            eff1.SetActive(true);
                             mode = 1;
                        }
                     }
                     

                        if(Input.GetMouseButtonDown(1))
                        {
                             Obj = hit.collider.gameObject;
                            Obj.GetComponent<Rigidbody>().useGravity = !Obj.GetComponent<Rigidbody>().useGravity;
                             flagObj = true;
                             UIobj.SetActive(false);  
                             eff2.SetActive(true);
                              mode = 2;
                        }

                        if(Input.GetMouseButtonDown(2))
                        {
                             Obj = hit.collider.gameObject;
                            Obj.GetComponent<Rigidbody>().useGravity = !Obj.GetComponent<Rigidbody>().useGravity;
                            Obj = null;
                             
                              
                        }
             }
             else
             {      
                    
                    UIobj.SetActive(false);   
             }
        }
        else
        {
           
            switch(mode)
            {
                case 1:
                float scale = Vector3.Distance(Obj.transform.position,transform.position);
                Obj.transform.localScale =   (Vector3.one * 0.08F  * scale);
                Obj.GetComponent<Rigidbody>().velocity = (hit.point - Obj.transform.position) * speedpod;
               // Obj.transform.rotation = Pointer.transform.rotation;
                if(Input.GetMouseButtonUp(0))
                        {
                            Obj.layer = LayerMask.NameToLayer("Default");
                             //Obj.GetComponent<BoxCollider>().enabled = true;
                             Obj = null;
                            flagObj = false;
                             mode = 0; 
                             eff1.SetActive(false);
                        }

                break;
                case 2:
                Obj.GetComponent<Rigidbody>().velocity = (Pointer.transform.position - Obj.transform.position) * speedpod;
                
                if(Input.GetMouseButtonUp(1))
                        {
                              Obj.GetComponent<Rigidbody>().useGravity = !Obj.GetComponent<Rigidbody>().useGravity;
                             Obj = null;
                             flagObj = false;
                             mode = 0; 
                             eff2.SetActive(false);
                        }
                break;
            }
            

            
            

        }
        


            
        

        
         //float scale = Vector3.Distance(Obj.transform.position,transform.position);
          //  Obj.transform.localScale =  Vector3.one * 0.08F * scale;

        
    }
}
