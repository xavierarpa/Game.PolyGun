﻿#region Imports
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion
[RequireComponent(typeof(Shot))] //para cuando puede disparar...
[RequireComponent(typeof(Equipment))]
/// <summary>
/// Este recoge los fragmentos y mejoras más cercanos,
/// - sus ataques son de corto rango
/// - se encarga de crear figuras o mejoras al conseguir 3 fragmentos,
/// - atacará a los enemigos débilmente.
/// </summary>
public class PolController : Minion
{
    #region
    //[Header("Pol Settings")]


    //cuando se vuelve true puede atacar cuando quiera, puesto que tiene el perseguir bala
    private bool canAttackInDistance = false;
    #endregion
    #region
    private void Start()
    {
        LoadMinion();

        //TODO ajustar el rango de cogida de items con char.range

        //TODO el Pol SIEMPRE ataca al enemigo sin importar su rango, puesto que este se rige por comsas como boxbox

    }
    private void Update()
    {
        if (UpdateMinion())
        {

            bool modoDeAtaque=false;
            if (modoDeAtaque)
            {
                //CaC
            }
            else
            {
                //Rango
            }



            bool modoTarget = false;
            if (modoTarget)
            {
                //Buscas un item (prioridad)
            }
            else
            {
                //Buscas un enemigo (estos deben de estar MUY cerca)
            }


            ///Moverse a un item, moverse a un enemigo cercano
            Vector3 moverse;

            //mirar a un Item, mirar a el enemigo mas cercano
            Quaternion rotart;


            //siempre que peuda
            bool estoyCercaDelItem = false;
            if (estoyCercaDelItem)
            {
                //coge el item
            }




            bool tengoBuffs = false;    
            if (tengoBuffs)
            {
                //cambia cosas para conveniencia del Pol
            }

        }
    }
    #endregion
    #region 




    #endregion
}
/*
 * TODO
 * 
 * - buscar item o atacar (prioridad a conseguir 3 items, luego pelear)(revisar esto en caso de buffos y eso..)
 * - 
 * 
 */