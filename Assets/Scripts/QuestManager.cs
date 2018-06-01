using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Newtonsoft.Json;
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
        if (quests == null)
        {
            DefaultSettings();
        }
    }

    public void QuestsFromFile(string path)
    {
        using (StreamReader stream = new StreamReader(path))
        {
            var json = stream.ReadToEnd();
            //quests = JsonUtility.FromJson<Quests>(json);
            quests = JsonConvert.DeserializeObject<Quests>(json);
        }
    }

    void DefaultSettings()
    {
        quests = new Quests();
        quests.quests = new Dictionary<string, Quest>();
        quests.quests.Add("1", new MVideoQuest.Model.Quest("1", QuestStatus.AVAILIBLE, 0));
        quests.quests.Add("2", new MVideoQuest.Model.Quest("2", QuestStatus.NOT_AVAILIBLE, 0));
        quests.quests.Add("3", new MVideoQuest.Model.Quest("3", QuestStatus.NOT_AVAILIBLE, 0));
        quests.quests.Add("4", new MVideoQuest.Model.Quest("4", QuestStatus.NOT_AVAILIBLE, 0));
        quests.quests.Add("5", new MVideoQuest.Model.Quest("5", QuestStatus.NOT_AVAILIBLE, 0));
        QuestsToFile();
    }

    public void QuestsToFile()
    {
        using (StreamWriter stream = new StreamWriter(path))
        {
            //var json = JsonUtility.ToJson(quests as object);
            var json = JsonConvert.SerializeObject(quests);
            stream.Write(json);
        }
    }

    

}
