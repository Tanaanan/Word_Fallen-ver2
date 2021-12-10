using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{

    public bool test = true;
    
    public GameObject wordPrefab;
    public Transform wordCanvas;

    public WordDisplay SpawnWord()
    {
        
        //Vector3 randomPosition = new Vector3(Random.Range(-8f, 9f), 9f);

        Vector3 randomPosition = new Vector3(2f, 6f, 9f);


        GameObject wordObj = Instantiate(wordPrefab,randomPosition,Quaternion.identity,wordCanvas);
        WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();

        return wordDisplay;
    }
}
