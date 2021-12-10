using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WordManager : MonoBehaviour
{
    [SerializeField] public List<Word> words;
    public WordSpawner wordSpawner;

    public WordDisplay WordDisplay;
    public bool hasActiveWord = false;
    public Word activeWord;

    public TimerManager timer;

    public float RemoveWordTime = 5f;

    [SerializeField] private float Timer = 0.0f;

    [SerializeField] public int sum = 0;

    private void Start() 
    {
        AddWord();
    }

    public void AddWord()
    { 
        Word word = new Word(WordGenarator.GetRandomWord(), wordSpawner.SpawnWord());
        Debug.Log(word.word);
        words.Add(word);
    }

    public void TypeLetter(char letter)
    {
        if(hasActiveWord)
        {
            if(activeWord.GetNextLetter() == letter)
            {
                activeWord.TypeLetter();
                sum++;
            }

        }
        else
        {

            if (words[0].GetNextLetter() == letter ) 
            {
                activeWord = words[0];
                hasActiveWord = true;
                words[0].TypeLetter();
            }

        }

        if(hasActiveWord && activeWord.WordTyped()) // CompleteDeleted
        {
            hasActiveWord = false;
            words.Remove(activeWord);
            AddWord(); //Addword
            TimerReset();
            sum = 0;
        }

        

    }

    public void TimerRemove() //Deleted Timeout
    {
        if ( (Timer >= RemoveWordTime) && (hasActiveWord == true) )
        {
            for (int x = 1; x < activeWord.Lenght() - sum; x++) //Loop index 
            {
                activeWord.TypeLetter();
            }
            
            activeWord.WordTyped(); //Remove display on screen
            hasActiveWord = false;
            words.Remove(activeWord);
            AddWord();
            TimerReset();
        }

        else if ( (Timer >= RemoveWordTime) && (hasActiveWord == false) )
        {
            activeWord = words[0]; // Simulate Activeword
            hasActiveWord = true;

            for (int x = 0; x < activeWord.Lenght(); x++) //Loop index 
            {
                activeWord.TypeLetter();
            }
            
            activeWord.WordTyped(); //Remove display on screen
            hasActiveWord = false;
            words.Remove(activeWord);
            AddWord();
            TimerReset();
        }
    }
    
    
    public void TimerReset()
    { 
        Timer = 0;
    }
    private void Update() 
    {
        Timer += Time.deltaTime;
        //Debug.Log(Timer);
        TimerRemove();
    }

}
