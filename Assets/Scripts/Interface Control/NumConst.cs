using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumConst : MonoBehaviour
{
    int contItems;
    int Score;
    int Life;

    public int[] numbers;

    public static int cId, cItems, cScore, cLife;

    public NumConst(int[] numbers)
    {
        this.contItems=numbers[0];
        this.Score=numbers[1];
        this.Life=numbers[2];
    }
}
