using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Для работы с тригером тижним
public class ColNiz : MonoBehaviour
{
    Hero he;
    // Start is called before the first frame update
    void Start()
    {
        he = transform.parent.parent.gameObject.GetComponent<Hero>();
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "PolP")
        {
            he.TrigPolP = c.gameObject;
        }
    }
    private void OnTriggerStay2D(Collider2D c)
    {
        if (c.gameObject.tag == "PolP")
        {
              he.TrigPolP = c.gameObject;
    }
    }
    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.tag == "PolP")
        {
            he.TrigPolP = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
