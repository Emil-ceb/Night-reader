using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBasic : MonoBehaviour
{
    private Vector3 startingPos;
    private void Start()
    {
        startingPos=transform.position;
    }

    private Vector3 GetRoamingPosition()
    {
        return startingPos + GetRandomDir()*Random.Range(10f,10f);
    } 
    
    //Direccion al azar
    public static Vector3 GetRandomDir()
    {
        return new Vector3(UnityEngine.Random.Range(-1f,1f),UnityEngine.Random.Range(-1f,1f)).normalized;
    }
}
