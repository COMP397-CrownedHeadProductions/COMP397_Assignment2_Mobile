using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneData", menuName = "Data/SceneData")]
[System.Serializable]
public class SceneDataSO : ScriptableObject
{
    //player
    [Header("Player Data")]
    public Vector3 playerPosition;
    public Vector3 cameraPosition;
    public Vector3 pivotPosition;
    public Quaternion playerRotation;
    public Quaternion cameraRotation;
    public int playerHealth;
    
    [Header("Enemy Data")]
    public Vector3 chaseEnemPos;
    public Vector3 rangeEnemPos;
    public Quaternion chaseEnemRot;
    public Quaternion rangeEnemRot;
    public float chaseEnemHealth;
    public float rangeEnemHealth;
}
