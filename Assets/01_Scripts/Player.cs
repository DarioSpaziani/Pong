using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 5;
    public int score = 10;
    public Rigidbody rb;
    public float currentVelocity = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = this.AddComponent<Rigidbody>();
        }

        rb.useGravity = false;

    }
}
