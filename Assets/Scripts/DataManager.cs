using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string highScoreText;
    public int points;

    public void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScoreText();
    }

    [System.Serializable]
    class SaveData
    {
        public string highScoreText;
        public int points;
    }

    public void SaveHighScoreText()
    {
        SaveData data = new SaveData();
        data.highScoreText = highScoreText;
        data.points = points;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScoreText()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScoreText = data.highScoreText;
            points = data.points;
        }
    }
}
