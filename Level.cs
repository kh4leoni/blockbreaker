using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    
    [SerializeField] int breakableBlocks;
    SceneLoader sceneloader;

    // Start is called before the first frame update
    void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }

     public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            StartCoroutine(NextLevelAfterWait());
            FindObjectOfType<GameStatus>().IncreaseGameSpeed();
            
        }
    }

    IEnumerator NextLevelAfterWait() {
        yield return new WaitForSeconds(0.3f);
        sceneloader.LoadNextScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
