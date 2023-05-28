using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FuncionsButtons : MonoBehaviour
{
    [SerializeField]
    private string NameScene;
    public void CambiarEscena(string NameScene)
    {
        SceneManager.LoadScene(NameScene);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
    
}
