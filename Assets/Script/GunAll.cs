using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAll : MonoBehaviour
{//общий скрипт для всех видов оружия
    //Переменные
    [Header("Имя оружия")]
    public string NameGun;//Имя оружия
    [Header("Тип оружия")]
    public int TipWaipoin;//тип оружия
    [Header("Стихия оружия")]
    public int WaipoinsStihiy;//Стихия Тип доп урона
    [Header("Количество боеприпасов сейчас в магазине и всего в магазине")]
    public Vector2 Magazin;//Количество боеприпасов до перезарядки/вместимость магазина
    [Header("Дальность стрельбы")]
    public float DalGun;//Дальность стрельбы
    [Header("Урон и урон от стихии")]
    public Vector2 AttakStiAttak;//x- Атака y-Урон т стихии
    [Header("Колличество патронов в очереди")]
    public int Ocher;//Количество патронов в очериди
    [Header("Дальность прицела")]
    public float PricDalGun;//Дальность прицела
    [Header("Время между выстрелами")]
    public float TimeZaderj;//Время между выстрелами
    [Header("Время перезарядки")]
    public float TimePerezarGun;//Время перезарядки
    [Header("Скорость полета пули")]
    public float SpeedWaipoins;//Скорость полета пули
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
