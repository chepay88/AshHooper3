using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiponsAll : MonoBehaviour
{
    public int TipW;//Тип патронов
    public float DamageW;//Урон
    public float speedW;//Скорость патрона
    public float Dalnost;//Дальность полета пули
    public float NachDlina;//Точка начала отсчета
    public Vector2 XYZ;

    // Start is called before the first frame update
    void Start()
    {
 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 0)
        {
            gameObject.SetActive(false);
            Debug.Log(collision);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 0)
        {
            gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.magnitude) - NachDlina < Dalnost)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(XYZ.normalized.x * speedW * Time.deltaTime, XYZ.normalized.y * speedW * Time.deltaTime);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
