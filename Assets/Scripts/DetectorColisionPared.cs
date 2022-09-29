using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectorColisionPared: MonoBehaviour {
    [SerializeField]
    Material colorMuros; // Se declara el color base para los muros
    [SerializeField]
    Material choqueMuros; // Se declara el color que adoptarán los muros al chocar con el jugador

    private bool colorChoque = false; // La variable colorChoque representa si el objeto debería cambiar de color o no
    double tiempoChoque = 0.5d; // tiempoChoque define por cuanto tiempo permanecerán los muros en su color alternativo

    private void Update() { // Update se ejecuta por cada frame de juego
        if (colorChoque == true) { // Si colorChoque pasa a ser verdadera
            tiempoChoque = tiempoChoque - Time.deltaTime; // tiempoChoque empieza a disminuir
            if (tiempoChoque < 0.0d) {  // Cuando tiempoChoque alcance el valor 0

                gameObject.GetComponent<MeshRenderer>().material = colorMuros; // El material volverá a ser el original
                colorChoque = false; // colorChoque será falso y este bloque dejará de ejecutarse
                tiempoChoque = 0.5d; // tiempoChoque vuelve a su valor original por si el jugador vuelve a hacer contacto con un muro
            }
        }
    }
    private void OnCollisionEnter(Collision choque) { // Este void se activará cuando el objeto en cuestión detecte una colisión

        if (choque.gameObject.tag == "Player") { // Si colisiona con un objeto de tag "Player" (solo aplicado al jugador):
            Debug.Log(choque.gameObject.name); // Aparecerá el nombre en la consola de aquello con lo que ha chocado
            gameObject.GetComponent<MeshRenderer>().material = choqueMuros; // El material pasará a ser el alternativo
            colorChoque = true; // colorChoque pasa a ser verdadera
        }
    }
}

