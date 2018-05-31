using System;

namespace MVideoQuest.Model
{
    public enum QuestStatus
    {
        NOT_AVAILIBLE,
        AVAILIBLE,
        FINISHED
    }

    [Serializable]
    public class Quest
    {
        public string id;
        public QuestStatus status;
        public int score;
    }
}
