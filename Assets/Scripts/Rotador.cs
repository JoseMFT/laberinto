using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotador : MonoBehaviour
{
    [SerializeField]
    float velRotacion = 130f;
    
    void Update() {
        transform.Rotate(0.0f, velRotacion * Time.deltaTime, 0f);
               
    }
}
