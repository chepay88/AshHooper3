using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    bool GGHoriz;
    GT GTQ;
    PersonsS Perss;
    GameObject GG;//Главный герой
    // Start is called before the first frame update
    void Start()
    {
        GTQ = GetComponent<ControlPerson>().GT.GetComponent<GT>();
        GG = GTQ.Hero1;
        Perss = GetComponent<PersonsS>();
    }
    public void AxisZFind()//Поиск позиции по оси Z
    {
        if (GGHoriz == true && Perss.NPol != null)
        {
            float a = transform.position.y;
            float b = GG.transform.position.y;
            if (b > a + 0.05f || b < a - 0.05f)
            {
                float EZ = a - b;
                Perss.StepPersZ(EZ / Mathf.Abs(EZ)*-1);
               // GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, (EZ / Mathf.Abs(EZ)) * -1 * Perss.SpeedZ * Time.deltaTime * Perss.Ruzgon.x);
            }
            else
            {
                Perss.StepZStop();
              //  GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Hero")
        {
            GGHoriz = true;
        }
    }
    private void FixedUpdate()
    {
        AxisZFind();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
