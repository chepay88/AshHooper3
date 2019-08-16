using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RukaPersons : MonoBehaviour
{
    public GameObject RukaUIInfo;// Ссылка на иконку оружия
    public GameObject GT;
    GT GTY;
    // Start is called before the first frame update
    void Start()
    {
        GTY = GT.GetComponent<GT>();
        OtobragIkonGun();
        WaipoinsUIOtobr(transform.GetChild(0).gameObject, 0);
    }
    public void PerezarydMagaz()
    {
        GameObject Gun = transform.GetChild(0).gameObject;
        GunAll GAL = Gun.GetComponent<GunAll>();
        GAL.Magazin.x = GAL.Magazin.y;
        Debug.Log(GAL.Magazin);
        WaipoinsUIOtobr(Gun, 0);
    }
    void ZapisUIText(GameObject UIT, string TextU, Color Colp)//Метод отображения текста в UI
    {
        UIT.GetComponent<Text>().text = TextU;
        UIT.GetComponent<Text>().color = Colp;
    }
    public void StrikeGuns()//Выстрел из оружия
    {
        GameObject Gun = transform.GetChild(0).gameObject;
        GunAll GAL = Gun.GetComponent<GunAll>();
        if (GAL.Magazin.x - GAL.Ocher > -1)
        {
            GameObject WaipoinsFire = WaipoinsOpr(GTY.WaipoinsPull);
            WaipoinsFire.transform.position = Gun.transform.position;
            WaipoinsFire.transform.rotation = Gun.transform.rotation;
            WaipoinsFire.SetActive(true);
            WaipoinsUIOtobr(Gun, 1);
            WaiponsAll WA = WaipoinsFire.GetComponent<WaiponsAll>();
            //Расчеты напраления вектора
            Vector3 ASD = Camera.main.ScreenToWorldPoint(Input.mousePosition);//Положение мыши в мировых координатах
            //Передаем информацию в патрон
            WA.Nac = Gun.transform.position;
            WaipoinsFire.GetComponent<SpriteRenderer>().sortingOrder = transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder;
            WA.XYZ = new Vector2(ASD.x - Gun.transform.position.x, ASD.y - Gun.transform.position.y);
            WA.NachDlina = Mathf.Abs(WA.XYZ.magnitude - WaipoinsFire.transform.position.magnitude);
            WA.Dalnost = GAL.DalGun;
            WA.speedW = GAL.SpeedWaipoins;
            WaipoinsFire.SetActive(true);
        }
        //GTY.WaipoinsPull;
    }
    public void OtobragIkonGun()//Метод отображения оружия в UI
    {
        if (transform.parent.parent.tag == "Hero")
        {
            Vector2 XYS = transform.GetChild(0).GetChild(0).GetChild(0).localScale*50;
            XYS = new Vector2(XYS.x * 2, XYS.y * 2);
            Vector2 XY = new Vector2(XYS.x / 2 + 40, XYS.y / 2 + 40);
            RukaUIInfo.transform.GetChild(0).gameObject.GetComponent<RawImage>().texture = transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite.texture;
            RukaUIInfo.transform.transform.position = XY;
            RukaUIInfo.transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = XYS;
            ZapisUIText(RukaUIInfo.transform.GetChild(0).GetChild(1).gameObject, transform.GetChild(0).gameObject.GetComponent<GunAll>().NameGun, Color.red);
        }
    }
    public void WaipoinsUIOtobr(GameObject Gun, int WaipoinDelta)//Отображаем количество патронов
    {
        if (transform.parent.parent.tag == "Hero")
        {
            GunAll GA = Gun.GetComponent<GunAll>();
            if (GA.Magazin.x - WaipoinDelta > -1)
            {
                GA.Magazin.x = GA.Magazin.x - WaipoinDelta;
                ZapisUIText(RukaUIInfo.transform.GetChild(0).GetChild(0).gameObject, GA.Magazin.x + "/" + GA.Magazin.y, Color.blue);
            }
        }
    }
    GameObject WaipoinsOpr(GameObject Pull)//Определяем патрон которым будем стрелять в пуле
    {
        GameObject PullPr = null;
        int a = 0;
        while (a != Pull.transform.childCount)
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
    void Update()
    {
        
    }
}
