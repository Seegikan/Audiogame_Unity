using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffLightInPlay : MonoBehaviour
{
    [SerializeField] private Light sunLight;
    [SerializeField] private Color colorNight; 

    void Start()
    {
        sunLight.color = colorNight;
    }

}
