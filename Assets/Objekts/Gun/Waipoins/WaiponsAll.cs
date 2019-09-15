using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiponsAll : MonoBehaviour
{
    public int TipW;//Тип патронов
    public int TipStihW;//Тип стихии патрона
    public Vector2 DamageW;//Урон
    public float speedW;//Скорость патрона
    public float Dalnost;//Дальность полета пули

    public Vector2 Nac;
    public float NachDlina;//Точка начала отсчета


    public Vector2 XYZ;

    // Start is called before the first frame update
    void Start()
    {
 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject GG = collision.gameObject.transform.parent.parent.parent.gameObject;
        ControlPerson CP = GG.GetComponent<ControlPerson>();
        //ParametrPersons PP = GG.GetComponent<ParametrPersons>();
        //PP._helfPers = PP._helfPers - DamageW.x;
        //print(PP._helfPers);
        CP.DeltaHalf(DamageW.x * -1f);
        gameObject.SetActive(false);
        //print(collision.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       // Debug.Log(collision);
        if (collision.gameObject.layer != 0)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log(collision);
        if (collision.gameObject.layer != 0)
        {
            gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Mathf.Sqrt(Mathf.Abs(Nac.x - transform.position.x) + Mathf.Abs(Nac.x - transform.position.y)) < Dalnost)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(XYZ.normalized.x * speedW * 1000 * Time.deltaTime, XYZ.normalized.y * speedW * 1000 * Time.deltaTime);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    void Update()
    {
        
    }
}
