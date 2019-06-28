using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zacep : MonoBehaviour
{
    float aada;
    float Chet = 1;
    bool Go = false;
    Hero HG;
    public void Zacepil()
    {
        HG = GetComponent<Hero>();
        if(HG.Wall != null && HG.Pol == null && HG.PolP == null)
        {
            Go = true;
        }
    }
    public void otpalWall()
    {
        if(GetComponent<Hero>().Wall != null && Go == true)
        {
            GetComponent<Upper>().UpUp(10);
            Go = false;
            Chet = 1;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Hero>().Wall != null && GetComponent<Hero>().Pol == null || GetComponent<Hero>().Wall != null && GetComponent<Hero>().PolP == null)
        {
            Go = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            transform.position = GetComponent<Hero>().Xy;
            if (Chet > GetComponent<Hero>().Zacep)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, aada);
                aada = aada - 10;
            }
        }
        if (Go == true)
        {
            Chet = Chet + 10*Time.deltaTime;
        
        }
        if (GetComponent<Hero>().Pol != null || GetComponent<Hero>().Wall == null || GetComponent<Hero>().PolP != null)
        {
            Go = false;
            Chet = 1;
        }
    }
}
