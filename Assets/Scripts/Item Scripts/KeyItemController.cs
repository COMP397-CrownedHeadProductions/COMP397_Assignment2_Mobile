using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Source File: KeyManager.cs
 * Editors: Timothy Garcia
 * Student Number: 300898955
 * Date Modified: 04-12-2021
 * Program: 3109 - Game-Programming(Optional Co-op)
 * 
 * --------------------Revision History--------------------
 * 
 *             Final Release - 2021.04.12
 * - Implemented function and UI for collecting all keys quest
 * - Added audio for key item pickup
 */

public class KeyItemController : MonoBehaviour
{
    public KeyManager keyItem;
    public AudioSource keyAudioSource;
    public float destroyDelay;

    // Start is called before the first frame update
    void Start()
    {
        keyItem = GameObject.Find("Keys").GetComponent<KeyManager>();
        keyAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            keyItem.keyCount++;
            //keyAudioSource.Play();
            Destroy(gameObject);

            //gameObject.SetActive(false);
        }
    }
}
