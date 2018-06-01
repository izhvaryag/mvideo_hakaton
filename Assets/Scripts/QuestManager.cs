using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using MVideoQuest.Model;

public class QuestManager : MonoBehaviour {

    #region Singleton
    private static QuestManager _instance;
    public static QuestManager Instance { get { return _instance;} }
    private void Awake()
    {
        if (_instance != null)
            Destroy(this);
        _instance = this;
        DontDestroyOnLoad(this);
    }
    #endregion

    #region PUBLIC VARIABLES

    public string fileName = "questInfo.json";
    public Quests quests = new Quests();

    #endregion

    #region PRIVATE VARIABLES

    private string path;

    #endregion

    private void Start()
    {
        path = Path.Combine(Application.streamingAssetsPath, fileName);
        QuestsFromFile(path);
    }

    public void QuestsFromFile(string path)
    {
        using (StreamReader stream = new StreamReader(path))
        {
            var json = stream.ReadToEnd();
            quests = JsonUtility.FromJson<Quests>(json);
        }
    }

    public void QuestsToFile()
    {
        using (StreamWriter stream = new StreamWriter(path))
        {
            var json = JsonUtility.ToJson(quests);
            stream.Write(json);
        }
    }

    

}
