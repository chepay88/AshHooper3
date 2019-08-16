using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class LayerDelta : MonoBehaviour {

	public int LayerIz;//Слой, который меняем
	public int LayerX;// Слой, на который меняем
	public bool ON;//Включение скрипта
	// Use this for initialization
	void Start () {
		if (ON == true) {
			LayerOn ();
		}
	}
	void LayerOn(){
        for (int i1 = transform.childCount - 1; i1 > -1; i1--)
        {
            if (transform.GetChild(i1).gameObject.GetComponent<SpriteRenderer>())
            {
                IzmL(transform.GetChild(i1).gameObject.GetComponent<SpriteRenderer>());
            }
        }
	}
	void IzmL(SpriteRenderer SR){
		if (LayerIz != 0 && SR.sortingOrder == LayerIz) {
			SR.sortingOrder = LayerX;
		}
		if (LayerIz == 0) {
			SR.sortingOrder = LayerX;
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
