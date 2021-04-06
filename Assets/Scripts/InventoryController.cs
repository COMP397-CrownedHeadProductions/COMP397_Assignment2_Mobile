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

    // Start is called before the first frame update
    void Start()
    {
        pausable = FindObjectOfType<Pauseable>();
        playerCamera = FindObjectOfType<CameraController>();
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = offScreenPos;
        timer = 0.0f;
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
}
