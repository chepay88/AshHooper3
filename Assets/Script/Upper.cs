using UnityEngine;
using System.Collections;
//Почти все что связано с прыжками
public class Upper : MonoBehaviour {
    Vector3 NachXY;//Координаты начала прыжка
    float naprA;//Переменная направления
    public float PowerUp = 1;//Сила прыжка
    //bool PowerOn = false;
    bool s=false;//Переменная запуска процесса
    float Padenie;//Какая-то переменная
	// Use this for initialization
	void Start () {
	
	}
    public void PowerUpV(int napr)//Прыгаем вверх
    {
        if (GetComponent<Hero>().Pol != null || GetComponent<Hero>().PolP != null)//Сработает только если стоим на полу
        {
            if (napr != 0 && PowerUp < GetComponent<Hero>().powerUpPer)//Если сила прыжка  меньше значения и направление не равно 0
            {
                PowerUp = PowerUp + napr;// Складываем силу и направление, таким образом мы регулируем разгон и силу прыжка
            }
            if(napr == 0)//Если направление = 0
            {
                PowerUp = 1;//То сила равна 1
            }
        }
    }
    public void UpUp(int napr)
    {
        if (GetComponent<Hero>().Pol != null || GetComponent<Hero>().Lestnica != null || GetComponent<Hero>().PolP != null)//Если стоим на полу или лестнице
        {
            GetComponent<Hero>().Up = true;//Присваеваем герою статус прыжка
            NachXY = transform.position;//Запоминаем начальные кординаты положения
            s = true;//Переменная для запуска прыжка в update
            naprA = napr;//Передаем значение направления
            Padenie = GetComponent<Hero>().speedUp;
        }
        if (GetComponent<Hero>().Wall != null)//Если приципились к стене
        {
            NachXY = transform.position;//Запоминаем начальные кординаты положения
            s = true;//Переменная для запуска прыжка в update
            naprA = Mathf.Sign(NachXY.x - GetComponent<Hero>().Wall.transform.position.x);//Вычисляем сторону противоположную от стены
            if (napr > 2)//Если параметр направления больше 2, то просто отцепляемся от стены
            {
                PowerUp = napr;//Сила прыжка равна направлению(немного)
                Padenie = 10;
            }
            else//Если мы не падаем, а отталкиваемся от стены
            {
                PowerUp = 30;//Тогда сила равна 30
            }
        }
    }
    public void PadenieBlock(int Napr)//Просто падаем когда ни чего не касается. Костыль чтоб усмерить физику, а то летит как не знаю что
    {
        if (GetComponent<Hero>().Pol == null && GetComponent<Hero>().Wall == null && GetComponent<Hero>().Lestnica == null && GetComponent<Hero>().Up == false && GetComponent<Hero>().PolP == null)//Проверяем, что ни чего не касаемся и не прыгаем
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(50*Napr, -250);//Скорость падения
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (s == true)//Сам процесс прыжка
        {
            if (Padenie > 10)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(10 * naprA * PowerUp, Padenie);

                if (GetComponent<Hero>().Pol == null || GetComponent<Hero>().PolP == null)
                {
                    if (transform.position.y > NachXY.y + GetComponent<Hero>().HeightUpPer)
                    {
                        s = false;
                        GetComponent<Hero>().Up = true;
                        GetComponent<Rigidbody2D>().velocity = new Vector2(10 * naprA * PowerUp, Padenie * -1);
                    }
                }
                if (GetComponent<Hero>().Pol != null || GetComponent<Hero>().PolP != null)
                {
                    if (NachXY.y + 5 < transform.position.y)
                    {
                        s = false;
                        GetComponent<Hero>().Up = true;
                        GetComponent<Rigidbody2D>().velocity = new Vector2(10 * naprA * PowerUp, Padenie * -1);
                    }
                }
            }
            if (Padenie == 10)
            {
                if (GetComponent<Hero>().Pol == null || GetComponent<Hero>().PolP == null)
                {
                    s = false;
                    GetComponent<Hero>().Up = true;
                    GetComponent<Rigidbody2D>().velocity = new Vector2(10 * naprA * PowerUp, Padenie * -1);
                }
            }
        }
 
    }
}
