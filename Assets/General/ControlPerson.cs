using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPerson : MonoBehaviour
{

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
        if(PA.NPol == PA.NPol1)
        {
            GT.GetComponent<GT>().DialogPole.GetComponent<UIDialogPersonsPolo>().TextDialog("Тебе мама не говорила, что не стоит беситься на лестнице?");
        }
    }
    public void JumpBegin()//Сам прыжок
    {
        if (this.gameObject.layer == 12)
        {
            if (PersonS.transform.position.y - PA.LostPos.y < PP.JumpSpeed.y)
            {
                RG2.velocity = new Vector2(PA._velocity.x, RG2.velocity.y + PP.JumpSpeed.x);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        JumpBegin();
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

