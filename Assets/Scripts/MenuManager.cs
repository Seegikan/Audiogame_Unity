using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using System;
using System.Threading.Tasks;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Button buttonPlay;

    [SerializeField]
    private UnityEngine.UI.Button buttonCredits;

    [SerializeField]
    private UnityEngine.UI.Button buttonExit;

    [SerializeField]
    private TMPro.TextMeshProUGUI textWelcome;

    [SerializeField]
    private TMPro.TextMeshProUGUI textCredits;

    [SerializeField]
    private float timeToWait = 1f;
    [SerializeField]
    private float timer = 0f;

    private int maxIndexCase = 3;
    [SerializeField]
    public EventReference audioPlay; // Ruta del evento FMOD en el Inspector
    [SerializeField]
    public EventReference audioCredits; // Ruta del evento FMOD en el Inspector
    [SerializeField]
    public EventReference audioExit; // Ruta del evento FMOD en el Inspector
    [SerializeField]
    public EventReference audioCreditsNames; // Ruta del evento FMOD en el Inspector
    [SerializeField]
    public EventReference bonefireMenu; // Ruta del evento FMOD en el Inspector
    public FMOD.Studio.EventInstance bonefireMenuEvent; // Ruta del evento FMOD en el Inspector

    private FMOD.Studio.EventInstance audioEvent;

    private enum UIButtonSelection
    {
        welcome,
        play,
        credits,
        exit,
        creditsPlay,
    }

    [SerializeField]
    UIButtonSelection UIselection;


    void Start()
    {
        bonefireMenuEvent = FMODUnity.RuntimeManager.CreateInstance(bonefireMenu);
        bonefireMenuEvent.start();
        UIselection = UIButtonSelection.welcome;
        audioEvent = FMODUnity.RuntimeManager.CreateInstance(audioPlay);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timeToWait)
        {
            UIselection++;

            if(((int)UIselection) > maxIndexCase) 
            {
                UIselection = UIButtonSelection.play;
            }

            switch (UIselection)
            {
                case UIButtonSelection.welcome:
                    timer = 0f;
                    //timeToWait = 5f;
                    break;

                case UIButtonSelection.play:
                    //Reproducir audio play
                    textWelcome.gameObject.SetActive(false);
                    timeToWait = 4f;
                    audioEvent = FMODUnity.RuntimeManager.CreateInstance(audioPlay);
                    audioEvent.start();

                    buttonPlay.gameObject.SetActive(true);

                    buttonCredits.gameObject.SetActive(false);
                    buttonExit.gameObject.SetActive(false);

                    timer = 0f;
                    break;

                case UIButtonSelection.credits:
                    //Reproducir audio play
                    timeToWait = 4f;

                    audioEvent = FMODUnity.RuntimeManager.CreateInstance(audioCredits);
                    audioEvent.start();

                    buttonCredits.gameObject.SetActive(true);

                    buttonExit.gameObject.SetActive(false);
                    buttonPlay.gameObject.SetActive(false);

                    timer = 0f;
                    break;

                case UIButtonSelection.exit:
                    //Reproducir audio play
                    timeToWait = 4f;
                    audioEvent = FMODUnity.RuntimeManager.CreateInstance(audioExit);
                    audioEvent.start();

                    buttonExit.gameObject.SetActive(true);
                    textCredits.gameObject.SetActive(false);
                    buttonCredits.gameObject.SetActive(false);
                    buttonPlay.gameObject.SetActive(false);

                    timer = 0f;
                    break;

                case UIButtonSelection.creditsPlay:
                    timeToWait = 17f;
                    audioEvent = FMODUnity.RuntimeManager.CreateInstance(audioCreditsNames);
                    audioEvent.start();

                    buttonExit.gameObject.SetActive(false);
                    buttonCredits.gameObject.SetActive(false);
                    buttonPlay.gameObject.SetActive(false);

                    timer = 0f;
                    break;
            }
        }

       
    }

    public void PlayCredits()
    {
        audioEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        timer = 0f;
        buttonCredits.gameObject.SetActive(false);
        textCredits.gameObject.SetActive(true);
        timeToWait = 18f;
        audioEvent = FMODUnity.RuntimeManager.CreateInstance(audioCreditsNames);
        audioEvent.start();
        buttonExit.gameObject.SetActive(false);
        buttonCredits.gameObject.SetActive(false);
        buttonPlay.gameObject.SetActive(false);

        //NextButton();
    }
    /*
    private async void NextButton()//Funcion reboot with delay 
    {
        await Task.Delay(TimeSpan.FromSeconds(17f));
        UIselection = UIButtonSelection.exit;
        
    }
    */
    public void OnClicPlay()
    {
        audioEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        bonefireMenuEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}
