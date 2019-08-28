using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerPersControl : MonoBehaviour
{
    public GameObject _torso;//Торс героя
    public GameObject _lArm;//левая рука
    public GameObject _rArm;//правая рука
    public GameObject _lLeg;//левая нога
    public GameObject _rLeg;//правая нога
    public GameObject _lArmpit;//левая подмышка
    public GameObject _rArmpit;//правая подмышка
    public GameObject _shadow;//Тень
    PhisicsAll PeS;

    // Start is called before the first frame update
    void Start()
    {
        PeS = GetComponent<PhisicsAll>();//Кеш
    }
    void LayerDefinition()
    {
        if (PeS.NPol != null)
        {
            float MinY;
            float MaxY;
            if (PeS.NPol.GetComponent<BoxCollider2D>())
            {
                MaxY = PeS.NPol.transform.position.y + PeS.NPol.GetComponent<BoxCollider2D>().size.y / 2;
                MinY = PeS.NPol.transform.position.y - PeS.NPol.GetComponent<BoxCollider2D>().size.y / 2;
                float qt = (PeS.NPol.transform.position.y - transform.position.y) / PeS.NPol.GetComponent<BoxCollider2D>().size.y * 100;
                SetLayer(Mathf.Floor(Mathf.Lerp(PeS.NPol.GetComponent<LayerPolPhis>().LayerMin, PeS.NPol.GetComponent<LayerPolPhis>().LayerMax, 1 - Mathf.Abs(qt / 100))));
            }
        }
       
    }
    void SetLayer(float LayerAll)
    {
        int LeftRite = 1;
        SetLayerQ(_torso, LayerAll);
        SetLayerQ(_lArm, LayerAll + 2 * LeftRite);
        SetLayerQ(_rArm, LayerAll - 2 * LeftRite);
        SetLayerQ(_lLeg, LayerAll + 1 * LeftRite);
        SetLayerQ(_rLeg, LayerAll - 1 * LeftRite);
        SetLayerQ(_rArmpit, LayerAll - 1 * LeftRite);
        SetLayerQ(_lArmpit, LayerAll + 1 * LeftRite);
        SetLayerQ(_shadow, LayerAll);
        PeS.LayerPers = LayerAll;
    }
    void SetLayerQ(GameObject A, float C)
    {
        if (A != null)
        {
            if (A.GetComponent<SpriteRenderer>())
            {
                A.GetComponent<SpriteRenderer>().sortingOrder = int.Parse(C.ToString());
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        LayerDefinition();
    }
}
