using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifficultyChanger : MonoBehaviour
{
    public bool isDifficultyDecrement;
    public bool isDifficultyIncrement;

    // Update is called once per framedsa
    void OnMouseUp()
    {

        if (isDifficultyDecrement)
        {
            Settings script = GameObject.Find("MenuText").GetComponent<Settings>();
            script.DecreaseDifficulty();
        }

        if (isDifficultyIncrement)
        {
            Settings script = GameObject.Find("MenuText").GetComponent<Settings>();
            script.IncreaseDifficulty();
        }
    }
}
