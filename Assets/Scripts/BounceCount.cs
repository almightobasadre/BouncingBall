using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceCounter : MonoBehaviour
{
    public float bounceCooldown = 0.5f; // Cooldown time between bounces
    public AudioSource bounceSound; // Drag and drop the AudioSource from your ball GameObject

    private float lastBounceTime;
    private int bounceCount = 0;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastBounceTime = Time.time;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") && (Time.time - lastBounceTime) > bounceCooldown)
        {
            bounceCount++;
            Debug.Log("Bounce Count: " + bounceCount);
            lastBounceTime = Time.time;

            // Play the bounce sound
            bounceSound.Play();
        }
    }
}

