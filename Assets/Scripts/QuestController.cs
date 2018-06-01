using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MVideoQuest.Model;

public class QuestController : MonoBehaviour {

    public string id;



    public GameObject closePrefab;
    public GameObject finishPrefab;
    public GameObject questPrefab;

    private QuestManager qm;
    private Dictionary<QuestStatus, GameObject> prefabs = new Dictionary<QuestStatus, GameObject>();
    private GameObject clone = null;

    private void Start()
    {
        qm = QuestManager.Instance;
        prefabs.Add(QuestStatus.AVAILIBLE, questPrefab);
        prefabs.Add(QuestStatus.NOT_AVAILIBLE, closePrefab);
        prefabs.Add(QuestStatus.FINISHED, finishPrefab);
    }

    public void Load()
    {
        if (clone != null)
            return;
        clone = Instantiate(prefabs[qm.quests.quests[id].status], transform.position, transform.rotation, null);
        clone.transform.SetParent(transform);
    }

    public void Destroy()
    {
        Destroy(clone.gameObject);
        clone = null;
    }

}
