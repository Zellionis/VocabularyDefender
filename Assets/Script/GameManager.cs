using System;
using Script;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextAsset wordsFile = null;
    [SerializeField] private TMP_InputField inputField = null;
    [SerializeField] private TextDisplayer textDisplayer = null;

    private Words words = null; // Store list of word
    
    private Word thirdWord = null;
    private Word secondWord = null;
    private Word lastWord = null;
    private Word currentWord = null; // Store current word
    
    // Start is called before the first frame update
    void Start()
    {
        words = new Words(wordsFile.text);
        
        thirdWord = words.GetRandomWord();
        secondWord = words.GetRandomWord();
        lastWord = words.GetRandomWord();
        currentWord = words.GetRandomWord();
        
        textDisplayer.NextWord(currentWord.English);
        textDisplayer.NextWord(lastWord.English);
        textDisplayer.NextWord(secondWord.English);
        textDisplayer.NextWord(thirdWord.English);
        
        inputField.Select();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inputField.isFocused)
            inputField.Select();

        //currentWordDisplay.SetText(currentWord.English);
        if (Input.GetButtonDown("Submit"))
        {
            if (currentWord.French.Trim().Equals(inputField.text.Trim()))
            {
                Debug.Log("True !");
            }
            else
            {
                Debug.Log("False !");
            }
            
            currentWord = lastWord;
            lastWord = secondWord;
            secondWord = thirdWord;
            thirdWord = words.GetRandomWord();
            
            textDisplayer.NextWord(thirdWord.English);
            
            inputField.text = "";
        }
    }
}
