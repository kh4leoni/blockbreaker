using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Block : MonoBehaviour

{


  [SerializeField] AudioClip breakSound;
  [SerializeField] GameObject explosionVFX;
  [SerializeField] Sprite[] hitSprites;


  [SerializeField] int timesHit; //serialized for debug

  Level level;
  GameStatus gameStatus;

  private void Start()
  {
    CountingBlocks();
    gameStatus = FindObjectOfType<GameStatus>();

  }

  private void CountingBlocks()
  {
    level = FindObjectOfType<Level>();
    if (tag == "Breakable")
    {

      level.CountBreakableBlocks();
    }
  }


  private void OnCollisionEnter2D(Collision2D other)
  {
    if (tag == "Breakable")
    {
      HandleTheHit();
    }
  }



  private void HandleTheHit()
  {
    timesHit++;
    int maxHits = hitSprites.Length;

    if (timesHit >= maxHits)
    {
      DestroyBlock();
    }
    else
    {
      ShowNextSprite();
    }

  }

  private void DestroyBlock()
  {
    GameObject explosion = Instantiate(explosionVFX, transform.position, Quaternion.identity);
    Destroy(explosion, 2f);
    gameStatus.AddToScore();
    AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    level.BlockDestroyed();
    Destroy(gameObject);


  }

  private void ShowNextSprite()
  {
    int spriteIndex = timesHit - 1;
    if (hitSprites[spriteIndex] != null)
    {
      GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }
    else
    {
      Debug.LogError("Block sprite is missing." + gameObject.name);

    }

  }
}
