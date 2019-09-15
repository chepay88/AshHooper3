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
    public KeyCode Program1;//Вспомогательная кнопка.

    GT GTQ;
   // PersonsS PeRs;
    ControlPerson CP;
    // Use this for initialization
    void Start()
    {
        GTQ = GetComponent<GT>();
        CP = GTQ.Hero1.GetComponent<ControlPerson>();
        //PeRs = GTQ.Hero.GetComponent<PersonsS>();
    }
    public void KlickProgram1()//Метод нажатия на клавишу программ
    {
        CP.PersonsToStart();
    }

    public void KlickArrRiet()//Метод Нажатие клавиши впрао
    {
        CP.MovementPersonsX(1);
        //PeRs.RunPerson(1);
    }
    public void KlickArrLeft()//Метод Нажатие на клавишу вправо
    {
        CP.MovementPersonsX(-1);
       // PeRs.RunPerson(-1);
    }
    public void UpKeyKlick()//Метод отпускания клавиши влево или вправо
    {
        CP.StopMovementPersonsX();
        //PeRs.RunStop();
    }
    public void DJumpKlicKey()//Метод прыжка
    {
        CP.JumpStart();
       // PeRs.VklDjump();
    }
    public void KlickArrVverh()//Метод нажатия клавиши вверх
    {
        CP.MovementPersonsZ(1);
       // PeRs.StepPersZ(1);
        //PeRs.LestnicaUpDown(1);
    }
    public void KlickArrDown()//Метод нажатия клавиши вниз
    {
        CP.MovementPersonsZ(-1);
        // PeRs.StepPersZ(-1);
        // PeRs.SpuskVniz();
        // PeRs.LestnicaUpDown(-1);
    }
    public void KlickArrVverhUp()//Метод отпускания клавиши вверх
    {
        CP.StopMovementPersonsZ();
       // PeRs.StepZStop();
        //PeRs.LestnicaOff();
    }
    public void KlickArrDownUP()//Метод отпускания клавиш вниз
    {
        CP.StopMovementPersonsZ();
        //PeRs.StepZStop();
        //PeRs.LestnicaOff();
    }
    public void KlickMouse0()//Метод нажатия левой клавиши мыши
    {
        GTQ.Hero.transform.GetChild(0).GetChild(0).gameObject.GetComponent<RukaPersons>().StrikeGuns(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
    // Update is called once per frame

    void Update()
   
    {
        if (Input.GetKeyDown(Program1))
        {
            KlickProgram1();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            KlickMouse0();
        }
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
            GTQ.Hero.transform.GetChild(0).GetChild(0).gameObject.GetComponent<RukaPersons>().PerezarydMagaz();
        }
    }
}
