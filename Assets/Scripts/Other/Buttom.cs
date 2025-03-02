using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttom : MonoBehaviour
{
    [SerializeField] private ElectricalSystem[] _electricalSystems;
    [SerializeField] private float _scaleActivMin = 1f;
    [SerializeField] private float _scaleActivMax = 1.5f;
    [SerializeField] private float _distanceDown;
    [SerializeField] private float _timeDown = 0.01f;
    private Vector3 _startPos;
    [SerializeField] private bool _activeButton = false;
    void Start()
    {
        _startPos = transform.position;
    }

    void Update()
    {
        if(_activeButton)
        {
            transform.position = Vector3.Lerp(transform.position, _startPos - Vector3.up * _distanceDown, _timeDown);
        }
        else if(!_activeButton)
        {
            transform.position = Vector3.Lerp(transform.position, _startPos, _timeDown);
        }
    }

    private void OnTriggerStay(UnityEngine.Collider other)
    {
        GameObject gam = other.gameObject;
        if (gam.tag == "Obj" && gam.transform.localScale.y > _scaleActivMin && gam.transform.localScale.y < _scaleActivMax)
        {
            foreach (ElectricalSystem el in _electricalSystems)
                el.Active = true;
            _activeButton = true;
        }
        else
        {
            foreach (ElectricalSystem el in _electricalSystems)
                el.Active = false;
            _activeButton = false;
        }
    }

    private void OnTriggerExit(UnityEngine.Collider other)
    {
        GameObject gam = other.gameObject;
        if (gam.tag == "Obj")
        {
            foreach (ElectricalSystem el in _electricalSystems)
                el.Active = false;
            _activeButton = false;
        }
    }
}
