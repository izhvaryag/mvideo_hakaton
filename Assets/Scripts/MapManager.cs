using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVideoQuest.Model;

public class MapManager : MonoBehaviour {

    #region Singleton
    private static MapManager _instance;
    public static MapManager Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance != null)
            Destroy(_instance);
        _instance = this;
    }
    #endregion

    public QuestInfo[] quests;

    public Sprite disableImg;
    public Sprite enableImg;
    public Sprite finishImg;

    private QuestManager qm;

    private void Start()
    {
        qm = QuestManager.Instance;
        SetAllInfo();
    }

    public void SetAllInfo()
    {
        if (qm.quests == null || qm.quests.quests == null)
        {
            qm.quests = new Quests();
            qm.quests.quests = new Dictionary<string, Quest>();
        }
        foreach (QuestInfo quest in quests)
        {
            if (qm.quests.quests.ContainsKey(quest.id))
                quest.ChangeInfo(qm.quests.quests[quest.id]);
            else
            {
                Quest newQuest = new Quest();
                newQuest.id = quest.id;
                newQuest.status = QuestStatus.NOT_AVAILIBLE;
                newQuest.score = 0;
                qm.quests.quests.Add(newQuest.id, newQuest);
            }
        }
    }

}
