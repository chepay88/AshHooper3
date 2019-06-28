using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallaks : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Target;//Цель, относительно которой скорость и регулируем
    Vector2 PosOld;//Старая позиция
    public float SpeedPar;//Переменная отвечающая за скорость паралакса

    void Start()
    {
        PosOld = Target.transform.position;
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x +(PosOld.x - Target.transform.position.x) *SpeedPar,transform.position.y +(PosOld.y - Target.transform.position.y)*SpeedPar);
            PosOld = Target.transform.position;
    }
}
