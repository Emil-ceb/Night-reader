using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConstruct : MonoBehaviour
{
    string charaName;
    int Id;
    int contItems;
    int Score;
    int Life;

    public int[] numbers;

    public static int cId, cItems, cScore, cLife;

    public PlayerConstruct(int[] numbers, string n)
    {
        this.Id=numbers[0];
        this.contItems=numbers[1];
        this.Score=numbers[2];
        this.Life=numbers[3];

        this.charaName=n;
    }
}
