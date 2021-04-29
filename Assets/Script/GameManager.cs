using System;
using Script;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextAsset wordsFile = null;
    [SerializeField] private TMP_InputField inputField = null;
    [SerializeField] private TextDisplayer textDisplayer = null;
    
    [SerializeField] private Player player = null;
    [SerializeField] private MonsterManager monsterManager = null;
    [SerializeField] private PanelManager panelManager = null;


    private Words words = null; // Store list of word
    
    private Word thirdWord = null;
    private Word secondWord = null;
    private Word lastWord = null;
    private Word currentWord = null; // Store current word

    private bool pause = false;
    private bool loose = false;
    
    // Start is called before the first frame update
    void Start()
    {
        words = new Words(wordsFile.text);
        
        thirdWord = words.GetRandomWord();
        secondWord = words.GetRandomWord();
        lastWord = words.GetRandomWord();
        currentWord = words.GetRandomWord();
        
        textDisplayer.NextWord(currentWord.BaseWord);
        textDisplayer.NextWord(lastWord.BaseWord);
        textDisplayer.NextWord(secondWord.BaseWord);
        textDisplayer.NextWord(thirdWord.BaseWord);
        
        inputField.Select();
        
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.Hp <= 0)
        {
            Time.timeScale = 0;
            loose = true;
            panelManager.SetGameOver();
            panelManager.SetPause(false);
        }
        
        if(loose)
            return;
        
        if (Input.GetButtonDown("Pause") && !pause)
        {
            Time.timeScale = 0;
            pause = true;
            panelManager.SetPause(true);
        }
        else if(Input.GetButtonDown("Pause"))
        {
            Time.timeScale = 1;
            pause = false;
            panelManager.SetPause(false);
        }

        if(pause)
            return;
        
        if (!inputField.isFocused)
            inputField.Select();

        if (monsterManager.Mobs.Count > 0)
        {
            if (monsterManager.Mobs[0] == null)
            {
                monsterManager.Mobs.RemoveAt(0);
            }
        }

        if (Input.GetButtonDown("Submit") && monsterManager.Mobs.Count > 0)
        {
            if (currentWord.IsTraduction(inputField.text.Trim()))
            {
                Debug.Log("True !");
                player.Fire(monsterManager.Mobs);
                player.combo += 1;
            }
            else
            {
                Debug.Log("False !");
                //player.combo = 0;
                //TODO:Remove before build
                player.Fire(monsterManager.Mobs);
                player.combo += 1;

            }
            
            currentWord = lastWord;
            lastWord = secondWord;
            secondWord = thirdWord;
            thirdWord = words.GetRandomWord();
            
            textDisplayer.NextWord(thirdWord.BaseWord);
            
            inputField.text = "";
        }
    }
}
