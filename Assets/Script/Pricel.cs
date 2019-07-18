using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Все связаное с прицелом
public class Pricel : MonoBehaviour
{
    public GameObject GunModelText;//Текстура
    GameObject[] PointL = new GameObject[3];
    int a;//Переменная для нахождения направления курсора
    // Start is called before the first frame update
    void Start()
    {
        ChoicePoint();
    }
    void ChoicePoint()//определяем какая точка выше или ниже
    {
        GameObject point;
        for (int i1 = 0; i1 < 3; i1++)
        {
            point = GunModelText.transform.GetChild(i1+1).gameObject;
            if(PointL[0] == null)
            {
                PointL[0] = point;
            }
            else
            {
                ForPoint(point);
            }
        }
     }
    void ForPoint(GameObject point)//Цикл, для точек
    {
        GameObject Buf;
        for (int i2 = 0; i2 < PointL.Length; i2++)
        {
            if (PointL[i2] != null)
            {
                if (point.transform.position.y > PointL[i2].transform.position.y)
                {
                    Buf = PointL[i2];
                    PointL[i2] = point;
                    point = Buf;
                }
            }
            else
            {
                PointL[i2] = point;
            }
        }
    }
    GameObject AnimPointPrikladChoise()
    {
        GameObject FF = null;
        if(GunModelText.transform.eulerAngles.z < 90 && GunModelText.transform.eulerAngles.z > 0)
        {
            FF = PointL[2];
        }
        if(GunModelText.transform.eulerAngles.z > 270 && GunModelText.transform.eulerAngles.z < 360)
        {
            FF = PointL[0];
        }
        return FF;
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        GameObject FF = AnimPointPrikladChoise();
        if(FF== null)
        {
            FF = PointL[1];
        } 
        Debug.Log(FF);
        Vector3 ASD = Camera.main.ScreenToWorldPoint(Input.mousePosition);//Положение мыши в мировых координатах
        var angle = Vector2.Angle(Vector2.right, ASD - transform.position);//угол между вектором от объекта к мыше и осью х
        if (ASD.y >= transform.position.y)//Если курсор выше серидины героя
        {
            a = 1;
        }
        else//Если ниже
        {
            a = -1;
        }
        GunModelText.transform.eulerAngles = new Vector3(0, 0, angle * a);//Направляем оружие на курсор
        Vector3 XY = GunModelText.transform.eulerAngles;
        if (ASD.x > transform.position.x)
        {
            GunModelText.transform.eulerAngles = new Vector3(0, XY.y, XY.z);
        }
        else
        {
            GunModelText.transform.eulerAngles = new Vector3(180, XY.y, XY.z * -1);
        }
        GunModelText.transform.GetChild(0).position = FF.transform.position;
    }
    void Update()
    {
 
    }
}
