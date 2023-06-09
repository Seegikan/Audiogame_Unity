using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using System;
using Unity.VisualScripting;
using System.Threading.Tasks;

public class RandomWhisper : MonoBehaviour
{
    [SerializeField]
    float maxTime = 45f;

    [SerializeField]
    float minTime = 10f;

    private float timeRan;

    [SerializeField]
    private EventReference eventReference; // Ruta del evento FMOD en el Inspector
    private FMOD.Studio.EventInstance eventInstance; // Ruta del evento FMOD en el Inspector

    void Start()
    {
        TimeRandom();
        PlayAudio();
    }

    private async void PlayAudio()
    {
        await Task.Delay(TimeSpan.FromSeconds(timeRan));
        eventInstance = FMODUnity.RuntimeManager.CreateInstance(eventReference);
        eventInstance.start();
        TimeRandom();
        PlayAudio();
    }

    private void TimeRandom()
    {
        timeRan = UnityEngine.Random.Range(minTime, maxTime);
    }
}
