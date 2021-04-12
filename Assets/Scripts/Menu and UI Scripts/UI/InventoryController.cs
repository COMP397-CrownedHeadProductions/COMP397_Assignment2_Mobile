using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [Header("Inventory Canvas")]
    public RectTransform rectTransform;
    public Vector2 offScreenPos;
    public Vector2 onScreenPos;
    [Range(0.1f, 10.0f)]
    public float speed = 1.0f;
    public float timer = 0.0f;
    public bool isOnScreen = false;
    public CameraController playerCamera;
    public Pauseable pausable;

    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;

    public GameObject slotHolder;
    // Start is called before the first frame update
    void Start()
    {
        pausable = FindObjectOfType<Pauseable>();
        playerCamera = FindObjectOfType<CameraController>();
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = offScreenPos;
        timer = 0.0f;

        allSlots = 40;
        slot = new GameObject[allSlots];
        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;

            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().isEmpty = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Inventory Menu Function
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOnScreen = !isOnScreen;
            timer = 0.0f;

            if (isOnScreen)
            {
                Cursor.lockState = CursorLockMode.None;
                playerCamera.enabled = false;
            }
            else
            {

                Cursor.lockState = CursorLockMode.Locked;
                playerCamera.enabled = true;
            }
        }
        if (isOnScreen)
        {
            MoveControlPanelDown();
        }
        else
        {
            MoveControlPanelUp();
        }
    }

    void ToggleInventory()
    {
        isOnScreen = !isOnScreen;
        timer = 0.0f;
        if (isOnScreen)
        {
            //Cursor.lockState = CursorLockMode.None;
            playerCamera.enabled = false;
        }
        else
        {

            //Cursor.lockState = CursorLockMode.Locked;
            playerCamera.enabled = true;
        }
    }

    public void OnInventoryButtonPressed()
    {
        ToggleInventory();
    }

    private void MoveControlPanelDown()
    {
        rectTransform.anchoredPosition = Vector2.Lerp(offScreenPos, onScreenPos, timer);
        if (timer < 1.0f)
        {
            timer += Time.deltaTime * speed;
        }
    }

    private void MoveControlPanelUp()
    {
        rectTransform.anchoredPosition = Vector2.Lerp(onScreenPos, offScreenPos, timer);
        if (timer < 1.0f)
        {
            timer += Time.deltaTime * speed;
        }

        if (pausable.isGamePaused)
        {
            pausable.TogglePause();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Heart")
        {
            GameObject itemPickedUp = other.gameObject;
            Item item = itemPickedUp.GetComponent<Item>();
            AddItem(itemPickedUp, item.ID, item.type, item.desc, item.thumbnail );
        }
    }
    void AddItem(GameObject itemObject, int id, string type, string desc, Sprite icon)
    {
        for (int i = 0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().isEmpty)
            {
                itemObject.GetComponent<Item>().isPickedUp = true;

                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().icon = icon;
                slot[i].GetComponent<Slot>().type = type;
                slot[i].GetComponent<Slot>().ID = id;
                slot[i].GetComponent<Slot>().desc = desc;

                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);

                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().isEmpty = false;
            }
            return;
        }
    }
}
