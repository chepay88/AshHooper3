﻿using UnityEngine;
using System.Collections;

public class StartDekor : MonoBehaviour {
    public GameObject Desk1;
    public GameObject Waipoins;
	// Use this for initialization
	void Start () {
        //Desk1.transform.position = new Vector3(500, 20, 0);
        CreateWaiponsPuul();
	}
	
    void CreateWaiponsPuul()
    {
        GT GTY = GetComponent<GT>();
        GameObject Pull = GTY.WaipoinsPull;
        for(int i1 = GTY.WaipoinsPullKol; i1 > 0; i1--)
        {
            GameObject HG = Instantiate(Waipoins, transform.position, transform.rotation) as GameObject;
            HG.transform.SetParent(Pull.transform);
            HG.gameObject.layer = 12;
            HG.name = "L" + i1;
        }
    }
	// Update is called once per frame
	void Update () {
       // Debug.Log(Desk1.transform.position);
	}
}
