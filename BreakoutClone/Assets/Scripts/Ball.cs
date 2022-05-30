using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float speed = 20f; // private can be denoted by _ before name, i.e. _speed
    private Rigidbody rigidbody;
    private Vector3 velocity;
    public Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        renderer = GetComponent<Renderer>();
        Invoke("Launch", 0.5f);
    }

    void Launch()
    {
        rigidbody.velocity = Vector3.up * speed;

    }

    // FixedUpdate is called once per physics update - 100Hz
    void FixedUpdate()
    {
        rigidbody.velocity = rigidbody.velocity.normalized * speed;
        velocity = rigidbody.velocity;

        if (!renderer.isVisible)
        {
            GameManager.Instance.Balls--;
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        rigidbody.velocity = Vector3.Reflect(velocity, collision.contacts[0].normal);
    }
}
