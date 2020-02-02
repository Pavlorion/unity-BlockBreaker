using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{

    [Range (0.1f,2f)] [SerializeField] float timespeed = 1;
    [SerializeField] TextMeshProUGUI scoreText;
    SceneLoader sceneloader;

    [SerializeField] int currentScore = 0;
    int addedScore = 35;

    private void Awake()
    {
        int gamestatus = FindObjectsOfType<GameSession>().Length;
        if(gamestatus > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
        

    }
    // Start is called before the first frame update
    void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timespeed;
    }

    public void AddToScore()
    {
        currentScore = currentScore + addedScore;
        scoreText.text = currentScore.ToString();
    }

    public void RestartScore()
    {
        Destroy(gameObject);
    }
}
