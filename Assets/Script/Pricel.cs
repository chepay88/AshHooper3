using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Все связаное с прицелом
public class Pricel : MonoBehaviour
{
    int a;//Переменная для нахождения направления курсора
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ASD = Camera.main.ScreenToWorldPoint(Input.mousePosition);//Положение мыши в мировых координатах
       var angle = Vector2.Angle(Vector2.right, ASD - transform.position);//угол между вектором от объекта к мыше и осью х
        if(ASD.y >= transform.position.y)//Если курсор выше серидины героя
        {
            a = 1;
        }
        else//Если ниже
        {
            a = -1;
        }
        transform.GetChild(0).GetChild(0).transform.eulerAngles = new Vector3(0f, 0f, angle*a);//Направляем оружие на курсор
 
    }
}
