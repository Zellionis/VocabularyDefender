using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void OnPlayClick()
    {
        SceneManager.LoadScene("Scenes/Game");
    }
    
    public void OnQuitClick()
    {
        Application.Quit();
    }
}
