using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public GameObject item;
    public int ID;
    public string desc;
    public string type;
    public bool isEmpty;

    public Transform slotGO;
    public Sprite icon;

    private void Start()
    {
        slotGO = transform.GetChild(0);
    }
    public void UpdateSlot()
    {
        slotGO.GetComponent<Image>().sprite = icon;
    }
    public void UseItem()
    {

    }
}
