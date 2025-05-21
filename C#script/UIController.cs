using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameOverImage;
    public GameObject gameTitleImage;
    public GameObject pressSpaceImage;

    bool IsGameOver;
    bool IsGameStart;
    void Start()
    {
        IsGameOver = false;
        IsGameStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGameOver)
        {
            if (gameOverImage.transform.localScale != Vector3.one)
            {
                gameOverImage.transform.localScale += Vector3.one * 0.01f;
            }
        }

        if (IsGameStart)
        {
            gameTitleImage.transform.localScale = Vector3.zero;
            pressSpaceImage.transform.localScale = Vector3.zero;
        }
    }

    public void ShowUIGameOver()
    {
        IsGameOver = true;
        //gameOverImage.transform.localScale = Vector3.one;
    }

    public void HideTitle()
    {
        IsGameStart = true;
    }
}
