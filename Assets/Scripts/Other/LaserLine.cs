using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LaserLine : MonoBehaviour
{
    [SerializeField] private float _widthLazer = 0.2f;
    private LineRenderer lineRenderer;
    public bool isActiveLazer = false;
    public bool isIsocknikLazer = false;
    [SerializeField] public GameObject Lens;
    [SerializeField] private GameObject _Finish;
    public GameObject objectHit;

    public GameObject Light;
    private Rigidbody _Rigidbody;
    
    void Start()
    {
        if (gameObject.tag == "Lazer")
        {
            isActiveLazer = true;
            
        }
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startWidth = _widthLazer;
        lineRenderer.endWidth = _widthLazer;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position);
        _Rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isActiveLazer)
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.position);
            

            return;
        }

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, hit.point);
        objectHit = hit.collider.gameObject;
        string tag = objectHit.tag; 
        if (isActiveLazer && Light != null )
            {
                Light.SetActive(true);
                Light.transform.position = hit.point;
            }
            else
            {
                Light.SetActive(false);
            }
        if (objectHit != null)
        {

           


            if (objectHit.tag == "Lens" && Lens == null)
            {
                Lens = objectHit;
                Lens.GetComponent<LaserLine>().isActiveLazer = true;
                Lens.GetComponent<LaserLine>().isIsocknikLazer = true;

            }
            if (objectHit == Lens && !Lens.GetComponent<LaserLine>().isActiveLazer) Lens.GetComponent<LaserLine>().isActiveLazer = true;
            if (Lens != objectHit && objectHit.tag == "Lens")
            {
                Lens.GetComponent<LaserLine>().isActiveLazer = false;
                Lens.GetComponent<LaserLine>().isIsocknikLazer = false;
                Lens = objectHit;
                Lens.GetComponent<LaserLine>().isActiveLazer = true;
                Lens.GetComponent<LaserLine>().isIsocknikLazer = true;
            }
            if (Lens != objectHit && Lens != null)
            {
                Lens.GetComponent<LaserLine>().isActiveLazer = false;
                Lens.GetComponent<LaserLine>().isIsocknikLazer = false;
                Lens = null;
            }
            /*if (Lens != null && gameObject.tag != "Lazer")
            {
                if (Lens.GetComponent<LaserLine>().Lens != null  && objectHit.tag == "Lens" && Lens.GetComponent<LaserLine>().objectHit.tag == "Lens")
                {
                    Lens.GetComponent<LaserLine>().isActiveLazer = false;
                    Lens.GetComponent<LaserLine>().isIsocknikLazer = false;
                    isActiveLazer = false;
                    isIsocknikLazer = false;
                    _Rigidbody.AddForce(Vector3.right * 10f + Vector3.up * 10f, ForceMode.Impulse);
                    Lens.GetComponent<Rigidbody>().AddForce(Vector3.right * 10f + Vector3.up * 10f, ForceMode.Impulse);
                    Lens.GetComponent<LaserLine>().Lens = null;
                    Lens = null;
                }
            }*/

            if (objectHit.tag == "Finish")
            {
                _Finish = objectHit;
                _Finish.GetComponent<ElectricalSystem>().Active = true;  
            }
            else
            {
                _Finish.GetComponent<ElectricalSystem>().Active = false;
               
            }

            
        }
    }
}
