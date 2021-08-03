using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntfMger : MonoBehaviour
{
    public Text[] textIntrfc;

    NumConst nC;

    void Start() 
    {
        nC=GetComponent<NumConst>();
        AsignValueArray();
    }

    void AsignValueArray()
    {
        for (int i = 0; i < textIntrfc.Length; i++)
        {
            textIntrfc[i].text=nC.numbers[i].ToString();
        }
    }
}
