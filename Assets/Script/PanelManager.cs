using System;
using System.Collections;
using System.Collections.Generic;
using Script;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{

    [SerializeField] private TMP_Text score = null;
    [SerializeField] private TMP_Text wrongWordList = null;
    
    public GameObject pausePanel = null;
    public GameObject gameOverPanel = null;

    public void SetPause(bool _pause)
    {
        pausePanel.SetActive(_pause);
    }
    
    public void SetGameOver(List<Word> _wrongWords)
    {
        gameOverPanel.SetActive(true);
        score.text = Player.Score.ToString();
        
        foreach (var word in _wrongWords)
        {
            wrongWordList.text += word.BaseWord + " : " + word.MainTrad+"\n";
        }
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
