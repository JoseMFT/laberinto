using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador: MonoBehaviour {
    public float movimientoEjeX;
    public float movimientoEjeY;
    public float movimientoEjeZ;
    public float velMovimiento = 2.3f;

    // Update is called once per frame
    void Update() {
        movimientoEjeX = Input.GetAxis("Horizontal") * Time.deltaTime * velMovimiento;
        movimientoEjeZ = Input.GetAxis("Vertical") * Time.deltaTime * velMovimiento;
        transform.Translate(movimientoEjeX, movimientoEjeY, movimientoEjeZ);
    }
        private class MovimientoInvertido: MonoBehaviour {
        bool choqueConInvertido = false;
        double tiempoInvertido = 5d;

        void OnCollisionEnter(Collision choque) {

            if (choqueConInvertido == true) {
                movimientoEjeX = -Input.GetAxis("Horizontal") * Time.deltaTime * velMovimiento;
                movimientoEjeZ = -Input.GetAxis("Vertical") * Time.deltaTime * velMovimiento;
                tiempoInvertido = tiempoInvertido - Time.deltaTime;

                if (tiempoInvertido < 0.0d) {
                    choqueConInvertido = false;
                    tiempoInvertido = 5.0d;
                }
            }

            if (choque.gameObject.tag == "a rellenar") {
                choqueConInvertido = true;
            }
        }
    }
}
