using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    public enum Behavior1 {Default = 0, Rage = 1};
    public Behavior1 Gad;
    public bool GGHoriz;//Опеделяем что герой в зоне видимости(паблик временно)
    GT GTQ;
    PhisicsAll Perss;
    GameObject GG;//Главный герой
    ParametrPersons PP;
    Rigidbody2D RG2;
    ControlPerson CP;
    GameObject GunModelText;
    // Start is called before the first frame update
    void Start()
    {
        CP = GetComponent<ControlPerson>();
        GTQ = GetComponent<ControlPerson>().GT.GetComponent<GT>();
        GG = GTQ.Hero1;
        RG2 = transform.GetChild(0).gameObject.GetComponent<Rigidbody2D>();
        Perss = GetComponent<PhisicsAll>();
        PP = GetComponent<ParametrPersons>();
        GunModelText = transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
    }
    void TurtToHero(Vector2 _target)//Поворот к герою, ну или на точку
    {
        Vector3 XY = transform.eulerAngles;
        if (_target.x - transform.position.x >= 0)
        {
           Perss._direction = true;
            transform.eulerAngles = new Vector3(XY.x, 0, XY.z);
        }
        else
        {
            Perss._direction = false;
            transform.eulerAngles = new Vector3(XY.x, 180, XY.z);
        }
    }

    public void AxisZFind()//Поиск позиции по оси Z
    {
        float Napr = 0;
        if (Mathf.Abs(GG.GetComponent<PhisicsAll>().LayerPers - Perss.LayerPers) > 2 && GG.GetComponent<PhisicsAll>().Perehod == Perss.Perehod)
        {
            Napr = Mathf.Sign(GG.transform.position.y - transform.position.y);
        }
        if (Perss.NPol != null && Perss._freeFall == false)
        {
            float _speedP = 0;
            if ((Mathf.Abs(PP._speedP.y) + Mathf.Abs(RG2.velocity.y)) <= PP._speedP.w)
            {
                _speedP = (Mathf.Abs(PP._speedP.y) + Mathf.Abs(RG2.velocity.y)) * Napr;
            }
            else
            {
                _speedP = PP._speedP.w * Napr;
            }
            RG2.velocity = new Vector2(RG2.velocity.x, _speedP);
        }
    }
    void StrickGun()//Стрельба
    {
        GunModelText.GetComponent<RukaPersons>().StrikeGuns(GG.transform.GetChild(0).position);
    }
    void EnemyBehaviorDefenishon()//Определяем поведение врага
    {

    }
    void Cooldawn()
    {
        if (GunModelText.transform.GetChild(0).gameObject.GetComponent<GunAll>().Magazin.x < 1)
        {
            GunModelText.GetComponent<RukaPersons>().PerezarydMagaz();
            print("L");
        }
    }
    void TrackDown(GameObject _target, float _dist)//Приследование
    {
        float _deltaNapr = _target.transform.position.x - transform.position.x;
        if (Mathf.Abs(_deltaNapr) > _dist)
        {
            CP.MovementPersonsX(Mathf.Sign(_deltaNapr));
        }
        else
        {
            CP.StopMovementPersonsX();
        }
    }
    void Aiming(GameObject _target)//Прицеливание
    {
        int a = 0;
        GunModelText = transform.GetChild(0).GetChild(0).GetChild(0).gameObject;
        GameObject RukaHand = transform.GetChild(0).GetChild(0).GetChild(0).gameObject;//Рука с оружием
        GameObject FF = GunModelText.GetComponent<Pricel>().AnimPointPrikladChoise();
        if (FF == null)
        {
            FF = GunModelText.GetComponent<Pricel>().PointL[1];
        }
        Vector3 ASD = _target.transform.position;
        var angle = Vector2.Angle(Vector2.right, ASD - GunModelText.transform.position);//угол между вектором от объекта к мыше и осью х
        if (ASD.y >= GunModelText.transform.position.y)//Если курсор выше серидины героя
        {
            a = 1;
        }
        else//Если ниже
        {
            a = -1;
        }
        GunModelText.transform.GetChild(0).eulerAngles = new Vector3(0, 0, angle * a);//Направляем оружие на курсор
        Vector3 XY = GunModelText.transform.GetChild(0).eulerAngles;
        if (ASD.x > GunModelText.transform.position.x)
        {
            GunModelText.transform.GetChild(0).eulerAngles = new Vector3(0, XY.y, XY.z);
        }
        else
        {
            GunModelText.transform.GetChild(0).eulerAngles = new Vector3(180, XY.y, XY.z * -1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Hero")
        {
            GGHoriz = true;
        }
    }
    private void FixedUpdate()
    {
        if (GGHoriz == true)
        {
            AxisZFind();
            TurtToHero(GG.transform.position);
            Aiming(GG.transform.GetChild(0).gameObject);
            TrackDown(GG, 5);
            StrickGun();
            Cooldawn();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
