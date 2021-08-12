/*
Nombre del desarrollador: Emilio Ceballos Castro
Asignatura: Programación Orientada a Objetos
Fuente en la que se basa el scripts: Canal de Youtube Pandemonium games
Descripción general: Script creado para manejar la representacion grafica de la barra de vida
del personaje en pantalla
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthbar;
    [SerializeField] private Image currenthealthbar;
    
    private void Start() 
    {
        //El fillAmount es usado para rellenar una cierta cantidad de la barra de vida
        totalhealthbar.fillAmount = playerHealth.currentHealth/10;
    }

    private void Update() 
    {
        currenthealthbar.fillAmount = playerHealth.currentHealth/10;
    }
}
