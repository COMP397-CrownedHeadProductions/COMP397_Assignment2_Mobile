using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Source File: ProjectObjectPool.cs
 * Editors: Timothy Garcia
 * Student Number: 300898955
 * Date Modified: 04-05-2021
 * Program: 3109 - Game-Programming(Optional Co-op)
 * 
 *             Beta(Mobile Conversion) continued		2021.04.05
 * - Object Pooling Optimization Pattern implemented to Range Enemy projectiles
 *
 */

public class ProjectileObjectPool : MonoBehaviour
{
    public static ProjectileObjectPool SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int poolAmount;

    // Start is called before the first frame update
    void Awake()
    {
        SharedInstance = this;
    }

    // Update is called once per frame
    void Start()
    {
        pooledObjects = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < poolAmount; i++)
        {
            tmp = Instantiate(objectToPool);
            tmp.SetActive(false);
            pooledObjects.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < poolAmount; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
