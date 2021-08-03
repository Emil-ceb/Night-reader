using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntfMger : MonoBehaviour
{
    public Text[] textIntrfc;

    PlayerConstruct pC;

    void Start() 
    {
        pC=GetComponent<PlayerConstruct>();
        AsignValueArray();
    }

    void AsignValueArray()
    {
        for (int i = 0; i < textIntrfc.Length; i++)
        {
            textIntrfc[i].text=pC.numbers[i].ToString();
        }
    }
}
