using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string UserName;
    public string BestUserName;
    public int BestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestProfile();
    }

    public string GetBestProfile()
    {
        return "Best Score : " + BestUserName + " : " + BestScore.ToString();
    }


    [System.Serializable]
    class SaveData
    {
        public string BestUserName;
        public int BestScore;
    }

    public void SaveBestProfile()
    {
        SaveData data = new SaveData();
        data.BestUserName = BestUserName;
        data.BestScore = BestScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadBestProfile()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            BestUserName = data.BestUserName;
            BestScore = data.BestScore;
		}
    }
}

// ensure class initializer is called whenever scripts recompile
[InitializeOnLoadAttribute]
public static class PlayModeStateChangedExample
{
    // register an event handler when the class is initialized
    static PlayModeStateChangedExample()
    {
        EditorApplication.playModeStateChanged += LogPlayModeState;
    }

    private static void LogPlayModeState(PlayModeStateChange state)
    {
        Debug.Log(state);
        DataManager.Instance.SaveBestProfile();
    }
}