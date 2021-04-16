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
        //Make sure the item is picked up
        if (isPickedUp)
        {
            //Set the isUsed to false so that it can be used.
            if (!isUsed)
            {
                //Make sure the game is paused to use the heart
                if (GetComponentInParent<PauseController>().isPaused && Input.GetKeyDown(KeyCode.G))
                {
                    //Add health
                    GetComponentInParent<PlayerController>().currentHealth = 100;
                    //deactivate the heart on player's hand and in the inventory.
                    gameObject.SetActive(false);
                    //set isUsed to true
                    isUsed = true;
                }
            }
        }
    }
    //put a heart on the player's hand and press g to use
    public void OnButtonPressed()
    {
        if (type == "Heart")
        {

            Heart.SetActive(true);

            Heart.GetComponent<Item>().isUsed = false;
        }
    }
}
