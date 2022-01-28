using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{

    public GameObject highScore;
    public Text highScoreText;

    private void Start()
    {
        if (DataManager.Instance != null)
        {
            SetHighScore(DataManager.Instance.highScoreText, DataManager.Instance.points);
            highScore.SetActive(true);
        }
    }
    // Start is called before the first frame update
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif 
    }

    public void SetHighScore(string name, int points)
    {
        highScoreText.text = $"High Score: " + name + "..." + points;
    }
}
