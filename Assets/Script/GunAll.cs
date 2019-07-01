using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAll : MonoBehaviour
{//общий скрипт для всех видов оружия
    //Переменные
    public int TipGun;//тип оружия
    public string Name;//назавание оружия
    public float Attak;//Аттака(сила) урон
    public int Magazin;//Количество боеприпасов до перезарядки
    public int TipWaipoins;//Тип боеприпасов
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject Waipoin = Instantiate(transform.GetChild(1).gameObject, transform.position, transform.rotation) as GameObject;
            Waipoin.SetActive(true);
            Waipoin.transform.SetParent(gameObject.transform.parent.parent.parent.parent);
        }
    }
}
