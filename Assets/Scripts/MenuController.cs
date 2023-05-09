using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayBtn()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void SettingsBtn()
    {

    }

    public void ExitBtn()
    {
        Application.Quit();
    }

    public void ContinueBtn()
    {
        
    }

    public void PauseBtn()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
