using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotador : MonoBehaviour {
    [SerializeField]
    public float velRotacion = 10f;

    void Update() {
        transform.Rotate(0.0f, Time.deltaTime * velRotacion, 0f);
    }
}