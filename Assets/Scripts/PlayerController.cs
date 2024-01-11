using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private static int point;
    private static int highestPoint;
    private Animator anim;
    [SerializeField] private float velocity;
    private GameController gameController;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        gameController = GetComponent<GameController>();
        highestPoint = point = 0;
    }

    // Update is called once per frame
    private void Update()
    {

    }

    // jumping
    public void Jumping() {
        rb.velocity = Vector2.up * velocity;
        anim.SetBool("isClicked", true);
    }

    // finish game
    private void OnCollisionEnter2D(Collision2D collision) {
        gameController.setGameState(GameState.End);
    }

    // point
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "PipeScore") {
            point++;
            highestPoint = Mathf.Max(highestPoint, point);
        }
    }

    public static void resetPoint() {
        point = 0;
    }    

    public static int getPoint() {
        return point;
    }

    public static int getHighestPoint() {
        return highestPoint;
    }
    // animation
    public void setIsClicked(bool val) {
        anim.SetBool("isClicked", val);
    }

}
