using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDialogPersonsPolo : MonoBehaviour
{
    int i1 = 1;
    float _timer;
    float _timer1;
    bool _timerStart = false;
    bool _timerStart1 = false;
    string _textDD;
    // Start is called before the first frame update
    void Start()
    {
        StartUIA();
    }
    void StartUIA()
    {
        float a = Screen.width / 20;
        // float b = Screen.height - Screen.height / 6;
        float b = a + a / 5;
        transform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(a, b);
        transform.GetChild(0).position = new Vector2(a,Screen.height - b);
        transform.GetChild(1).position = new Vector2(a*4, Screen.height - b);
        int _sF = Mathf.RoundToInt(a / 3);
        if(_sF > 25)
        {
            _sF = 25;
        }
        transform.GetChild(1).gameObject.GetComponent<Text>().fontSize =_sF;
    }
    public void TextDialog(string _textD)//текст диалога
    {
        EndDialog();
        transform.GetChild(1).gameObject.GetComponent<Text>().text = "";
        _timerStart = true;
      
        _textDD = _textD;
    }
    void DialogRun()
    {
        if (_timerStart == true)
        {
            if (_timer > 0.1f)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(true);
                StartCoroutine("DialogCorutine");
            }
        }
       
    }
    void TimerRun()
    {
        if (_timerStart == true)
        {

            _timer = _timer + Time.deltaTime;
        }
    }
    void TimerRun1()
    {
        if (_timerStart1 == true)
        {
            _timer1 = _timer1 + Time.deltaTime;
        }
        if (_timer1 > 1 && transform.GetChild(1).gameObject.activeSelf == true)
        {
            StartCoroutine("CloseDialog");
        }
    }
    IEnumerator CloseDialog()
    {
        yield return new WaitForSeconds(1f);
        Color _F = transform.GetChild(0).gameObject.GetComponent<RawImage>().color;
        Color _Ff = transform.GetChild(1).gameObject.GetComponent<Text>().color;
        float _a = _F.a - 0.01f;
        if (_a < 0)
        {
            _a = 0;
        }
        transform.GetChild(0).gameObject.GetComponent<RawImage>().color = new Color(_F.r, _F.g, _F.b, _a);
        transform.GetChild(1).gameObject.GetComponent<Text>().color = new Color(_Ff.r, _Ff.g, _Ff.b, _a);
        if (transform.GetChild(0).gameObject.GetComponent<RawImage>().color.a == 0)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            _timerStart1 = false;
            _timer1 = 0;
            StopAllCoroutines();
        }
    }
    IEnumerator DialogCorutine()
    {    
        while (i1 != _textDD.Length-1)
        {
            yield return new WaitForSeconds(1f);
            if (i1 != transform.GetChild(1).gameObject.GetComponent<Text>().text.Length && i1 < _textDD.Length+1)
            {
                transform.GetChild(1).gameObject.GetComponent<Text>().text = _textDD.Substring(0, i1);
            }
            i1 = i1 + 1;
            if (i1 == _textDD.Length+1)
            {
                _timerStart = false;
                _timerStart1 = true;
                StopAllCoroutines();
                break;
            }
        }
    }
    void EndDialog()
    {
        if(_timerStart == false && transform.GetChild(1).gameObject.GetComponent<Text>().text.Length > 0)
        {
            Color _F = transform.GetChild(0).gameObject.GetComponent<RawImage>().color;
            Color _Ff = transform.GetChild(1).gameObject.GetComponent<Text>().color;
            transform.GetChild(0).gameObject.GetComponent<RawImage>().color = new Color(_F.r, _F.g, _F.b, 1);
            transform.GetChild(1).gameObject.GetComponent<Text>().color = new Color(_Ff.r, _Ff.g, _Ff.b, 1);
            _timer = 0;
            _timer1 = 0;
            _timerStart1 = false;
            i1 = 0;
        }
    }
    // Update is called once per frame
    void Update()
    {
        TimerRun();
        TimerRun1();
        DialogRun();
       // CloseDialog();
    }
}
