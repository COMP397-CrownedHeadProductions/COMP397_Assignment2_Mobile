using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Source File: QuestScript.cs
 * Editors: Timothy Garcia
 * Student Number: 300898955
 * Date Modified: 04-16-2021
 * Program: 3109 - Game-Programming(Optional Co-op)
 * 
 * --------------------Revision History--------------------
 *             Final Release	2021.04.16
 * - Implemented quest system for all enemies destroyed
*/

[System.Serializable]
public class QuestControllerScript
{
    public string questTitle;
    public string questDescription;
    public int questReward;
    public bool isActive;

    public QuestTypeScript questTypeScript;
}
