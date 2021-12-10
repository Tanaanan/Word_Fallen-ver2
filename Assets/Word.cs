using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word 
{
    public string word;
    private int typeIndex;

    WordDisplay display;

    WordManager Manager;

    public Word (string _word, WordDisplay _display)
    {
        word = _word;
        typeIndex = 0;

        display = _display;
        display.SetWord(word);
    }

    public int Lenght() //Make int word.Lenght used in WordManager
    {
        int LenghtWord = word.Length; 
        return LenghtWord;
    }

    public char GetNextLetter()
    {
        return word[typeIndex];
    }

    public void TypeLetter()
    {
        typeIndex++;
        display.RemoveLetter();   
    }
    public bool WordTyped()
    {
        bool wordTyped = (typeIndex >= word.Length);
        if(wordTyped)
        {
            // Remove the word on screen
            display.RemoveWord();
        }

        return wordTyped;
    }
}
