using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int hits = 1;
    public int points = 100;
    public Vector3 rotator;
    public Material hitMaterial;

    private Material originalMaterial;
    private Renderer renderer;

    void Start()
    {
        transform.Rotate(rotator * (transform.position.x + transform.position.y) * 0.1f);
        renderer = GetComponent<Renderer>();
        originalMaterial = renderer.sharedMaterial;
    }

    void Update()
    {
        transform.Rotate(rotator * Time.deltaTime); // rotate at the same speed regardless of framerate
    }

    private void OnCollisionEnter(Collision collision)
    {
        hits--;
        if (hits <= 0)
        {
            GameManager.Instance.Score += points;
            Destroy(gameObject);
        }
        renderer.sharedMaterial = hitMaterial;
        Invoke("RestoreMaterial", 0.05f);
    }

    void RestoreMaterial()
    {
        renderer.sharedMaterial = originalMaterial;
    }
}
