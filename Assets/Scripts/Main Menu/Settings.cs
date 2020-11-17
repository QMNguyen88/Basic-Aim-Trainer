using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public bool isBack;
    public bool isDifficultyDecrement;
    public bool isDifficultyIncrement;
    public int difficultyLevel;

    private readonly string[] difficultyLevels = {"Easy", "Medium", "Hard"};

    void Start()
    {
        TextMesh diificultyTextMesh = GameObject.Find("DifficultySelection").GetComponent<TextMesh>();
        diificultyTextMesh.text = difficultyLevels.GetValue(GlobalGameObject.Instance.difficultyLevel).ToString();
    }

    // Update is called once per framedsa
    void OnMouseUp()
    {
        if (isBack)
        {
            SceneManager.LoadScene(0);
        }
    }

    public void DecreaseDifficulty()
    {
        if (GlobalGameObject.Instance.difficultyLevel > 0)
        {
            GlobalGameObject.Instance.difficultyLevel--;
            TextMesh diificultyTextMesh = GameObject.Find("DifficultySelection").GetComponent<TextMesh>();
            diificultyTextMesh.text = difficultyLevels.GetValue(GlobalGameObject.Instance.difficultyLevel).ToString();
        }
    }

    public void IncreaseDifficulty()
    {
        if (GlobalGameObject.Instance.difficultyLevel < 2)
        {
            GlobalGameObject.Instance.difficultyLevel++;
            TextMesh diificultyTextMesh = GameObject.Find("DifficultySelection").GetComponent<TextMesh>();
            diificultyTextMesh.text = difficultyLevels.GetValue(GlobalGameObject.Instance.difficultyLevel).ToString();
        }
    }
}
