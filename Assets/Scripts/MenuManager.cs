using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Button buttonPlay;

    [SerializeField]
    private UnityEngine.UI.Button buttonCredits;

    [SerializeField]
    private UnityEngine.UI.Button buttonExit;

    [SerializeField]
    private float timeToWait = 1f;
    [SerializeField]
    private float timer = 0f;

    [EventRef]
    public string audioEventPath; // Ruta del evento FMOD en el Inspector
    private FMOD.Studio.EventInstance audioEvent;

    private enum UIButtonSelection
    {
        play,
        credits,
        exit
    }
    [SerializeField]
    UIButtonSelection UIselection;


    // Start is called before the first frame update
    void Start()
    {
        UIselection = UIButtonSelection.play;
        audioEvent = FMODUnity.RuntimeManager.CreateInstance(audioEventPath);
        audioEvent.start();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timeToWait)
        {
            UIselection++;
            if(((int)UIselection) > 3) 
            {
                UIselection = 0;
            }
            switch (UIselection)
            {
                case UIButtonSelection.play:
                    //Reproducir audio play
                    buttonPlay.gameObject.SetActive(true);

                    buttonCredits.gameObject.SetActive(false);
                    buttonExit.gameObject.SetActive(false);

                    timer = 0f;
                    break;

                case UIButtonSelection.credits:
                    //Reproducir audio play
                    buttonCredits.gameObject.SetActive(true);

                    buttonExit.gameObject.SetActive(false);
                    buttonPlay.gameObject.SetActive(false);

                    timer = 0f;
                    break;

                case UIButtonSelection.exit:
                    //Reproducir audio play
                    buttonExit.gameObject.SetActive(true);


                    buttonCredits.gameObject.SetActive(false);
                    buttonPlay.gameObject.SetActive(false);

                    timer = 0f;
                    break;
            }
        }
    }

  
}
