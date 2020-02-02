using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float velocityX = 2f;
    [SerializeField] float velocityY = 15f;
    [SerializeField] AudioClip[] audioclip;
    [SerializeField] float randomFactor = 1;

    AudioSource audiosource;
    Rigidbody2D myRigidBody2D;
    // Start is called before the first frame update
    Vector2 paddleToBallVector;
    bool hasStarted = false;
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        audiosource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted != true)
        {
            LockBalltoPaddle();
            LaunchMouseClick();
        }
    }

    private void LaunchMouseClick()
    {
        if (Input.GetMouseButton(0))
        {
            hasStarted = true;
            myRigidBody2D.velocity = new Vector2(velocityX, velocityY);
        }
    }

    private void LockBalltoPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));

        if (hasStarted == true)
        {

            AudioClip clip = audioclip[Random.Range(0,audioclip.Length)];
            audiosource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
    }
}
