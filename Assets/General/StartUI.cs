using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(Screen.width + "ll" + Screen.height);
       // Debug.Log(transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta);
        transform.GetChild(0).position = new Vector2(150,60);
        transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(250, 100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
