using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class DialogJ
{
    public string _personName;
    public int _numberPersons;
    public string _personDialog;
    public Texture _textureDialog;
}
[System.Serializable]
public struct PersonsO
{
    public string _personName;
    public Texture _textureDialog;
}
[ExecuteInEditMode]
public class ScenarioObjScript : MonoBehaviour
{
    [Header("Включение скрипта")]
    public bool _vklSkript;
    [Header("Инфа о персах(Имя, Текстура)")]
    public List<PersonsO> PersonsD = new List<PersonsO>();
    [Header("Диалог")]
    public List<DialogJ> DialogR = new List<DialogJ>();
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Raschet()
    {
        if(DialogR.Count > 0)
        {
            for(int i1 = 0; i1 < DialogR.Count; i1++)
            {
                if(DialogR[i1]._numberPersons < PersonsD.Count)
                {
                    DialogR[i1]._personName = PersonsD[DialogR[i1]._numberPersons]._personName;
                    DialogR[i1]._textureDialog = PersonsD[DialogR[i1]._numberPersons]._textureDialog;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Raschet();
    }
    private void FixedUpdate()
    {
        
    }

}
