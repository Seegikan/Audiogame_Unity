using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class AudioCloser : MonoBehaviour
{
    [SerializeField]
    private StudioEventEmitter Audio;

    //[SerializeField] private EmitterRef anEmitter;
    [SerializeField]
    private SphereCollider sphereCollider;

    void Start()
    {
        sphereCollider.radius = Audio.OverrideMaxDistance * 2f;
    }

    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, sphereCollider.radius);
    }
}
