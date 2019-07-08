using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonsControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public void Hotba(GameObject Pers, float speedP, int Napr, bool Povorot)
    {
        Rigidbody2D RG2D = Pers.GetComponent<Rigidbody2D>();
        if (Povorot == true && Napr < 0 || Povorot == false && Napr > 0)
        {
            speedP = speedP / 2;
        }
        RG2D.velocity = new Vector2(speedP * Napr, RG2D.velocity.y);//Задаем скорость
    }//Хотьба персонажа
    public Vector3 RunPers(GameObject Pers, float speedP, int Napr, bool Povorot, Vector3 Razgon)
    {
        speedP = speedP + Razgon.y;
        if (Razgon.y + Razgon.z * Time.deltaTime < Razgon.x)
        {
            Razgon.y = Razgon.y + Razgon.z * Time.deltaTime;
        }
        Hotba(Pers, speedP, Napr, Povorot);
        return Razgon;
    }//Бег персонажа с учетом разбега и ускорения
    public Vector3 StopRazgon(GameObject Pers, Vector3 Razgon)
    {
        Razgon.y = 0;
        return Razgon;
    }//Останавливаем разгон
    public bool NapravPers(GameObject Pers)
    {
        Vector3 XY = Pers.transform.eulerAngles;
        bool LefPrav = false;
        if (Pers.transform.position.x < Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
        {
            LefPrav = true;
            Pers.transform.eulerAngles = new Vector3(XY.x, 0, XY.z);
        }
        else
        {
            LefPrav = false;
            Pers.transform.eulerAngles = new Vector3(XY.x, 180, XY.z);
        }
        return LefPrav;
    }//Напрвление героя
    public Vector4 Padenie(GameObject Pers, Vector4 Padenie)
    {
        float SpeedX;
        Rigidbody2D RG2;
        RG2 = Pers.GetComponent<Rigidbody2D>();
        if (RG2.velocity.x != 0)
        {
            SpeedX = RG2.velocity.x;
        }
        else
        {
            SpeedX = Padenie.x;
        }
        RG2.velocity = new Vector2(SpeedX, Padenie.y);
        if (Padenie.y + Padenie.w * Time.deltaTime > Padenie.z)
        {
            Padenie.y = Padenie.y - Padenie.w * Time.deltaTime;
        }
        else
        {
            Padenie.y = Padenie.z;
        }
        return Padenie;
    }//Регулировка свободного падения
    public Vector4 StopPadenie(GameObject Pers, Vector4 Padenie)//Остановка падения и набора скорости
    {
        Padenie.y = 0;
        return Padenie;
    }
    public bool Jump(GameObject Pers, Vector4 Jumper, Vector2 NachPol, bool Wall2)
    {
        bool Up = true;//Переменная индикация прыжка
        Rigidbody2D RG2D = Pers.GetComponent<Rigidbody2D>();//Ссылка
        if (Wall2 == false)
        {
            RG2D.velocity = new Vector2(Jumper.x / 2, Jumper.z);
        }
        else
        {
            RG2D.velocity = new Vector2(Jumper.x, Jumper.z);
            //Debug.Log(Pers.transform.position.y + "  -  " + NachPol.y + "  =  " + (transform.position.y - NachPol.y) + "::" + Jumper.w);
        }
        float yP = Pers.transform.position.y;
        if (yP - NachPol.y > Jumper.w)
        {
            Up = false;
        }
        return Up;
    }//Прыжок, набор высоты до молмента падения
    public bool Jump(GameObject Pers, Vector4 Jumper, Vector2 NachPol)
    {
        return Jump(Pers, Jumper, NachPol, false);
    }
    public bool WallZacep(GameObject Pers, Vector2 Times)
    {
        bool Zacep = true;
        if(Time.time - Times.x > Times.y)
        {
            Zacep = false;
        }
        return Zacep;
    }
    public void LestnicaUpDown(GameObject Pers, float Napr, float SpeedLestnica)
    {
        Rigidbody2D RG2 = Pers.GetComponent<Rigidbody2D>();
        RG2.velocity = new Vector2(-0, SpeedLestnica * Napr * Time.deltaTime*100);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
