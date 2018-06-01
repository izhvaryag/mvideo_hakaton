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

        public Quest(){}
        public Quest (string id, QuestStatus status, int score)
        {
            this.id = id;
            this.status = status;
            this.score = score;
        }
    }
}
