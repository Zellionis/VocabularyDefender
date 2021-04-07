using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class Word
    {
        private string english;
        private string french;

        public Word(string _english, string _french)
        {
            english = _english;
            french = _french;
        }

        public string English => english;
        public string French => french;
    }
    public class Words
    {
        private List<Word> wordList = new List<Word>();

        public Words(string _wordsList)
        {
            string[] wordCorrespondanceList = _wordsList.Split('\n');

            foreach (var wordCorrespondance in wordCorrespondanceList)
            {
                if(wordCorrespondance.Length == 0)
                    continue;
                
                string[] wordCorrespondanceSplited = wordCorrespondance.Split(';');
                wordList.Add(new Word(wordCorrespondanceSplited[0], wordCorrespondanceSplited[1]));
            }
        }

        public Word GetRandomWord()
        {
            return wordList[UnityEngine.Random.Range(0,Size())];
        }
        
        public int Size()
        {
            return wordList.Count;
        }
    }
}