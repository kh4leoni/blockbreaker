using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Paddle : MonoBehaviour
{
  [SerializeField] float screenWidthInUnits = 16f;

  float mousePositionMin = 1f;
  float mousePositionMax = 15f;

  GameStatus gameStatus;
  Ball ball;


  // Start is called before the first frame update
  void Start()
  {
    gameStatus = FindObjectOfType<GameStatus>();
    ball = FindObjectOfType<Ball>();
  }
  // Update is called once per frame
  void Update()
  {
    
    Vector2 paddlePosition = new Vector2(Mathf.Clamp(GetXPos(), mousePositionMin, mousePositionMax), transform.position.y);
    transform.position = paddlePosition;

  }

  private float GetXPos()
  {
    if (gameStatus.IsAutoPlayEnabled())
    {
      return ball.transform.position.x;
    }
    else
    {
      return Input.mousePosition.x / Screen.width * screenWidthInUnits;
    }
  }


}
