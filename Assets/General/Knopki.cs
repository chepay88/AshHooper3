using UnityEngine;
using System.Collections;

public class Knopki : MonoBehaviour
{
    public KeyCode RiteK;//Клавиша вправо
    public KeyCode LeftK;//Клавиша лево
    public KeyCode Up;//Прыжок
    public KeyCode Vverh;// Движение вверх по лестнице
    public KeyCode Niz;//Движение в низ
    public KeyCode Fire;//Стрельба, удар
    public KeyCode Perezaryd;//Клавиша перезарядки патронов

    GT GTQ;
    PersonsS PeRs;
    // Use this for initialization
    void Start()
    {
        GTQ = GetComponent<GT>();
        PeRs = GTQ.Hero.GetComponent<PersonsS>();
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetKey(LeftK))
            {
                PeRs.RunPerson(-1);
            }
            if (Input.GetKey(RiteK))
            {
                PeRs.RunPerson(1);
            }

        if (Input.GetKeyUp(LeftK))
        {
            PeRs.RunStop();
            if (Input.GetKeyDown(Up))
            {
                PeRs.VklDjump();
            }
        }
        if (Input.GetKeyUp(RiteK))
        {
            PeRs.RunStop();
            if (Input.GetKeyDown(Up))
            {
                PeRs.VklDjump();
            }
        }
        if (Input.GetKeyDown(Up))
        {
            PeRs.VklDjump();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(GTQ.Hero.GetComponent<Rigidbody2D>().velocity);
        }
        if (Input.GetKey(Vverh))
        {
            PeRs.LestnicaUpDown(1);
        }
        if (Input.GetKey(Niz))
        {
            PeRs.SpuskVniz();
            PeRs.LestnicaUpDown(-1);
        }
        if (Input.GetKeyUp(Vverh))
        {
            PeRs.LestnicaOff();
        }
        if (Input.GetKeyUp(Niz))
        {
            PeRs.LestnicaOff();
        }
        if(Input.GetKeyDown(Fire))
        {
           // GTQ.Hero.transform.GetChild(0).GetChild(4).gameObject.GetComponent<RukaPersons>().StrikeGuns();
        }
        if (Input.GetKeyDown(Perezaryd))
        {
            GTQ.Hero.transform.GetChild(0).GetChild(4).gameObject.GetComponent<RukaPersons>().PerezarydMagaz();
        }
        /*
        if (Input.GetKey(RiteK))
        {
            if (GetComponent<GT>().Hero.GetComponent<Hero>().Pol != null || GetComponent<GT>().Hero.GetComponent<Hero>().PolP != null )
            {
                GetComponent<GT>().Hero.GetComponent<Upper>().PowerUpV(1);
            }
            if (Input.GetKey(Up))
            {
                GetComponent<GT>().Hero.GetComponent<Upper>().UpUp(1);
            }
            else
            {
                GetComponent<GT>().Hero.GetComponent<Dvigenie>().dvigK(1);
            }
            GetComponent<GT>().Hero.GetComponent<Upper>().PadenieBlock(1);
        }//Нажали кнопку вправо и держим
        if (Input.GetKeyUp(RiteK))
        {
            GetComponent<GT>().Hero.GetComponent<Upper>().PowerUpV(0);
            GetComponent<GT>().Hero.GetComponent<Dvigenie>().dvigKstop(0,0);
        }//ОТпустили кнопку вправо
        if (Input.GetKey(LeftK))
        {
            if (GetComponent<GT>().Hero.GetComponent<Hero>().Pol != null)
            {
                GetComponent<GT>().Hero.GetComponent<Upper>().PowerUpV(1);
            }
            if (Input.GetKey(Up))
            {
                GetComponent<GT>().Hero.GetComponent<Upper>().UpUp(-1);
            }
            else
            {
                GetComponent<GT>().Hero.GetComponent<Dvigenie>().dvigK(-1);
            }
            GetComponent<GT>().Hero.GetComponent<Upper>().PadenieBlock(-1);
        }//Нажали кнопку влево и держим
        if (Input.GetKeyUp(LeftK))
        {
            GetComponent<GT>().Hero.GetComponent<Dvigenie>().dvigKstop(0,0);
            GetComponent<GT>().Hero.GetComponent<Upper>().PowerUpV(0);
        }//Отпустили кнопку влево
        if (Input.GetKeyDown(Up))
        {
            GetComponent<GT>().Hero.GetComponent<Upper>().UpUp(0);
        }//Нажали кнопку прыжка
        if (Input.GetKey(Vverh))
        {
            GetComponent<GT>().Hero.GetComponent<Dvigenie>().VverhLect(1);
        }//Нажали кнопку Вверх и держим
        if (Input.GetKey(Niz))
        {
            GetComponent<GT>().Hero.GetComponent<Dvigenie>().VverhLect(-1);
            GetComponent<GT>().Hero.GetComponent<Zacep>().otpalWall();
            if(GetComponent<GT>().Hero.GetComponent<Hero>().TrigPolP != null && GetComponent<GT>().Hero.GetComponent<Hero>().Lestnica == null)
            {
               // GetComponent<GT>().Hero.GetComponent<Hero>().PolP1 = GetComponent<GT>().Hero.GetComponent<Hero>().TrigPolP;
                GetComponent<GT>().Hero.layer = 11;
            }
        }//Нажали кнопку вниз и держим
        if (Input.GetKeyUp(Vverh))
        {
            GetComponent<GT>().Hero.GetComponent<Dvigenie>().dvigKstop(0, 0);
        }//Отпустили кнопку вверх
        if (Input.GetKeyUp(Niz))
        {
            GetComponent<GT>().Hero.GetComponent<Dvigenie>().dvigKstop(0, 0);
        }//Отпустили кнопкувниз*/
    }
}
