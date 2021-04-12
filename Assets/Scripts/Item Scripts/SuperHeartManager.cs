using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperHeartManager : MonoBehaviour
{
    public Text superHeartText;
    public int superHeartCount;
    public int superHeartTotal;
    public HeartDropController[] superHeart; 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        superHeartText.text = superHeartCount.ToString() + "/" + superHeartTotal.ToString();
    }
}
