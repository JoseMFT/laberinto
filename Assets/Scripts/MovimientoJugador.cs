using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public float movimientoEjeX;
    public float movimientoEjeY;
    public float movimientoEjeZ;

    public float velMovimiento = 2.3f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movimientoEjeX = Input.GetAxis("Horizontal") * Time.deltaTime * velMovimiento;
        movimientoEjeZ = Input.GetAxis("Vertical") * Time.deltaTime * velMovimiento;


        transform.Translate(movimientoEjeX, movimientoEjeY, movimientoEjeZ);
    }
}
