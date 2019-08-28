using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParametrPersons : MonoBehaviour
{
    [Header("Скорость персонажа")]
    public Vector4 _speedP;//(x - Макс по X,y - Макс по Z,z - разгон по X,a - разгон по Z)
    [Header("Скорость свободного падения персонажа")]
    public Vector2 _freeFallSpeed;// x - ускорение, y - максимальная скорость
    [Header("Скорость прыжка и его высота")]
    public Vector2 JumpSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
