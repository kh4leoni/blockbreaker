using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Ball : MonoBehaviour
{
  //config params
  [SerializeField] Paddle paddle1;
  [SerializeField] float xPush = 2f;
  [SerializeField] float yPush = 15f;
  [SerializeField] AudioClip[] ballSounds;
  [SerializeField] float randomFactor = 0.2f;

  Vector2 paddleToBallVector;
  bool ballLaunched = false;

  AudioSource myAudioSource;
  Rigidbody2D myRigidBody;

  // Start is called before the first frame update

  void Start()
  {

    paddleToBallVector = transform.position - paddle1.transform.position;
    myAudioSource = GetComponent<AudioSource>();
    myRigidBody = GetComponent<Rigidbody2D>();

  }

  // Update is called once per frame
  void Update()
  {

    if (!ballLaunched)
    {
      LockBallToPaddle();
      LaunchOnClick();
    }
  }

  private void LaunchOnClick()
  {
    if (Input.GetMouseButtonDown(0))
    {
      ballLaunched = true;
      myRigidBody.velocity = new Vector2(xPush, yPush);


    }
  }

  private void LockBallToPaddle()
  {
    Vector2 paddlePosition = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
    transform.position = paddlePosition + paddleToBallVector;

  }

  private void OnCollisionEnter2D(Collision2D other) {

    Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f, randomFactor), UnityEngine.Random.Range(0f, randomFactor));
    
    if (ballLaunched) {


    AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];    
     myAudioSource.PlayOneShot(clip);
     myRigidBody.velocity += velocityTweak;
     
    }
    
}
}
