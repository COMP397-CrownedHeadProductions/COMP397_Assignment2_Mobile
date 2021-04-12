using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManagerScript : MonoBehaviour
{
    public QuestControllerScript questController;
    public PlayerController player;
    public GameObject questWindow;
    public Text enemyCount;
    public Text itemCount;

    void Start()
    {
        questWindow = GetComponent<QuestManagerScript>().gameObject;
    }
    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
    }

    public void CloseQuestWindow()
    {
        questWindow.SetActive(false);
    }
}
