﻿#region Imports
using UnityEngine;
#endregion
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoX
{
    #region Variables
    public float speed = 5f;
    private Vector3 axis = Vector3.zero;
    private Rigidbody body;
    #endregion
    #region Events
    private void Awake(){
        Get(out body);
    }
    #endregion
    #region Methods
    /// <summary>
    /// Asignamos el movimiento basado en la dirección que se movera
    /// y la velocidad que lo hará
    /// <para>
    /// En caso de no asignarle velocidad se establecerá la
    /// que tiene <see cref="Movement"/>
    /// </para>
    /// </summary>
    public void Move(Vector3 axis = default, float speed = default){
        if (speed == default) speed = this.speed;
        if (axis == default) axis = this.axis;
        body.velocity = new Vector3(axis.x, 0, axis.z) * speed;
    }
    /// <summary>
    /// Asignamos los axis del movimiento
    /// </summary>
    public void SetAxis(float x, float y, float z) => axis = new Vector3(x, y, z);


    #endregion
}