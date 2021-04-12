using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyManager : MonoBehaviour
{
    public Text keyText;
    public int keyCount;
    public int keyTotal;
    public GameObject exitStar;

    // Start is called before the first frame update
    void Start()
    {
        exitStar = GameObject.Find("ExitStar").GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        keyText.text = keyCount.ToString() + "/" + keyTotal.ToString();
        if (keyCount >= keyTotal)
        {
            exitStar.SetActive(true);
        }
        //if (keyCount >= 1)
        //{
        //    keyAudioSource.clip = keyPickupAudio;
        //    keyAudioSource.Play();
        //}
    }
}
