using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip blocksound;
    [SerializeField] GameObject particleEffect;
    [SerializeField] int timesHit;
    [SerializeField] Sprite[] hitSprite;
    Level level;
    GameSession score;

    private void Start()
    {
        CountBrealableBlocks();
    }

    private void CountBrealableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            int maxHit = hitSprite.Length + 1;
            timesHit++;
            if (timesHit >= maxHit)
            {
                DestroyBlock();
            } else
            {
                ShowNextSprite();
            }
        }
        AudioSource.PlayClipAtPoint(blocksound, Camera.main.transform.position, 0.36f);

    }

    private void ShowNextSprite()
    {
        
        int spriteIndex = timesHit - 1;
        if (hitSprite[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprite[spriteIndex];
        } else
        {
            Debug.LogError("Sprite in an array is missing" + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        score = FindObjectOfType<GameSession>();
        score.AddToScore();
        level.CountLeftBlocks();
        TriggerParticle();
        Destroy(gameObject);
        
        //Debug.Log(collision.gameObject.name);
    }

    private void TriggerParticle()
    {
        GameObject sparkles = Instantiate(particleEffect, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
    
}
