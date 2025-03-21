using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LensContoller : MonoBehaviour
{
    private LaserLine _laserLine;
    [SerializeField] private Material _bloomMaterial;
    [SerializeField] private Material _glassMaterial;
    [SerializeField] private MeshRenderer _renderer;
    public float distance = 0.5f;
    private void Start()
    {
        _laserLine = GetComponent<LaserLine>();

    }
    private void FixedUpdate()
    {
        
        if (_laserLine.isActiveLazer)
        {
            _renderer.material = _bloomMaterial;
        }
        else
        {
            if (_laserLine.Lens != null)
            {
                _laserLine.Lens.GetComponent<LaserLine>().isActiveLazer = false;
            }
            _laserLine.Lens = null;
            _laserLine.isIsocknikLazer = false;
            _renderer.material = _glassMaterial;
        }
        if (_laserLine.isIsocknikLazer == false)
        {
            RaycastHit hit;
            Debug.DrawRay(transform.GetChild(0).position, Vector3.down * distance, Color.yellow);
            if (Physics.Raycast(new Ray(transform.GetChild(0).position, Vector3.down), out hit))
            {
                float distance = Vector3.Distance(hit.point, transform.GetChild(0).position) - transform.localScale.x/2f;
                if (hit.collider.tag == "Lens" && distance < 0.1f && hit.collider.GetComponent<LaserLine>().isActiveLazer)
                {
                    _laserLine.isActiveLazer = true;
                    return;
                }
                else
                    _laserLine.isActiveLazer = false;
            }
            if (Physics.Raycast(new Ray(transform.GetChild(0).position, Vector3.up), out hit))
            {
                float distance = Vector3.Distance(hit.point, transform.GetChild(0).position) - transform.localScale.x / 2f;
                if (hit.collider.tag == "Lens" && distance < 0.1f && hit.collider.GetComponent<LaserLine>().isActiveLazer)
                    _laserLine.isActiveLazer = true;
                else
                    _laserLine.isActiveLazer = false;
            }
        }
            
    }
}
