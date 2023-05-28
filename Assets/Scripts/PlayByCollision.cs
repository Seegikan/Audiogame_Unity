using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlayByCollision : MonoBehaviour
{
    [SerializeField]
    private EventReference eventReference; // Ruta del evento FMOD en el Inspector
    private FMOD.Studio.EventInstance eventInstance; // Ruta del evento FMOD en el Inspector

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            eventInstance = FMODUnity.RuntimeManager.CreateInstance(eventReference);
            eventInstance.start();
            gameObject.SetActive(false);
        }
    }
}
