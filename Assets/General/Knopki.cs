using UnityEngine;
using System.Collections;

public class Knopki : MonoBehaviour
{
    public KeyCode RiteK;//Клавиша вправо
    public KeyCode LeftK;//Клавиша лево
    public KeyCode Up;//Прыжок
    public KeyCode Vverh;// Движение вверх по лестнице
    public KeyCode Niz;//Движение в низ
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(RiteK))
        {
            if (GetComponent<GT>().Hero.GetComponent<Hero>().Pol != null || GetComponent<GT>().Hero.GetComponent<Hero>().PolP != null)
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
        }//Отпустили кнопкувниз
    }
}
