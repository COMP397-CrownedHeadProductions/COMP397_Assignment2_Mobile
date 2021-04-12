using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestTypeScript
{
    public QuestType questType;
    public int currentAmt;
    public int requiredAmt;

    public bool QuestCompleted()
    {
        return (currentAmt >= requiredAmt);
    }

    public void EnemyKilled()
    {
        if (questType == QuestType.KillEnemy)
        currentAmt++;
    }

    public void ItemCollected()
    {
        if(questType == QuestType.CollectItem)
        currentAmt++;
    }
}

public enum QuestType
{
    KillEnemy,
    CollectItem
}
