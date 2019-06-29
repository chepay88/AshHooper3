using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour
{
    public float Zacep;//сила зацепа
    public float powerUpPer;//Максимальная сила прыжка в сторону
    public int speedH;//скорость героя
    public float speedUp;//Скорость с которой персонаж прыгает
    public float HeightUpPer;//Высота на которую прыгает герой
    //Переменные обозначающие, что что-то касается персонажа
    public GameObject Pol = null;//Пол
    public GameObject Wall = null;//Стена
    public GameObject Lestnica = null;//Лестница
    public GameObject PolP = null;//Поверхность сквозб которую можно пройти
   // public GameObject PolP1 = null;//Объект для проверки тот же или нет
    public Vector2 Xy;//Координаты персонажа в момен таксания



    public GameObject TrigPolP = null;//Переменная, показывающая стоит ли нижний на лестнице или нет
    public bool Up = false;//Переменная, говорящая о том, что персонаж в прыжке

  
                      // Use this for initialization
    void Start()
    {

    }
    void OnCollisionEnter2D(Collision2D c)//Метод столкновения персонажа с чем либо
    {
       // PolP1 = null;
        if (c.gameObject.tag == "pol")//Один раз задел пол
        {
            GetComponent<Rigidbody2D>().isKinematic = false;//Отключаем кинематику
            Pol = c.gameObject;//Присваеваем значение
            if (Up == true)//Если в прыжке
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);//Останавливаем при столкновении с землей
                Up = false;//выключаем режим прыжка
            }

        }
        if (c.gameObject.tag == "Wall")//Один раз каснулся стены
        {
            Wall = c.gameObject;//Присваеваем значение
            Xy = transform.position;//Координаты, в которых находился персонаж в момент касания

        }
        if (c.gameObject.tag == "Lestnica")//Один раз каснулся лесницы
        {
            if (GetComponent<Hero>().Pol == null)//Если не касается и пола в это время
            {
                GetComponent<Rigidbody2D>().isKinematic = true;//Физику выключаем
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);//отключаем скорость, чтоб персонаж не вздумал падать
            }
            Lestnica = c.gameObject;//Присваеваем значение
            Xy = transform.position;//Координаты, в которых находился персонаж в момент касания

        }
        if (c.gameObject.tag == "PolP")//Один раз задел полП
        {
            GetComponent<Rigidbody2D>().isKinematic = false;//Отключаем кинематику
            PolP = c.gameObject;//Присваеваем значение
            if (Up == true)//Если в прыжке
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);//Останавливаем при столкновении с землей
                Up = false;//выключаем режим прыжка
            }
        }
        
    }
    private void OnCollisionStay2D(Collision2D co)//Метод непрерывного касания
    {
        
        if (co.gameObject.tag == "Wall")//Каснулись стены
        {
            Wall = co.gameObject;//Присваеваем значение
            Xy = transform.position;//Координаты персонажа в момент касания
        }
        if (co.gameObject.tag == "pol")//Каснулись пола
        {
            Pol = co.gameObject;//Присваеваем значение
            GetComponent<Rigidbody2D>().isKinematic = false;//Включаем гравитацию персонажа
        }
        if (co.gameObject.tag == "Lestnica")//Каснулись лестницы
        {
            if (GetComponent<Hero>().Pol == null)//Если не касаемся пола
            {
                GetComponent<Rigidbody2D>().isKinematic = true;//Выключаем гравитацию
            }
            Lestnica = co.gameObject;//Присваеваем значение
            Xy = transform.position;//Координаты персонажа в момент касания
        }
        if (co.gameObject.tag == "PolP")//Каснулись пола
        {
            PolP = co.gameObject;//Присваеваем значение
            GetComponent<Rigidbody2D>().isKinematic = false;//Включаем гравитацию персонажа
        }
    }
    private void OnCollisionExit2D(Collision2D collision)//Метод выхода из касания
    {
        if (collision.gameObject.tag == "Wall")//Перестали касаться стены
        {
            Wall = null;//Удаляем значение 
        }
        if (collision.gameObject.tag == "pol")//Перестали касаться пола
        {
            Pol = null;//Удаляем значение
        }
        if (collision.gameObject.tag == "Lestnica")//Перестали касаться Лестницы
        {
            Lestnica = null;//Удаляем значение
            if (GetComponent<Rigidbody2D>().velocity.y > 0 && GetComponent<Rigidbody2D>().velocity.x == 0)//Когда лестница кончилась при подъеме
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);//Скорость меняем на 0
            }
        }
        if (collision.gameObject.tag == "PolP")//Перестали касаться пола
        {
            PolP = null;//Удаляем значение
        }
    }
    // Update is called once per frame


    void Update()
    {
        if (TrigPolP != null || Up == true)
        {
            gameObject.layer = 9;
        }
        else
        {
            gameObject.layer = 11;
        }
    }
}
