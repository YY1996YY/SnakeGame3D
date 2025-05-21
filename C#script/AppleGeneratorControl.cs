using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleGeneratorControl : MonoBehaviour
{
    public GameObject applePrefab;
    public Text scoreInPlay;
    public Text scoreGameOver;
    bool IsEaten;
    int score;
    AudioSource audioEatApple;
    // Start is called before the first frame update
    void Start()
    {
        IsEaten = true;
        int score = 0;
        audioEatApple = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreInPlay.text = score.ToString();
        if(GameObject.Find("Player").GetComponent<PlayerControl>().IsGameOver())
        {
            scoreGameOver.text = "Ç†Ç»ÇΩÇ™èWÇﬂÇΩÇËÇÒÇ≤ÇÕ"+score.ToString()+ "å¬ÅI";
        }

        if (IsEaten)
        {
            GameObject apple = Instantiate(applePrefab);
            float x = Random.Range(-5, 5) + 0.5f;
            float z = Random.Range(-5, 5) + 0.5f;
            apple.transform.position = new Vector3(x, 1, z);
            IsEaten = false;
        }
    }

    public void PlayerEatApple()
    {
        IsEaten=true;
        //GameObject.Find("Player").GetComponent<PlayerControl>().SpeedUp();
        score++;
        audioEatApple.Play();
    }

    public int GetScore()
    {
        return score;
    }
}
