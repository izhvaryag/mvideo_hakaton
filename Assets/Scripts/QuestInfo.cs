using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using MVideoQuest.Model;

public class QuestInfo : MonoBehaviour {

    public string id;
    public int score;
    public Text scoreField;
    public Image status;
    public GameObject info;

    public Sprite disable;
    public Sprite enable;
    public Sprite finish;

    private QuestManager qm;


    public void ChangeInfo(Quest quest)
    {
        if (quest.status == QuestStatus.AVAILIBLE)
            SetInfo("", enable, true);
        else if (quest.status == QuestStatus.NOT_AVAILIBLE)
            SetInfo("", disable, false);
        else
            SetInfo(score.ToString(), finish, false);
    }

    private void SetInfo(string score, Sprite image, bool enabled)
    {
        scoreField.text = score;
        status.sprite = image;
        info.SetActive(enabled);
    }

}
