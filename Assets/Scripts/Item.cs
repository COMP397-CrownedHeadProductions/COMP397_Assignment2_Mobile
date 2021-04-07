using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public string desc;
    public string type;
    public Sprite thumbnail;
    public bool isPickedUp;

    [HideInInspector]
    public bool isUsed;

    [HideInInspector]
    public bool isPlayerObject;

    [HideInInspector]
    public GameObject Heart;

    [HideInInspector]
    public GameObject itemManager;

    public bool playerItem;

    public void Start()
    {
        itemManager = GameObject.FindWithTag("ItemManager");

        if (!isPlayerObject)
        {
            int allItems = itemManager.transform.childCount;
            for (int i = 0; i < allItems; i++)
            {
                if (itemManager.transform.GetChild(i).gameObject.GetComponent<Item>().ID == ID)
                {
                    Heart = itemManager.transform.GetChild(i).gameObject;
                }
            }
        }
    }
    public void Update()
    {
        if (isUsed)
        {
            if (Input.GetKeyDown(KeyCode.G))
                isUsed = false;

            if (isUsed == false)
                this.gameObject.SetActive(false);


        }
    }
    public void ItemUsage()
    {
        if(type == "Item")
        {
            Heart.SetActive(true);
            Heart.GetComponent<Item>().isUsed = true;
        }
    }
}
