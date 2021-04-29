using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Script
{
    public class Word
    {
        private string baseWord;
        private string[] tradList;

        public Word(string[] _list)
        {
            baseWord = _list[0];
            tradList = _list.Skip(1).ToArray();
        }

        public bool IsTraduction(string _word)
        {
            foreach (var trad in tradList)
            {
                if (trad.Trim().Equals(_word))
                    return true;
            }

            return false;
        }
        
        public string BaseWord => baseWord;
        public string MainTrad => tradList[0];
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
                wordList.Add(new Word(wordCorrespondanceSplited));
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