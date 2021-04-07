using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDisplayer : MonoBehaviour
{
    List<TMP_Text>     words    = new List<TMP_Text>();
    List<Vector2>  wordsPos = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (TMP_Text T in GetComponentsInChildren<TMP_Text>())
        {
            words.Add(T);
            wordsPos.Add(T.rectTransform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            if (!words[i].rectTransform.position.Equals(wordsPos[i]))
            {
                words[i].rectTransform.position = new Vector3(
                Mathf.Lerp(words[i].rectTransform.position.x, wordsPos[i].x, 0.01f),
                Mathf.Lerp(words[i].rectTransform.position.y, wordsPos[i].y, 0.01f), 0);
            }

            if (!words[i].transform.localScale.Equals(Vector3.one))
            {
                words[i].transform.localScale =
                new Vector3(Mathf.Lerp(words[i].transform.localScale.x, 1f, 0.01f), Mathf.Lerp(words[i].transform.localScale.y, 1f, 0.01f), 1);
            }
        }
    }

    public void NextWord(string newWord)
    {
        words[3].rectTransform.position = words[2].rectTransform.position;
        words[3].text                   = words[2].text;
        words[3].transform.localScale   = words[2].transform.localScale / 2;

        words[2].rectTransform.position = words[1].rectTransform.position;
        words[2].text                   = words[1].text;
        words[2].transform.localScale   = words[1].transform.localScale;

        words[1].rectTransform.position = words[0].rectTransform.position;
        words[1].text                   = words[0].text;
        words[1].transform.localScale   = words[0].transform.localScale;

        words[0].rectTransform.position += new Vector3(0, 20, 0);
        words[0].text                   = newWord;
        words[0].transform.localScale   = new Vector3(0f, 0f, 1);
    }
}
