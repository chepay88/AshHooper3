using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPerson : MonoBehaviour
{
    public Texture BJ;
    //Управление персонажем
    public GameObject GT;//Ссылка на General
    GameObject PersonS;
    Rigidbody2D RG2;
    PhisicsAll PA;
    ParametrPersons PP;
    // Start is called before the first frame update

    void Start()
    {
        PersonS = transform.GetChild(0).gameObject;
        RG2 = PersonS.GetComponent<Rigidbody2D>();
        PA = GetComponent<PhisicsAll>();
        PP = GetComponent<ParametrPersons>();
        DeltaHalf(0);
    }
    void DialogDefinition()//Определяем что стоим на объеке сценария
    {
        if(PA.Dialog != null && PA.Dialog.GetComponent<ScenarioObjScript>()._vklSkript == true)
        {
            GT.GetComponent<GT>().DialogPole.GetComponent<UIDialogPersonsPolo>().DialogScenario = PA.Dialog;
        }
    }
    public void PersonsToStart()//Возвращаем персонажа, если он откуда-нибудь упал
    {
        PersonS.transform.position = PA.LostPos;
    }
    public void MovementPersonsZ(float Napr)//Передвижение персонажа оси Z
    {
        if(PA.NPol != null && PA._freeFall == false)
        {
            float _speedP = 0;
            if ((Mathf.Abs(PP._speedP.y) + Mathf.Abs(RG2.velocity.y)) <= PP._speedP.w)
            {
                _speedP = (Mathf.Abs(PP._speedP.y) + Mathf.Abs(RG2.velocity.y)) * Napr;
            }
            else
            {
                _speedP = PP._speedP.w * Napr;
            }
            RG2.velocity = new Vector2(RG2.velocity.x, _speedP);
        }
    }
    public void MovementPersonsX(float Napr)//Передвиение персонажа по оси X
    {
        if(PA.NPol != null)
        {
            float _speedP = 0;
            if ((Mathf.Abs(PP._speedP.x) + Mathf.Abs(RG2.velocity.x)) <= PP._speedP.z)
            {
                _speedP = (Mathf.Abs(PP._speedP.x) + Mathf.Abs(RG2.velocity.x)) * Napr*DirectionPersons(Napr, PA._direction);
            }
            else
            {
                _speedP = PP._speedP.z * Napr * DirectionPersons(Napr, PA._direction);
            }
            RG2.velocity = new Vector2(_speedP, RG2.velocity.y);
        }
    }
    public void StopMovementPersonsZ()//Остановка по оси Z
    {
        if (PA.NPol != null)
        {
            RG2.velocity = new Vector2(RG2.velocity.x, 0);
        }
    }
    public void StopMovementPersonsX()//Остановка по оси X
    {
        RG2.velocity = new Vector2(0, RG2.velocity.y);
    }
    public void JumpStart()//Начинаем прыжок
    {
        if (PA.NPol != null && PA.NPol == PA.NPol2)
        {
            PA.TakeOfftheGround();
        }
        if(PA.NPol == PA.NPol1 && PA.Perehod == 1)
        {
            GT.GetComponent<GT>().DialogPole.GetComponent<UIDialogPersonsPolo>().TextDialog("BJ","Тебе мама не говорила, что не стоит беситься на лестнице?", BJ);
        }
    }
    public void JumpBegin()//Сам прыжок
    {
        if (this.gameObject.layer == 12)
        {
            if (Mathf.Abs(PersonS.transform.position.y - PA.LostPos.y) < PP.JumpSpeed.y)
            {
                //print(PersonS.transform.position.y + " - "  + PA.LostPos.y + " = " + (PersonS.transform.position.y - PA.LostPos.y) +  " < " + PP.JumpSpeed.y);
                RG2.velocity = new Vector2(PA._velocity.x, RG2.velocity.y + PP.JumpSpeed.x);
               // print(RG2.velocity);
            }
            else
            {
                PA._takeOfftheGround = false;
                RG2.velocity = new Vector2(PA._velocity.x, RG2.velocity.y + PP.JumpSpeed.x*-1);
            }
        }
    }
    public void DeltaHalf(float _deltaHalf)//Изменяем здоровье(если положительное значение - лечит)
    {
        PP._helfPers = PP._helfPers + _deltaHalf;
        if(gameObject.tag == "Hero")
        {
            GT.GetComponent<GT>().HelfBarUI.transform.GetChild(0).gameObject.GetComponent<Text>().text = PP._helfPers.ToString();
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        JumpBegin();
    }
    void Update()
    {
        //JumpBegin();
        DialogDefinition();
    }
    //Вспомогательные функции и методы
    float DirectionPersons(float Napr, bool _directionP)//определяем множитель для направления шага
    {
        float a = 1; 
        if(Napr > 0 && _directionP == true || Napr < 0 && _directionP == false)
        {
            a = 1;
        }
        if (Napr > 0 && _directionP == false || Napr < 0 && _directionP == true)
        {
            a = 0.7f;
        }
        return a;
    }
}

