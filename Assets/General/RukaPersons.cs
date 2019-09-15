using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RukaPersons : MonoBehaviour
{
    public GameObject RukaUIInfo;// Ссылка на иконку оружия
    GameObject GT;
    GT GTY;
    GameObject Gun;
    GunAll GAL;
    GameObject _parentP;//Первый объект в персонаже
    // Start is called before the first frame update
    void Start()
    {
        _parentP = transform.parent.parent.parent.gameObject;
        GT = _parentP.GetComponent<ControlPerson>().GT;
        GTY = GT.GetComponent<GT>();
        OtobragIkonGun();
        WaipoinsUIOtobr(transform.GetChild(0).gameObject, 0);
        Gun = transform.GetChild(0).gameObject;
        GAL = Gun.GetComponent<GunAll>();
        
    }
    public void PerezarydMagaz()
    {
        GAL.Magazin.x = GAL.Magazin.y;
        WaipoinsUIOtobr(Gun, 0);
        GAL._deltaTime = 0;
    }
    void ZapisUIText(GameObject UIT, string TextU, Color Colp)//Метод отображения текста в UI
    {
        UIT.GetComponent<Text>().text = TextU;
        UIT.GetComponent<Text>().color = Colp;
    }
    public void StrikeGuns(Vector2 ASD)//Выстрел из оружия
    {
        if (GAL._deltaTime == 0 || Time.time - GAL._deltaTime > GAL.TimeZaderj)
        {
            if (GAL.Magazin.x - GAL.Ocher > -1)
            {
                GameObject WaipoinsFire = WaipoinsOpr(GTY.WaipoinsPull);
                WaipoinsFire.transform.position = Gun.transform.position;
                WaipoinsFire.transform.rotation = Gun.transform.rotation;
                WaipoinsFire.SetActive(true);
                WaipoinsUIOtobr(Gun, 1);
                WaiponsAll WA = WaipoinsFire.GetComponent<WaiponsAll>();
                GAL._deltaTime = Time.time;
                //Расчеты напраления вектора
                //Передаем информацию в патрон
                if (_parentP.tag == "Hero")
                {
                    WaipoinsFire.layer = 14;
                }
                else
                {
                    WaipoinsFire.layer = 15;
                }
                WA.Nac = Gun.transform.position;
                WaipoinsFire.GetComponent<SpriteRenderer>().sortingOrder = transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<SpriteRenderer>().sortingOrder;//Слой 
                WA.XYZ = new Vector2(ASD.x - Gun.transform.position.x, ASD.y - Gun.transform.position.y);
                WA.NachDlina = Mathf.Abs(WA.XYZ.magnitude - WaipoinsFire.transform.position.magnitude);
                WA.Dalnost = GAL.DalGun;//Дальность полета пули
                WA.speedW = GAL.SpeedWaipoins;//Скорость полета пули
                WA.DamageW.x = GAL.AttakStiAttak.x;//Урон от пули
                WaipoinsFire.SetActive(true);//Включение пули
            }
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
        GunAll GA = Gun.GetComponent<GunAll>();
        GA.Magazin.x = GA.Magazin.x - WaipoinDelta;
        if (transform.parent.parent.tag == "Hero")
        {
            if (GA.Magazin.x - WaipoinDelta > -1)
            {       
                ZapisUIText(RukaUIInfo.transform.GetChild(0).GetChild(0).gameObject, GA.Magazin.x + "/" + GA.Magazin.y, Color.blue);
            }
        }
    }
    public  GameObject WaipoinsOpr(GameObject Pull)//Определяем патрон которым будем стрелять в пуле
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
                if(a == Pull.transform.childCount-1)
                {
                    PullPr = Instantiate(Pull.transform.GetChild(0).gameObject, Pull.transform.position, Pull.transform.rotation, Pull.transform) as GameObject;
                    PullPr.name = "L" + a;
                    a = Pull.transform.childCount;
                }
            }
        }
        return PullPr;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
