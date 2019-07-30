using UnityEngine;
using System.Collections;

public class Knopki : MonoBehaviour
{
    public KeyCode RiteK;//Клавиша вправо
    public KeyCode LeftK;//Клавиша лево
    public KeyCode Up;//Прыжок
    public KeyCode Vverh;// Движение вверх по лестнице
    public KeyCode Niz;//Движение в низ
    public KeyCode Fire;//Стрельба, удар
    public KeyCode Perezaryd;//Клавиша перезарядки патронов

    GT GTQ;
    PersonsS PeRs;
    // Use this for initialization
    void Start()
    {
        GTQ = GetComponent<GT>();
        PeRs = GTQ.Hero.GetComponent<PersonsS>();
    }

    public void KlickArrRiet()//Метод Нажатие клавиши впрао
    {
        PeRs.RunPerson(1);
    }
    public void KlickArrLeft()//Метод Нажатие на клавишу вправо
    {
        PeRs.RunPerson(-1);
    }
    public void UpKeyKlick()//Метод отпускания клавиши влево или вправо
    {
        PeRs.RunStop();
    }
    public void DJumpKlicKey()//Метод прыжка
    {
        PeRs.VklDjump();
    }
    public void KlickArrVverh()//Метод нажатия клавиши вверх
    {
        PeRs.StepPersZ(1);
        PeRs.LestnicaUpDown(1);
    }
    public void KlickArrDown()//Метод нажатия клавиши вниз
    {
        PeRs.StepPersZ(-1);
        PeRs.SpuskVniz();
        PeRs.LestnicaUpDown(-1);
    }
    public void KlickArrVverhUp()//Метод отпускания клавиши вверх
    {
        PeRs.StepZStop();
        PeRs.LestnicaOff();
    }
    public void KlickArrDownUP()//Метод отпускания клавиш вниз
    {
        PeRs.StepZStop();
        PeRs.LestnicaOff();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(LeftK))//Непосредственное нажатие на клавишу влево
        {
            KlickArrLeft();
        }
        if (Input.GetKey(RiteK))//Непосредственное нажатие на клавишу вправо
        {
            KlickArrRiet();
        }
        if (Input.GetKeyUp(LeftK))//Непосредственно отпустили клавишу влево
        {
            UpKeyKlick();
        }
        if (Input.GetKeyUp(RiteK))//Непосредственно отпустили клавишу вправо
        {
            UpKeyKlick();
        }
        if (Input.GetKeyDown(Up))//Непосредственно нажали клавишу прыжка
        {
            DJumpKlicKey();
        }
        if (Input.GetKey(Vverh))//Непосредственное нажатие на клавишу вверх
        {
            KlickArrVverh();
        }
        if (Input.GetKey(Niz))//Непосредственное нажатие на клавишу вниз
        {
            KlickArrDown();
        }
        if (Input.GetKeyUp(Vverh))//Непосредственное отпускание клавиши вверх
        {
            KlickArrVverhUp();
        }
        if (Input.GetKeyUp(Niz))//Непосредственно отпустили клавишу вниз
        {
            KlickArrDownUP();
        }
        if (Input.GetKeyDown(Fire))
        {
            // GTQ.Hero.transform.GetChild(0).GetChild(4).gameObject.GetComponent<RukaPersons>().StrikeGuns();
        }
        if (Input.GetKeyDown(Perezaryd))
        {
            GTQ.Hero.transform.GetChild(0).GetChild(4).gameObject.GetComponent<RukaPersons>().PerezarydMagaz();
        }
    }
}
