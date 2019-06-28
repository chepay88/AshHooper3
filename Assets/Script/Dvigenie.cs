using UnityEngine;
using System.Collections;

public class Dvigenie : MonoBehaviour {
    // Use this for initialization
    Hero HG;

    void Start() {
        dvigK(1);
        HG = GetComponent<Hero>();
    }

    public void dvigK(int Napr)//Движение персонажа, направление - 1 право (-1) - лево
    {
        HG = GetComponent<Hero>();
        if (HG.Pol != null || GetComponent<Hero>().Lestnica != null || GetComponent<Hero>().PolP != null)//если стоит на полу или лестнице
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(HG.speedH * Napr, 0);//Задаем скорость
        }
    }

    public void dvigKstop(int a, int b)//Останавливаем персонажа, скорости по x и y, либо придаем скорость
    {
        if (GetComponent<Hero>().Pol != null || GetComponent<Hero>().Lestnica != null || GetComponent<Hero>().PolP != null)//Если стот на полу или лестнице
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(a, b);
        }
        if (GetComponent<Hero>().Lestnica != null)//Если стит на лестнице
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(a, b);
        }
       // if(GetComponent<Hero>().PolP != null)
      //  {
       //     GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
       // }
    }

    public void VverhLect(int Napr)//Движение по лестнице, 1 - вверх, (-1) - вниз
    {
        if (GetComponent<Hero>().Lestnica != null)//Если персонаж на лестнице
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 200 * Napr);
        }
    }


   
	// Update is called once per frame
	void Update () {
        if(GetComponent<Hero>().Lestnica == null)//Костыль, чтоб с лестнице не скатываться
        {
            GetComponent<Rigidbody2D>().isKinematic = false;//Отключаем гравитацию
        }
	}
}
