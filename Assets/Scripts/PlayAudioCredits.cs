using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class PlayAudioCredits : MonoBehaviour
{

    [SerializeField]
    private float TimeWaitOn = 1f; //Debe durar lo que dura el audio de creditos

    [SerializeField] 
    private MenuManager menuManager;

    public void DelayMenu()
    {
        menuManager.enabled = false;
        TurnOnMenu();
    }

    private async void TurnOnMenu()//Funcion reboot with delay 
    {
        await Task.Delay(TimeSpan.FromSeconds(TimeWaitOn));
        menuManager.enabled = true;
    }
}
