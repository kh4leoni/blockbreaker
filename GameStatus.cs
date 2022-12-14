using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
     [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
     [SerializeField] int pointsPerBlockDestroyed = 86;
     [SerializeField] TextMeshProUGUI scoreText;
     [SerializeField] float increaseGameSpeedPerLevel = 0.25f;
     [SerializeField] bool isAutoPlayEnabled;

     [SerializeField] int currentScore = 0;
    // Start is called before the first frame update

    private void Awake() {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        
        if (gameStatusCount > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;

        
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed; 
        scoreText.text = currentScore.ToString();
        
    }

    public void IncreaseGameSpeed()
    {
        gameSpeed += increaseGameSpeedPerLevel;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

   public bool IsAutoPlayEnabled() 
   {
    return isAutoPlayEnabled;
   }
}
