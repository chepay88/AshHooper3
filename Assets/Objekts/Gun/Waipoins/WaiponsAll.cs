using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiponsAll : MonoBehaviour
{
    public int TipW;
    public float DamageW;
    public float speedW;

    Vector3 ASD;
    Vector2 XYZ;

    // Start is called before the first frame update
    void Start()
    {
        ASD = Camera.main.ScreenToWorldPoint(Input.mousePosition);//Положение мыши в мировых координатах
        XYZ = new Vector2(ASD.x - transform.position.x, ASD.y - transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(XYZ.x*speedW*Time.deltaTime, XYZ.y*speedW*Time.deltaTime) ;
    }
}
