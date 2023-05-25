using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayBtn()
    {
        SceneManager.LoadScene("Main Scene");
    }

    public void ExitBtn()
    {
        Application.Quit();
    }

    public void MenuBtn()
    {
        SceneManager.LoadScene("Main Menu");
    }


}
