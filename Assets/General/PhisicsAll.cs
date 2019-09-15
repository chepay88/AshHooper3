using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhisicsAll : MonoBehaviour
{
    //Основная физика персонажей и предметов

    //Чего касаемся
    [HideInInspector]
    public GameObject NPol = null;// Общая переменная, выводные данные того, на чем стоим
    [HideInInspector]
    public GameObject NPol1 = null;//Пол, , тип второй(Лестницы и тд)
    [HideInInspector]
    public GameObject Kray = null;//Край пола
    [HideInInspector]
    public GameObject Kray1 = null;//Край пола1
    [HideInInspector]
    public GameObject NPol2 = null;//Пол, тип первый, просто пол
    [HideInInspector]
    public GameObject VPol = null;//Пол, коснулись головой
    [HideInInspector]
    public GameObject NPereh = null;//Встали на переход
    [HideInInspector]
    public GameObject RPol = null;
    [HideInInspector]
    public GameObject LPol = null;
    [HideInInspector]
    public GameObject RWall = null;//Правым боком каснулись стены
    [HideInInspector]
    public GameObject LWall = null;//Левым боком каснулись стены
    [HideInInspector]
    public GameObject NLestnica = null;//Стоим на лестнице
    [HideInInspector]
    public GameObject NBox = null;//Стоим на ящике
    [HideInInspector]
    public GameObject Dialog = null;//Объект с диалогом 
    [HideInInspector]
    public Vector3 LostPos;
    [HideInInspector]
    public Vector2 _velocity;//Скорость на сохранение
    [HideInInspector]
    public float LayerPers;//Слой на котором вообщем стоит персонаж


    //Переменные
    [HideInInspector]
    public int Perehod = 0;//Переход с одного на другой тип(0- обычный пол, 1 - лестница
    [HideInInspector]
    public bool _direction = false;
    [HideInInspector]
    public bool _freeFall = false;//Свободный полет включен
    [HideInInspector]
    public bool _takeOfftheGround;//Показывем, что мы намеренно оторвались от земли
    GameObject PersonS;
    Rigidbody2D RG2;
    ParametrPersons PP;
    void Start()
    {
        PersonS = transform.GetChild(0).gameObject;
        RG2 = PersonS.GetComponent<Rigidbody2D>();
        PP = GetComponent<ParametrPersons>();
    }
    public void LAyerDetermine()//Определяем слой на котором стоит, в данный момент персонаж, так, сравнение
    {

    }
    public void TakeOfftheGround()//Отрываемся от земли
    {
        _takeOfftheGround = true;
        transform.GetChild(0).GetChild(2).GetChild(0).gameObject.layer = 12;
        this.gameObject.layer = 12;
        LostPos = PersonS.transform.position;
        _velocity = new Vector2(RG2.velocity.x, 0);
    }
    private void FreeFall()//Свободное падение 
    {
        if(_freeFall == true)
        {
            RG2.velocity = new Vector2(RG2.velocity.x, RG2.velocity.y + PP._freeFallSpeed.x*-1);
        }
    }
    private void DetermineSurface()//Определяем, стоит ли персонаж на поверхности(Ну или кто-то еще)
    {
        if(Perehod == 0 && NPereh == null)//Если первый тип перехода
        {
            NPol = NPol2;
        }
        if(Perehod == 1 && NPereh == null)//Второй тип перехода, пока это леснтица
        {
            NPol = NPol1;
        }
        if(NPereh != null)//Если стоим на переходе
        {
            NPol = NPereh;
        }
        if(NPol == null)
        {
            _freeFall = true;
        }
        if(NPol != null)
        {
             StopFreeFall();//Остановка свободного падения
        }
    }
    private void PerehodDetermine()//Включаем переход
    {
        if(NPereh != null)//Если стоим на переходе
        {
            if(NPol2 != null)//Переходим на пол2
            {
                Perehod = 0;
                this.gameObject.layer = 10;
                transform.GetChild(0).GetChild(2).GetChild(0).gameObject.layer = 10;
            }
            if(NPol1 != null)//Переходим на второй тип пол1
            {
                Perehod = 1;
                this.gameObject.layer = 11;
                transform.GetChild(0).GetChild(2).GetChild(0).gameObject.layer = 11;
            }
        }
    }
    private void PullUp()//Подтягиваем объект к физике
    {
        if (_takeOfftheGround != true)
        {
            HelpPullUp(transform.GetChild(0).position.x, transform.GetChild(0).position.y);
        }
        if(_takeOfftheGround == true)
        {
            HelpPullUp(transform.GetChild(0).position.x, LostPos.y);
        }
    }
    void NapravPers()//Напрвление героя
    {
        if (tag == "Hero")
        {
            Vector3 XY = transform.eulerAngles;
            if (transform.position.x < Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
            {
                _direction = true;
                transform.eulerAngles = new Vector3(XY.x, 0, XY.z);
            }
            else
            {
                _direction = false;
                transform.eulerAngles = new Vector3(XY.x, 180, XY.z);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        FreeFall();//Скорость свободного падения
        PerehodDetermine();//Постоянно определяем переход
        DetermineSurface();//Постоянно определяем на чем стоим
        PullUp();
        NapravPers();
    }
    //Вспомагательные методы и функции
    private void StopFreeFall()//Останавливаем свободное падение
    {
        if(_freeFall == true)
        {
            if (transform.GetChild(0).GetChild(2).GetChild(0).gameObject.layer == 12)
            {
                if (PersonS.transform.position.y <= LostPos.y)
                {
                    _freeFall = false;
                    RG2.velocity = new Vector2(0, 0);
                    transform.GetChild(0).GetChild(2).GetChild(0).gameObject.layer = 10;
                    this.gameObject.layer = 10;
                    PersonS.transform.position = new Vector3(transform.position.x, LostPos.y, transform.position.z);
                    _takeOfftheGround = false;
                }
                
            }
        }
    }
    private void HelpPullUp(float a, float b)//Вспомогательная функция для подтягивания(координаты на которые смещаем)
    {
        Vector2 e = transform.GetChild(0).position;
        transform.position = new Vector2(a,b);
            //transform.GetChild(0).position;
        transform.GetChild(0).position = e;
    }

}
