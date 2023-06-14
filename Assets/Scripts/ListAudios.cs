using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System;
using System.Threading.Tasks;
using FMOD.Studio;

public class ListAudios : MonoBehaviour
{
    private int index = 0;

    [SerializeField]
    float cooldown = 5f;

    [SerializeField]
    List<EventReference> eventReferenceList; // Ruta del evento FMOD en el Inspector
    private EventInstance eventInstance; // Ruta del evento FMOD en el Inspector
    private Collider sphereCollider;

    void Start()
    {
        sphereCollider = GetComponent<Collider>();
       // eventInstance = RuntimeManager.CreateInstance(eventReferenceList[index]);
        //RuntimeManager.AttachInstanceToGameObject(eventInstance, GetComponent<Transform>());
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            eventInstance = RuntimeManager.CreateInstance(eventReferenceList[index]);
            RuntimeManager.AttachInstanceToGameObject(eventInstance, GetComponent<Transform>());

            eventInstance.start();
            sphereCollider.gameObject.SetActive(false);
            index++;
            ActiveCollider();

            if (index == eventReferenceList.Count)
            {
                index = 0;
            }
        }
    }

    private async void ActiveCollider()
    {
        await Task.Delay(TimeSpan.FromSeconds(cooldown));
        sphereCollider.gameObject.SetActive(true);
    }
}
