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

    //Ejemplo de UnityEvent
    [SerializeField] UnityEvent _OnWalking;


    void Update()
    {
        _OnWalking?.Invoke();
        dirMovement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized * speedMovement;
        dirMovement.y = rigidBody.velocity.y;
        rigidBody.velocity = dirMovement;
    }
}


