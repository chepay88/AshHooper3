using UnityEngine;
using UnityEngine.Animations;
using System.Collections;

public class GT : MonoBehaviour {
    public GameObject Hero;//ссылка на го героя
    public GameObject Hero1;//ссылка на го героя
    public GameObject WaipoinsPull;// Ссылка на пул патронов и снарядов
    public int WaipoinsPullKol;//Количество снарядов в пулле
    public GameObject DialogPole;//Диалоговое поле
    public GameObject HelfBarUI;//ССылка на хелфбар героя
    public Event Run;
    public Animator gh;
	// Use this for initialization
	void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.L))
        {
            gh.Play("Walk");
        }
	}
}
