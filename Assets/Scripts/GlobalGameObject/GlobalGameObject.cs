using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameObject : MonoBehaviour
{
    public static GlobalGameObject Instance;
    public int difficultyLevel = 1;

    public const int DIFFICULTY_EASY = 0;
    public const int DIFFICULTY_MEDIUM = 1;
    public const int DIFFICULTY_HARD = 2;

    public void Awake()
    {
        if(Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if( Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
