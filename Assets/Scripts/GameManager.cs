using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get 
        {
            // return game manager if not null
            if (_instance) return _instance;
            
            // create new game manager instance
            var gameObject = new GameObject("Game Manager");
            _instance = gameObject.AddComponent<GameManager>();
            Debug.Log("Game Manager Initialised");
            return _instance;
        }
    }
    public InputHandler InputHandler { get; private set; }

    private void Awake()
    {
        InputHandler = gameObject.AddComponent<InputHandler>();
    }
}
