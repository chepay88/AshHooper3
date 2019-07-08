using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lestnica : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Hero" && collision.name == "Niz")
        {
            collision.transform.parent.parent.gameObject.GetComponent<PersonsS>().NLestnica = this.gameObject;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Hero" && collision.name == "Niz")
        {
            collision.transform.parent.parent.gameObject.GetComponent<PersonsS>().NLestnica = this.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Hero" && collision.name == "Niz")
        {
            collision.transform.parent.parent.gameObject.GetComponent<PersonsS>().NLestnica = null;
            collision.gameObject.layer = 9;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
