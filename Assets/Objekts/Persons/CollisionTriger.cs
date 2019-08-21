using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTriger : MonoBehaviour
{
    //Скрипт для определения чего мы коснулись. Всю информацию о касании передаем в 
    PersonsS PeS;
    // Start is called before the first frame update
    void Start()
    {
        PeS = transform.parent.parent.gameObject.GetComponent<PersonsS>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.name == "Niz")
        {
            if (collision.gameObject.tag == "pol" && PeS.NPol2 == collision.gameObject)
            {
                PeS.NPol2 = null;
            }
            if (collision.gameObject.tag == "PolP")
            {
                PeS.NBox = null;
            }
            if (collision.gameObject.tag == "Perehod")
            {
                PeS.NPereh = null;
            }
            if (collision.gameObject.tag == "Pol1" && PeS.NPol1 == collision.gameObject)
            {
                PeS.NPol1 = null;
            }
            if (collision.gameObject.tag == "Kray")
            {
                PeS.Kray = null;
            }
            if (collision.gameObject.tag == "Kray1")
            {
                PeS.Kray1 = null;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (gameObject.name == "Niz")
        {
            if (collision.gameObject.tag == "pol")
            {
                PeS.NPol2 = collision.gameObject;
                PeS.PadenieSv.y = 0;
            }
            if (collision.gameObject.tag == "PolP")
            {
                PeS.NBox = collision.gameObject;
                PeS.PadenieSv.y = 0;
            }
            if(collision.gameObject.tag == "Perehod")
            {
                PeS.NPereh = collision.gameObject;
            }
            if (collision.gameObject.tag == "Pol1")
            {
                PeS.NPol1 = collision.gameObject;
            }
            if (collision.gameObject.tag == "Kray")
            {
                PeS.Kray = collision.gameObject;
            }
            if (collision.gameObject.tag == "Kray1")
            {
                PeS.Kray1 = collision.gameObject;
            }
        }
        }
        
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (gameObject.name == "Niz")
        {
            if (collision.gameObject.tag == "Kray")
            {
                PeS.Kray = collision.gameObject;
            }
            if (collision.gameObject.tag == "Kray1" && PeS.PerehodN == true)
            {
                PeS.Kray1 = collision.gameObject;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
