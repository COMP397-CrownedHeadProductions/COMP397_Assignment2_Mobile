using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyItemController : MonoBehaviour
{
    public KeyManager keyItem;
    public AudioSource keyAudioSource;

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
            keyAudioSource.Play();
            Destroy(gameObject, 1f);
            //gameObject.SetActive(false);
        }
    }
}
