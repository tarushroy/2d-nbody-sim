using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour {

    public float mass;
    public float radius;
    public Vector2 velocity;

    public Rigidbody2D rb;

    public void UpdateVelocity(Body[] bodies, float timeStep) {
        foreach (var otherBody in bodies) {
            if (otherBody != this) {
                float dist = Mathf.Sqrt((otherBody.rb.position - rb.position).magnitude);
                Vector2 dir = (otherBody.rb.position - rb.position).normalized;
                Vector2 force = dir * Universe.G * mass * otherBody.mass / Mathf.Pow(dist, 2);
                Vector2 acc = force / mass;
                velocity += acc * timeStep;
            }
        }
    }

    public void UpdatePosition(float timeStep) {
        rb.position += velocity * timeStep;
    }
}
