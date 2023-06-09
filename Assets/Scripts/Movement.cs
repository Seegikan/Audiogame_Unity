using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class Movement : MonoBehaviour
{
    //Movimiento con inputs basicos prereferenciados de unity, Alexander 2023
    [SerializeField] CinemachineVirtualCamera cameraV;
    [SerializeField] float speedMovement;
    [SerializeField] private Rigidbody rigidBody;
    private Vector3 dirMovement;
    [SerializeField] private CapsuleCollider collider;
    [SerializeField] UnityEvent _OnWalking;


    void Update()
    {
       // transform.rotation = Quaternion.Euler(Vector3.right * 0.1f); 
        _OnWalking?.Invoke();
        //dirMovement = new Vector3(Input.GetAxisRaw("Horizontal") * speedMovement, 0f, Input.GetAxisRaw("Vertical") * speedMovement);
        dirMovement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized * speedMovement;
        //dirMovement = cameraV.transform.TransformDirection(dirMovement);
       // dirMovement = Vector3.ProjectOnPlane(dirMovement, Vector3.up);
        dirMovement.y = rigidBody.velocity.y;
        rigidBody.velocity = dirMovement;
    }
}


