using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonsS : MonoBehaviour
{//Вся информация о персанаже самом. Как редактируемая так и техническая
 //Параметры персонажа
    [HideInInspector]
    public bool LeftRight;//Куда повеернуты, 1 - право, 0 лево
    [HideInInspector]
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
    [Header("Множитель Скорость движения по оси Z")]
    public float SpeedZ;//Коофициент скорости вбок


    //public bool Zacep;//Зацеплен ли на стене
    //public Vector2 TimesZacep;//y - время удержания на стене, x - дельта времени
    //public float WallJump;//Дальность прыжка от стены

    //Техническая
    [Space]
    [Header("Техническая информация")]
    public GameObject Gen;//Ссылка на генерал
    [Header("Ось Z")]
    public float OsZ;//Ось Z
    GT GTQ;//Ссылка на компонент GT
    Rigidbody2D RG2;
    PersonsControl PeS;
    float NaprL;//Показывает направление на лестнице
    bool SvPad = false;//Переменная свободного падения
    public bool PerehodN = false;//Переход активирован или нет
    GameObject NPolUp;//Поверхность с которой начинается прыжок

    //Чего касаемся
   // [HideInInspector]
    public GameObject NPol = null;//Пол, коснулись ногами
    [HideInInspector]
    public GameObject NPol1 = null;//Пол, , тип второй(Лестницы и тд)
    public GameObject Kray = null;//Край пола
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
    public Vector3 LostPos;
    // Start is called before the first frame update

    private void Awake()
    {
        GTQ = Gen.GetComponent<GT>();
        RG2 = GetComponent<Rigidbody2D>();
        PeS = Gen.GetComponent<PersonsControl>();
    }
    void Start()
    {
        LostPos  = new Vector3(-10000, -10000, -10000);
    }
    void PerehodMetod()//Метод перехода с обычного пола на лестницу
    {
        if (NPol2 != null && NPereh != null && UpDown == false)
        {
            PerehodN = true;
        }
        //
        if (NPol2 != null && NPereh == null && NPol1 == null && UpDown == false && SvPad != true)
        {
            PerehodN = false;
        }

        if (PerehodN == false && UpDown == false)
        {
            NPol = NPol2;
        }
        else
        {
            if (NPereh != null && UpDown == false)
            {
                NPol = NPereh;
            }
            else
            {
                NPol = NPol1;
            }
        }
    }
    void OpredOsZ()//Определяем положение персонажа по оси Z
    {
        if (OsZ > 10000)
        {
            OsZ = Mathf.Floor(transform.position.y);
        }
        else
        {
            if (UpDown == false && SvPad == false)
            {
                if (NPol != null || NBox != null || NLestnica != null)
                {
                    OsZ = Mathf.Floor(transform.position.y);
                }
            }
        }
    }
    void PadenieSvob()//Свободное падение(скорость по оси x)
    {
        if (TrigerPadenie() == true)
        {
                if (PadenieSv.y + PadenieSv.w * Time.deltaTime < PadenieSv.z)
                {
                    PadenieSv.y = PadenieSv.y + PadenieSv.w * Time.deltaTime;
                }
                else
                {
                    PadenieSv.y = PadenieSv.z;
            }
                Ruzgon.y = RG2.velocity.x;
                RG2.velocity = new Vector2(Ruzgon.y, PadenieSv.y);
        }
        else
        {
            if (SvPad == true)
            {
                if (OsZ >= Mathf.Floor(transform.position.y) || NPolUp != NPol && NPolUp.name != NPol.name)
                {
                    RG2.velocity = new Vector2(0, 0);
                    PadenieSv.y = 0;
                    SvPad = false;
                }
            }
        }

    }
    bool TrigerPadenie()//Проверка на касание героя к поверхности
    {
        bool A = false;
        if (NPol == null && NBox == null && NLestnica == null && UpDown == false)//Если ни чего не касаемся ногами - падаем
        {
            A = true;
            SvPad = true;
        }
        return A;
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
        if (Kray == null && PerehodN == false)
        {
            RunPersonL(Napr);
        }
        else
        {
            if (Kray1 == null && PerehodN == true)
            {
                RunPersonL(Napr);
            }
            else
            {
                transform.position = LostPos;
            }
        }
    }
    void RunPersonL(int Napr)
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
            LostPos = transform.position;
        }
    }
    public void StepPersZ(int Napr)//Движение персонажа вдоль Z
    {
        if (Kray == null && PerehodN == false)
        {
            StepPersZL(Napr);
        }
        else
        {
            if (Kray1 == null && PerehodN == true)
            {
                StepPersZL(Napr);
            }
            else
            {
                transform.position = LostPos;
            }
        }
    }
    void StepPersZL(int Napr)
    {
        if (NPol != null && NLestnica == null)
        {
            RG2.velocity = new Vector2(RG2.velocity.x, Ruzgon.x * Napr * Time.deltaTime * SpeedZ);//Задаем скорость
            LostPos = transform.position;                                                                                      // LostPosOpr();
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
    public void StepZStop()//Остановка персонажа по оси z
    {
        if (NPol != null)
        {
            RG2.velocity = new Vector2(RG2.velocity.x, 0);//Задаем скорость
        }
    }
    public void VklDjump()//Начало прыжка 
    {
        if (PerehodN == false)
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
                    NPolUp = NPol;
                }
            }
        }
    }
    void JumperUp()//Сам прыжок
    {
        if (UpDown == true)//Прыжок
        {
            JumpIk.y = JumpIk.y + JumpIk.z * Time.deltaTime;//ускорение по оси y
            if (RWall == null && LWall == null && (transform.position.y + JumpIk.y) - XYUP.y < JumpIk.w && VPol == null)//проверяем ни касаемся ли случаем чего, и не достигли максимальной высоты
            {
                RG2.velocity = new Vector2(RG2.velocity.x, JumpIk.y);//Если все ок, то движемся(скорость текущая по x, и новая по y
            }
            else//иначе
            {
                UpDown = false;//Выключаем индикацию прыжка
                transform.GetChild(1).GetChild(0).gameObject.layer = 9;//Возвращаем, начальный слой(вроде уже не используется, но влом искать)
            }
        }
    }
    public void SpuskVniz()//Спуск вниз с ящика
    {
        if (NBox != null)
        {
            Times = Time.time;
            transform.GetChild(1).GetChild(0).gameObject.layer = 10;
        }
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

    void Update()
    {
        PerehodMetod();
        NapravPers();
        JumperUp();
        StopSpusk();
        LestnicaControl();
        OpredOsZ();
        PadenieSvob();
    }
}
