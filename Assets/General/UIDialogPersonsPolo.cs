using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDialogPersonsPolo : MonoBehaviour
{
    int i1 = 1;
    float _timer;//Первый таймер, для включения
    float _timer1;//Второй таймер, для выключения
    bool _timerStart = false;//Включение первого таймера
    bool _timerStart1 = false;//Включение второго таймера
    string _personNameD;//Имя персонажа
    string _textDD;//Сам текст
    Texture _texturePersonD;//Текстура персонажа
    // Start is called before the first frame update
    void Start()
    {
        StartUIA();
    }
    void StartUIA()
    {
        float a = Screen.width / 20;
        int _sF = Mathf.RoundToInt(a / 3);
        if (_sF > 25)
        {
            _sF = 25;
        }
        float b = a + a / 5;
        GameObject UIY = transform.GetChild(0).gameObject;
        UIY.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, b + 10);
        UIY.transform.position = new Vector2(Screen.width / 2, Screen.height - b);
        UIY = transform.GetChild(1).gameObject;
        UIY.GetComponent<RectTransform>().sizeDelta = new Vector2(a, b);
        UIY.transform.position = new Vector2(a,Screen.height - b);
        UIY = transform.GetChild(2).gameObject;
        UIY.transform.position = new Vector2(a*4, Screen.height - b);
        UIY.GetComponent<Text>().fontSize = _sF;
        UIY = transform.GetChild(3).gameObject;
        UIY.transform.position = new Vector2(a * 4, Screen.height - b + Screen.height/18);
        UIY.GetComponent<Text>().fontSize = _sF + 5;
       
        
    }//Установка размеров окна при старте
    public void TextDialogMass()
    {

    }
    public void TextDialog(string _personName, string _textD, Texture _texturePerson)//имя персонажа, текст диалога, текстура персонажа
    {
        EndDialog();
        _timerStart = true;
        _personNameD = _personName;
        _texturePersonD = _texturePerson;
        _textDD = _textD;
    }
    void DialogRun()
    {
        if (_timerStart == true)
        {
            if (_timer > 0.1f)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                GameObject UIY = transform.GetChild(1).gameObject;
                UIY.gameObject.SetActive(true);
                UIY.GetComponent<RawImage>().texture = _texturePersonD;
                UIY = transform.GetChild(2).gameObject;
                UIY.SetActive(true);
                UIY = transform.GetChild(3).gameObject;
                UIY.SetActive(true);
                UIY.GetComponent<Text>().text = _personNameD;
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
        if (_timer1 > 1 && transform.GetChild(2).gameObject.activeSelf == true)
        {
            StartCoroutine("CloseDialog");
        }
    }
    IEnumerator CloseDialog()
    {
        yield return new WaitForSeconds(1f);
        Color _Fq = transform.GetChild(0).gameObject.GetComponent<RawImage>().color;
        Color _F = transform.GetChild(1).gameObject.GetComponent<RawImage>().color;
        Color _Ff = transform.GetChild(2).gameObject.GetComponent<Text>().color;
        Color _Fqf = transform.GetChild(3).gameObject.GetComponent<Text>().color;
        float _a = _F.a - 0.01f;
        if (_a < 0)
        {
            _a = 0;
        }
        transform.GetChild(0).gameObject.GetComponent<RawImage>().color = new Color(_Fq.r, _Fq.g, _Fq.b, _a);
        transform.GetChild(1).gameObject.GetComponent<RawImage>().color = new Color(_F.r, _F.g, _F.b, _a);
        transform.GetChild(2).gameObject.GetComponent<Text>().color = new Color(_Ff.r, _Ff.g, _Ff.b, _a);
        transform.GetChild(3).gameObject.GetComponent<Text>().color = new Color(_Fqf.r, _Fqf.g, _Fqf.b, _a);
        if (transform.GetChild(1).gameObject.GetComponent<RawImage>().color.a == 0)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
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
            if (i1 != transform.GetChild(2).gameObject.GetComponent<Text>().text.Length && i1 < _textDD.Length+1)
            {
                transform.GetChild(2).gameObject.GetComponent<Text>().text = _textDD.Substring(0, i1);
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
        if(_timerStart == false && transform.GetChild(2).gameObject.GetComponent<Text>().text.Length > 0)
        {
            Color _Fq = transform.GetChild(0).gameObject.GetComponent<RawImage>().color;
            Color _F = transform.GetChild(1).gameObject.GetComponent<RawImage>().color;
            Color _Ff = transform.GetChild(2).gameObject.GetComponent<Text>().color;
            Color _Fqf = transform.GetChild(3).gameObject.GetComponent<Text>().color;
            transform.GetChild(0).gameObject.GetComponent<RawImage>().color = new Color(_Fq.r, _Fq.g, _Fq.b, 1);
            transform.GetChild(1).gameObject.GetComponent<RawImage>().color = new Color(_F.r, _F.g, _F.b, 1);
            transform.GetChild(2).gameObject.GetComponent<Text>().color = new Color(_Ff.r, _Ff.g, _Ff.b, 1);
            transform.GetChild(3).gameObject.GetComponent<Text>().color = new Color(_Fqf.r, _Fqf.g, _Fqf.b, 1);
            _timer = 0;
            _timer1 = 0;
            _timerStart1 = false;
            i1 = 0;
            transform.GetChild(2).gameObject.GetComponent<Text>().text = "";
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
