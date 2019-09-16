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
        TwoUIBar();   
    }
    void TwoUIBar()//Ставим бар на место
    {
        float a = Screen.width;
        a = a - a / 6;
        transform.parent.GetChild(2).GetChild(0).position = new Vector2(a, 50);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
