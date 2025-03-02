using System;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterContoller;
    private Rigidbody rb;

    [SerializeField] private float speed = 3f;
    [SerializeField] private float Jump = 2f;
    [SerializeField] private float distanceRay = 1.2f;
    private void Start()
    {
        _characterContoller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        
    }


    void Update() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    //f(_characterContoller.isGrounded)if(Input.GetKeyDown(KeyCode.Space))Jmp();
    }
    void FixedUpdate() {
       rb.MovePosition(transform.position +_movement * speed * Time.fixedDeltaTime);
        if (Input.GetAxis("Jump") > 0 && _isGroundet) rb.AddForce(Vector3.up * Jump, ForceMode.Impulse);
    }

    private Vector3 _movement
    {
        get
        {
            float hor = Input.GetAxis("Horizontal") ;
            float ver = Input.GetAxis("Vertical") ;

            Vector3 move = transform.right * hor + transform.forward * ver;
            return move;
        }
    }


    private bool _isGroundet
    {
        get { 
            if (Physics.Raycast(transform.position, -Vector3.up, distanceRay))
            {
                return true;
            }
            else return false;
        }
    }
 
}
