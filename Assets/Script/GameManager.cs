using System;
using Script;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextAsset wordsFile = null;
    [SerializeField] private TMP_InputField inputField = null;
    [SerializeField] private TMP_Text currentWordDisplay = null;

    private Words words = null; // Store list of word
    private Word currentWord = null; // Store current word
    
    // Start is called before the first frame update
    void Start()
    {
        words = new Words(wordsFile.text);
        currentWord = words.GetRandomWord();
        inputField.Select();
    }

    // Update is called once per frame
    void Update()
    {
        if (!inputField.isFocused)
            inputField.Select();

        currentWordDisplay.SetText(currentWord.English);
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

            currentWord = words.GetRandomWord();
            inputField.text = "";
        }
    }
}
