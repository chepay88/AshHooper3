using UnityEngine;
using System.Collections;

public class Dvigenie : MonoBehaviour {
    // Use this for initialization
    Hero HG;
    public GameObject GTZ;
    GT GTY;

    void Start() {
        GTY = GTZ.GetComponent<GT>();
        dvigK(1);
        HG = GetComponent<Hero>();
    }

    public void dvigK(int Napr)//Движение персонажа, направление - 1 право (-1) - лево
    {
        HG = GetComponent<Hero>();
        if (HG.Pol != null || GetComponent<Hero>().Lestnica != null || GetComponent<Hero>().PolP != null)//если стоит на полу или лестнице
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(HG.speedH * Napr, 0);//Задаем скорость
        }
    }

    public void dvigKstop(int a, int b)//Останавливаем персонажа, скорости по x и y, либо придаем скорость
    {
        if (GetComponent<Hero>().Pol != null || GetComponent<Hero>().Lestnica != null || GetComponent<Hero>().PolP != null)//Если стот на полу или лестнице
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(a, b);
        }
        if (GetComponent<Hero>().Lestnica != null)//Если стит на лестнице
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(a, b);
        }
       // if(GetComponent<Hero>().PolP != null)
      //  {
       //     GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
       // }
    }

    public void VverhLect(int Napr)//Движение по лестнице, 1 - вверх, (-1) - вниз
    {
        if (GetComponent<Hero>().Lestnica != null)//Если персонаж на лестнице
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 200 * Napr);
        }
    }
    public void FierFei()//Выстрел
    {
        GameObject Pull = GTY.WaipoinsPull;
        GameObject WaipoinsFire = WaipoinsOpr(Pull);
        GameObject Gun = transform.GetChild(0).GetChild(2).gameObject;
        WaipoinsFire.transform.position = Gun.transform.position;
        WaipoinsFire.transform.rotation = Gun.transform.rotation;
        WaiponsAll WA = WaipoinsFire.GetComponent<WaiponsAll>();
        //Расчеты напраления вектора
        Vector3 ASD = Camera.main.ScreenToWorldPoint(Input.mousePosition);//Положение мыши в мировых координатах
        
        //Передаем информацию в патрон
        WA.XYZ = new Vector2(ASD.x - Gun.transform.position.x, ASD.y - Gun.transform.position.y);
        WA.NachDlina = Mathf.Abs(WA.XYZ.magnitude - WaipoinsFire.transform.position.magnitude);
        WA.Dalnost = 1000;
        WA.speedW = 30000;
        WaipoinsFire.SetActive(true);
       // Debug.Log(WaipoinsFire);
    }
     GameObject WaipoinsOpr(GameObject Pull )//Определяем патрон
    {
        GameObject PullPr = null;
        int a = 0;
        while(a != Pull.transform.childCount)
        {
            if (Pull.transform.GetChild(a).gameObject.activeSelf == false)
            {
                PullPr = Pull.transform.GetChild(a).gameObject;
                a = Pull.transform.childCount;
            }
            else
            {
                a = a + 1;
            }
        }
        return PullPr;
    }
   
	// Update is called once per frame
	void Update () {
        if(GetComponent<Hero>().Lestnica == null)//Костыль, чтоб с лестнице не скатываться
        {
            GetComponent<Rigidbody2D>().isKinematic = false;//Отключаем гравитацию
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FierFei();
        }
	}
}
