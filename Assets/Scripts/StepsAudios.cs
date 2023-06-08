
using UnityEngine;
using FMODUnity;


public class StepsAudios : MonoBehaviour
{
    [SerializeField]
    private float timeNextStep = 0.7f;
    private float timer;
    [SerializeField] 
    private Rigidbody rigidbody;
    private bool touchWalls = false;

    [SerializeField]
    private EventReference eventReference; // Ruta del evento FMOD en el Inspector
    private FMOD.Studio.EventInstance eventInstance; // Ruta del evento FMOD en el Inspector

    // Update is called once per frame
    void Update()
    {
        if (!touchWalls)
        {
            if (rigidbody.velocity.magnitude > 1f)
            {
                timer += Time.deltaTime;
            }

            if (timer > timeNextStep)
            {
                timer = 0f;
                eventInstance = FMODUnity.RuntimeManager.CreateInstance(eventReference);
                eventInstance.start();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            touchWalls = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            touchWalls = false;
        }
    }
}
