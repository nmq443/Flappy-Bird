using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] float velocity;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // moving pipe
    public void movingPipe() {
        // GetComponent<Rigidbody2D>().velocity = Vector2.left * velocity;
        //GetComponent<Rigidbody2D>().velocity = Vector2.left * velocity;
        rb.velocity = Vector2.left * velocity;
    }

    public void stopPipe() {
        rb.velocity = Vector2.zero;
    }

    // out of bound
    public bool outOfScreen() {
        return transform.position.x < -4;
    }
}
