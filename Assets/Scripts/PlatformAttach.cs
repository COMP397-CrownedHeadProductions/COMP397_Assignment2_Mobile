using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    public GameObject player;
    public GameObject pivot;
    public GameObject mainCamera;

    void Start()
    {
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player)
        {
            player.transform.parent = transform;
            pivot.transform.parent = transform;
            mainCamera.transform.parent = transform;
        }       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            player.transform.parent = null;
            pivot.transform.parent = null;
            mainCamera.transform.parent = null;
        }        
    }
}
