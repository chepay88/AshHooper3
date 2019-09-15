using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [Header("Смещение по оси X")]
    public float X;
    [Header("Смещение по оси Y")]
    public float Y;
    public GameObject Target;//ГОна который указывает камера
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void LateUpdate()
    {
       // transform.position = Target.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        //  Camera.main.transform.position = Target.transform.position;

        transform.position = new Vector3(Target.transform.position.x + X, 0 /*Target.transform.position.y + Y*/, transform.position.z);


    }
}
