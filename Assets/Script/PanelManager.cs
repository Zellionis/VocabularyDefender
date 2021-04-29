using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{

    [SerializeField] private TMP_Text score = null;
    
    public GameObject pausePanel = null;
    public GameObject gameOverPanel = null;

    public void SetPause(bool _pause)
    {
        pausePanel.SetActive(_pause);
    }
    
    public void SetGameOver()
    {
        gameOverPanel.SetActive(true);
        score.text = Player.Score.ToString();
    }
    
    public void OnRestartClick()
    {
        SceneManager.LoadScene("Scenes/Game");
    }

    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("Scenes/Menu");
    }
}
