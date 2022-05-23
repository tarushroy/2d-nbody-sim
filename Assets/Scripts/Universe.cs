using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Universe : MonoBehaviour {

    public static float G = 0.001f;
    public float time;
    public float timeStep = 0.01f;

    Body[] bodies;

    void Start() {
        time = 0;
        Time.fixedDeltaTime = timeStep;
        bodies = FindObjectsOfType<Body>();
    }

    void FixedUpdate() {
        for(int i=0; i<bodies.Length; i++) {
            bodies[i].UpdateVelocity(bodies, timeStep);
        }

        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].UpdatePosition(timeStep);
        }

        time += timeStep;
    }
}
