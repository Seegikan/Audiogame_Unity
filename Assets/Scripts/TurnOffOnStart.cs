using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffOnStart : MonoBehaviour
{
    [SerializeField]
    private MeshRenderer m_Renderer;
    void Start()
    {
        m_Renderer.enabled = false;
    }

}
