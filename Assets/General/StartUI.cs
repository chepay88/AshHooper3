using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartUIA();
    }
    void StartUIA()
    {
        float a = Screen.width / 6;
        transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(a, a/3);
        transform.GetChild(0).position = new Vector2(a - a/4, a/6 + a/12);
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
