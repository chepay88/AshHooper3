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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name == "Niz")
        {
            if (collision.gameObject.tag == "pol")
            {
                PeS.NPol = collision.gameObject;
                PeS.PadenieSv.y = 0;
            }
            if (collision.gameObject.tag == "PolP")
            {
                PeS.NBox = collision.gameObject;
                PeS.PadenieSv.y = 0;
            }
        }
        }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (gameObject.name == "Niz")
        {
            if (collision.gameObject.tag == "pol")
            {
                PeS.NPol = null;
            }
            if (collision.gameObject.tag == "PolP")
            {
                PeS.NBox = null;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.name == "Niz")
        {
            if (collision.gameObject.tag == "pol")
            {
                PeS.NPol = collision.gameObject;
                PeS.PadenieSv.y = 0;
            }
            if (collision.gameObject.tag == "PolP")
            {
                PeS.NBox = collision.gameObject;
                PeS.PadenieSv.y = 0;
            }
        }
        if(gameObject.name == "Verh")
        {
            if (collision.gameObject.tag == "pol")
            {
                PeS.VPol = collision.gameObject;
            }
        }
        if(gameObject.name == "Right")
        {
            if (collision.gameObject.tag == "pol")
            {
                PeS.RPol = collision.gameObject;
            }
               if (collision.gameObject.tag == "Wall")
             {
               PeS.RWall = collision.gameObject;                
             }
        }
        if (gameObject.name == "Left")
        {
            if (collision.gameObject.tag == "pol")
            {
                PeS.LPol = collision.gameObject;
            }
            if (collision.gameObject.tag == "Wall")
            {
                PeS.LWall = collision.gameObject;
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (gameObject.name == "Niz")
        {
            if (collision.gameObject.tag == "pol")
            {
                PeS.NPol = collision.gameObject;
            }
            if (collision.gameObject.tag == "PolP")
            {
                PeS.NBox = collision.gameObject;
            }
        }
        if (gameObject.name == "Verh")
        {
            if (collision.gameObject.tag == "pol")
            {
                PeS.VPol = collision.gameObject;
            }
        }
        if (gameObject.name == "Right")
        {
            if (collision.gameObject.tag == "pol")
            {
                PeS.RPol = collision.gameObject;
            }
            if (collision.gameObject.tag == "Wall")
            {
                PeS.RWall = collision.gameObject;
            }
        }
        if (gameObject.name == "Left")
        {
            if (collision.gameObject.tag == "pol")
            {
                PeS.LPol = collision.gameObject;
            }
            if (collision.gameObject.tag == "Wall")
            {
                PeS.LWall = collision.gameObject;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (gameObject.name == "Niz")
        {
            if (collision.gameObject.tag == "pol")
            {
                PeS.NPol = null;
            }
            if (collision.gameObject.tag == "PolP")
            {
                PeS.NBox = null;
            }
        }
        if (gameObject.name == "Verh")
        {
            if (collision.gameObject.tag == "pol")
            {
                PeS.VPol = null;
            }
        }
        if (gameObject.name == "Right")
        {
            if (collision.gameObject.tag == "pol")
            {
                PeS.RPol = null;
            }
            if (collision.gameObject.tag == "Wall")
            {
                PeS.RWall = null;
            }
        }
        if (gameObject.name == "Left")
        {
            if (collision.gameObject.tag == "pol")
            {
                PeS.LPol = null;
            }
            if (collision.gameObject.tag == "Wall")
            {
                PeS.LWall = null;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
