using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
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

        transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y, transform.position.z);


    }
}
