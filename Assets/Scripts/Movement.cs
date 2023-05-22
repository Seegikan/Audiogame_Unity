using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class Movement : MonoBehaviour
{
    //Movimiento con inputs basicos prereferenciados de unity, Alexander 2023
    [SerializeField] CinemachineFreeLook camera;
    [SerializeField] float speedMovement;
    [SerializeField] private Rigidbody rigidBody;
    private Vector3 dirMovement;
    [SerializeField] private CapsuleCollider collider;

    void Update()
    {
        dirMovement = new Vector3(Input.GetAxisRaw("Horizontal") * speedMovement, 0f, Input.GetAxisRaw("Vertical") * speedMovement);
        dirMovement = camera.transform.TransformDirection(dirMovement);
        dirMovement = Vector3.ProjectOnPlane(dirMovement, Vector3.up);
        dirMovement.y = rigidBody.velocity.y;
        rigidBody.velocity = dirMovement;
    }
}


