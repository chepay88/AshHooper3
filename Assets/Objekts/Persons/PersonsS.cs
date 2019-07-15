using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonsS : MonoBehaviour
{//Вся информация о персанаже самом. Как редактируемая так и техническая
    //Параметры персонажа
   // [HideInInspector]
    public bool LeftRight;//Куда повеернуты, 1 - право, 0 лево
   // [HideInInspector]
    public bool UpDown;//Положение падаем или прыгаем 0 - падаем, 1 прыгаем
    [HideInInspector]
    public bool LestnicaOn;//Положение на лестнице
    [HideInInspector]
    public float Naprav;
    [HideInInspector]
    public Vector2 XYUP;//Координаты начала прыжка
    [Header("x - максимальный разгон, z - коофициент разгона")]
    public Vector3 Ruzgon;//Разгон x - max, y - текущий, z - коофициент разгона
    [Header("Свободное падение. x - длина падения z - макс скорость w -ускорение ")]
    public Vector4 PadenieSv;//Свободное падение x - длина падения y - скорость z - max скорость w - ускорение
    [Header("Прыжок. x - ускорение по оси x z - скорость набора высоты w - макс высота")]
    public Vector4 JumpIk;//Настройки прыжка x - ускорение по оси x y - текущая высота прыжка z - скорость прыжка w - max высота прыжка
    [Header("Скорость шага")]
    public float speedShag;//Скорость хотьбы
    [HideInInspector]
    float Times = 0;// начало отсчета времени
    [Header("Скорость подъема по лестнице")]
    public float SpeedLestnica;//Скорость подъема или спуска по лестнице


    //public bool Zacep;//Зацеплен ли на стене
    //public Vector2 TimesZacep;//y - время удержания на стене, x - дельта времени
    //public float WallJump;//Дальность прыжка от стены

    //Техническая
    [Space]
    [Header("Техническая информация")]
    public GameObject Gen;//Ссылка на генерал
    GT GTQ;//Ссылка на компонент GT
    Rigidbody2D RG2;
    PersonsControl PeS;
    float NaprL;//Показывает направление на лестнице
    //Чего касаемся
    //[HideInInspector]
    public GameObject NPol = null;//Пол, коснулись ногами
    [HideInInspector]
    public GameObject VPol = null;//Пол, коснулись головой
    [HideInInspector]
    public GameObject RPol = null;
    [HideInInspector]
    public GameObject LPol = null;
    [HideInInspector]
    public GameObject RWall = null;//Правым боком каснулись стены
    [HideInInspector]
    public GameObject LWall = null;//Левым боком каснулись стены
    //[HideInInspector]
    public GameObject NLestnica = null;//Стоим на лестнице
    //[HideInInspector]
    public GameObject NBox = null;//Стоим на ящике
    // Start is called before the first frame update

    void Start()
    {
        GTQ = Gen.GetComponent<GT>();
        RG2 = GetComponent<Rigidbody2D>();
        PeS = Gen.GetComponent<PersonsControl>();
    }

    void PadenieSvob()//Свободное падение(скорость по оси x)
    {
        if (NPol == null && NBox == null && NLestnica == null && UpDown == false)//Если ни чего не касаемся ногами - падаем
        {
            if (PadenieSv.y + PadenieSv.w * Time.deltaTime < PadenieSv.z)
            {
                PadenieSv.y = PadenieSv.y + PadenieSv.w * Time.deltaTime;
            }
            else
            {
                PadenieSv.y = PadenieSv.z;
            }

            /*  if (Mathf.Sign(Ruzgon.y + 20) < Ruzgon.x)
              {
                  if (LeftRight == true)
                  {
                      a = 10;
                  }
                  else
                  {
                      a = -10;
                  }
              }
              else
              {
                  a = 0;

              }*/
            Ruzgon.y = RG2.velocity.x;
            RG2.velocity = new Vector2(Ruzgon.y, PadenieSv.y);
        }
        else
        {
            PadenieSv.y = 0;
        }
    }
    void NapravPers()//Напрвление героя
    {
        Vector3 XY = transform.eulerAngles;
        if (transform.position.x < Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
        {
            LeftRight = true;
            transform.eulerAngles = new Vector3(XY.x, 0, XY.z);
        }
        else
        {
            LeftRight = false;
            transform.eulerAngles = new Vector3(XY.x, 180, XY.z);
        }
    }
    public void RunPerson(int Napr)//Бег персонажа
    {
        if (NPol != null || NBox != null || NLestnica != null)
        {
            if (Mathf.Abs(Ruzgon.y) + Ruzgon.z * Time.deltaTime < Ruzgon.x)
            {
                Ruzgon.y = Mathf.Abs(Ruzgon.y) + Ruzgon.z * Time.deltaTime;
            }
            else
            {
                Ruzgon.y = Ruzgon.x;
            }
            if (LeftRight == true && Napr < 0 || LeftRight == false && Napr > 0)
            {
                Ruzgon.y = speedShag;
            }
            RG2.velocity = new Vector2(Ruzgon.y * Napr, RG2.velocity.y);//Задаем скорость

        }
    }
    public void RunStop()//Остановка героя
    {
        Ruzgon.y = 0;
        if (NPol != null || NBox != null || NLestnica != null)
        {
            RG2.velocity = new Vector2(Ruzgon.y, RG2.velocity.y);//Задаем скорость
        }
    }
    public void VklDjump()//Начало прыжка 
    {
        if (NPol != null || NBox != null || NLestnica != null)
        {
            if (UpDown == false)
            {
                XYUP = transform.position;//Начало рыжка координаты
                JumpIk.x = GetComponent<Rigidbody2D>().velocity.x;//Координаты начала прыжка
                UpDown = true;//Статус прыжок
                transform.GetChild(1).GetChild(0).gameObject.layer = 10;
                JumpIk.y = 0;
            }
        }
        /*if (Pol == null && Wall != null)
        {
            int a = 1;
            XYUP = transform.position;
            if (XYKos.x < Wall.transform.position.x)
            {
                a = -1;
            }
            JumpIk.x = WallJump * a;
            TimesZacep.x = TimesZacep.x - TimesZacep.y;
            UpDown = true;
            //gameObject.layer = 11;
        }*/
    }
    void JumperUp()//Сам прыжок
    {
        if (UpDown == true)//Прыжок
        {
            JumpIk.y = JumpIk.y + JumpIk.z * Time.deltaTime;
            if (RWall == null && LWall == null && (transform.position.y + JumpIk.y) - XYUP.y < JumpIk.w && VPol == null)
            {
                RG2.velocity = new Vector2(RG2.velocity.x, JumpIk.y);
            }
            else
            {
                UpDown = false;
                transform.GetChild(1).GetChild(0).gameObject.layer = 9;
            }


            //  else
            //  {
            //     RG2D.velocity = new Vector2(Jumper.x, Jumper.z);
            //Debug.Log(Pers.transform.position.y + "  -  " + NachPol.y + "  =  " + (transform.position.y - NachPol.y) + "::" + Jumper.w);
            //  }
            //  float yP = Pers.transform.position.y;
            //   if (yP - NachPol.y > Jumper.w)
            //  {
            //      Up = false;
            //  }

            /* if (Wall2 == null)
             {
                 UpDown = PeS.Jump(this.gameObject, JumpIk, XYUP);
             }
             if (Wall2 != null)
             {
                 UpDown = PeS.Jump(this.gameObject, JumpIk, XYKos, true);
             }
             if (UpDown == false)
             {
                 gameObject.layer = 9;
             }
             else
             {
                 gameObject.layer = 11;
             }*/
        }
    }
    public void SpuskVniz()//Спуск вниз с ящика
    {
        if (NBox != null)
        {
            Times = Time.time;
            transform.GetChild(1).GetChild(0).gameObject.layer = 10;
        }
        /* if (Zacep == true)
         {
             float a = Mathf.Sign(transform.position.x - Wall.transform.position.x);
             RG2.constraints = RigidbodyConstraints2D.FreezeRotation;
             RG2.velocity = new Vector2(50 * a, PadenieSv.y);
             Zacep = false;
             gameObject.layer = 9;
             RG2.velocity = new Vector2(50 * a, PadenieSv.y);
         }*/
    }
    void StopSpusk()//Отключаем спуск вниз
    {
        if (Times != 0)
        {
            if (Time.time - Times > 0.1f)
            {
                if (NLestnica == null)
                {
                    transform.GetChild(1).GetChild(0).gameObject.layer = 9;
                }
                Times = 0;
            }
        }
    }
    void LestnicaControl()//Метод движения по лестнице
    {
        if (NLestnica != null && LestnicaOn == true && UpDown != true)
        {
            transform.GetChild(1).GetChild(0).gameObject.layer = 10;
            RG2.velocity = new Vector2(RG2.velocity.x, SpeedLestnica * NaprL * Time.deltaTime * 100);
        }
        if (NLestnica != null && LestnicaOn == false && UpDown != true)
        {
            transform.GetChild(1).GetChild(0).gameObject.layer = 10;
            RG2.velocity = new Vector2(RG2.velocity.x, 0);
        }
    }
    public void LestnicaUpDown(float Napr)//Метод включения движения по летнице
    {
        LestnicaOn = true;
        NaprL = Napr;
    }
    public void LestnicaOff()//Отключение движения по лестнице
    {
        LestnicaOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        PadenieSvob();
        NapravPers();
        JumperUp();
        StopSpusk();
        LestnicaControl();
        /*   LeftRight = PeS.NapravPers(this.gameObject);
           JumperUp();
           if (Pol == null && PolP == null && Lestnica == null && UpDown == false && Wall2 == null && Wall == null)//Если ни чего не касаемся
           {
               PadenieSv = PeS.Padenie(this.gameObject, PadenieSv);
           }
           else
           {
               if (UpDown == false)
               {
                   if (PadenieSv.y != 0)
                   {
                       PadenieSv = PeS.StopPadenie(this.gameObject, PadenieSv);
                   }
               }
           }
           if (Wall != null && Pol == null && Lestnica == null)//кОГДА КОСНУЛИСЬ ТОЛЬКО СТЕНЫ
           {

               XYKos = transform.position;
               if (Wall != Wall2)
               {
                   UpDown = false;
               }
               if (TimesZacep.x == 0 && Wall2 != Wall)
               {
                   Wall2 = Wall;
                   TimesZacep.x = Time.time;
               }
               gameObject.layer = 9;
               Zacep = PeS.WallZacep(this.gameObject, TimesZacep);
               if (Zacep == true)
               {
                   gameObject.layer = 11;
                   RG2.constraints = RigidbodyConstraints2D.FreezeAll;
                   RG2.velocity = new Vector2(0, 0);
               }
               else
               {
                   RG2.constraints = RigidbodyConstraints2D.FreezeRotation;
                   TimesZacep.x = 0;
               }
           }
           if (Pol != null  || Wall != null)
           {
               if (Wall != Wall2)
               {
                   if (Mathf.Abs(XYUP.y - transform.position.y) > 7)
                   {
                       UpDown = false;
                       gameObject.layer = 9;
                   }
               }
           }
           if(Pol != null || PolP != null || Lestnica != null)
           {
               Wall2 = null;
           }
           if(Zacep == true && Wall == null)
           {
               Zacep = false;
               RG2.constraints = RigidbodyConstraints2D.FreezeRotation;
           }*/

    }

}
