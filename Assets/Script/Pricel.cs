﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Все связаное с прицелом
public class Pricel : MonoBehaviour
{
    public GameObject GunModelText;//Текстура
    public GameObject[] PointL = new GameObject[3];
    int a;//Переменная для нахождения направления курсора
    // Start is called before the first frame update
    void Start()
    {
        ChoicePoint();
        PointL[0].name = "1";
        PointL[1].name = "2";
        PointL[2].name = "3";
        //transform.GetChild(0).GetChild(0).GetChild(1).gameObject.SetActive(false);
        //transform.GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(false);
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
        for (int i4 = PointL.Length; i4 >0; i4--)
        {
            PointL[i4 - 1].SetActive(false);
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
   public GameObject AnimPointPrikladChoise()//Точки анимации, движение анимации
    {
        GameObject FF = null;
        if(GunModelText.transform.GetChild(0).eulerAngles.z < 360)
        {
            FF = PointL[1];
            //Debug.Log(FF);
        }
        if(GunModelText.transform.GetChild(0).eulerAngles.z < 330)
        {
            FF = PointL[0];
        }
        if (GunModelText.transform.GetChild(0).eulerAngles.z < 90)
        {
            FF = PointL[1];
        }
        if (GunModelText.transform.GetChild(0).eulerAngles.z < 70)
        {
            FF = PointL[2];
        }
        //else
             //{
             //  FF = PointL[1];
             //}
        return FF;
    }
    void PointHeands()
    {
        if (transform.parent)
        {
            if (transform.GetChild(0).GetChild(0).childCount >1)
            {
                GameObject Left = transform.parent.GetChild(1).GetChild(11).GetChild(1).GetChild(0).gameObject;
                GameObject Right = transform.parent.GetChild(1).GetChild(11).GetChild(1).GetChild(1).gameObject;
                Left.transform.position = transform.GetChild(0).GetChild(0).GetChild(1).position;
                Right.transform.position = transform.GetChild(0).GetChild(0).GetChild(2).position;
            }
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (transform.parent.parent.gameObject.tag == "Hero")
        {
            GameObject FF = AnimPointPrikladChoise();
            if (FF == null)
            {
                FF = PointL[1];
            }
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
            GunModelText.transform.GetChild(0).eulerAngles = new Vector3(0, 0, angle * a);//Направляем оружие на курсор
            Vector3 XY = GunModelText.transform.GetChild(0).eulerAngles;
            if (ASD.x > transform.position.x)
            {
                GunModelText.transform.GetChild(0).eulerAngles = new Vector3(0, XY.y, XY.z);
            }
            else
            {
                GunModelText.transform.GetChild(0).eulerAngles = new Vector3(180, XY.y, XY.z * -1);
            }
           // GunModelText.transform.GetChild(0).position = FF.transform.position;
        }
        PointHeands();
    }
    void Update()
    {
 
    }
}
