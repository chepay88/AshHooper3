using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class BuildTextAll : MonoBehaviour {
	[Header("Сюда кидаем спрайт")]
	public GameObject GOBuild;//Го которое создаем
	[Header("Сюда ставим количество повторений")]
	public int KolVo;//Количество объектов
	[Header("Сюда начальные координаты первого объекта")]
	public Vector2 NachKoord;//Начальные координаты первого объекта
	[Header("Выбираем по каким осям будет смещение")]
	public bool SmeshKoordinatX;//Смещение по осямX
	public bool SmeshKoordinatY;//Смещение по осямY
	// Use this for initialization
	void Start () {
		//GOBuild.transform
		CreateObjects ();
	}
	void CreateObjects()
	{
		if (transform.childCount == 0) {
			RR (KolVo, NachKoord);
		} else {
			if(KolVo - transform.childCount > 0){
				RR(KolVo,NachKoord);
			}
			//if(KolVo - transform.childCount < 0){
				//for(int i1 =Mathf.Abs(KolVo - transform.childCount-1); i1 > 0; i1--){
				//	Destroy(transform.GetChild(transform.childCount-i1).gameObject);
				//}
			//}
			//RR(KolVo - transform.childCount,
		}
	}
	void RR(int i2, Vector3 NachKoordS)
	{
		for (int i1 = transform.childCount; i1 < i2; i1++) {
			GameObject GO = Instantiate (GOBuild, new Vector3 (NachKoordS.x, NachKoordS.y, 0), transform.rotation) as GameObject;
			Vector3 SDize = GO.GetComponent<SpriteRenderer> ().bounds.size;
			Vector2 Sizef = new Vector2 (0, 0);
			if (SmeshKoordinatX == true) {
				Sizef.x = SDize.x;
			}
			if (SmeshKoordinatY == true) {
				Sizef.y = SDize.y;
			}
			GO.transform.position = new Vector3 (GO.transform.position.x + Sizef.x * i1, GO.transform.position.y + Sizef.y * i1, 0);
			GO.transform.SetParent (this.transform);
		}
	}
	

// Update is called once per frame
void Update () {
	
}
}
