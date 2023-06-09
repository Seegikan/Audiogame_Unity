using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System;
using System.Threading.Tasks;

public class ListAudios : MonoBehaviour
{
    private int index = 0;

    [SerializeField]
    float cooldown = 5f;

    [SerializeField]
    List<EventReference> eventReferenceList; // Ruta del evento FMOD en el Inspector
    private FMOD.Studio.EventInstance eventInstance; // Ruta del evento FMOD en el Inspector
    private Collider sphereCollider;

    void Start()
    {
        sphereCollider = GetComponent<Collider>();
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            eventInstance = FMODUnity.RuntimeManager.CreateInstance(eventReferenceList[index]);
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
