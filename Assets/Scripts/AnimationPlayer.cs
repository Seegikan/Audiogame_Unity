using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private Animator animator;

    private bool CanWalk = true;

    // Update is called once per frame
    void Update()
    {
        if (CanWalk)
            animator.SetFloat("Velocity", rb.velocity.magnitude);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall")) 
        { 
            CanWalk = false;
            animator.SetFloat("Velocity", 0f);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall")) 
        {
            CanWalk = true;
        }
    }
}
