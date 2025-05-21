using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    enum Direction
    {
        Forward,
        Backward,
        Left,
        Right,
        None
    }

    Direction direction;
    Direction nextDirection;

    Vector3 moveForward;
    Vector3 moveBackward;
    Vector3 moveLeft;
    Vector3 moveRight;
    Vector3 moving;

    float speed;
    float turnDistance;

    bool isGameOver;

    AudioSource audioStart;
    // Start is called before the first frame update
    void Start()
    {
        direction = Direction.Backward;
        nextDirection = Direction.None;


        moveForward = new Vector3(0, 0, 1);
        moveBackward = new Vector3(0, 0, -1);
        moveLeft = new Vector3(-1, 0, 0);
        moveRight = new Vector3(1, 0, 0);

        moving = moveBackward;
        speed = 0.05f;
        turnDistance = 0.05f;
        Time.timeScale = 0;

        isGameOver = false;
        audioStart = GetComponent<AudioSource>();

        Application.targetFrameRate = 60;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            
        }

        

        if (Time.timeScale != 0)
        {

            DirectionControl();
            ToNextGrid();
            FaceToDirection();
            this.transform.position += moving * speed;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space)&&!isGameOver){
                Time.timeScale = 1;
                GameObject.Find("UIController").GetComponent<UIController>().HideTitle();
                audioStart.Play();
            }
        }
    }

    void DirectionControl()
    {
        if (true) {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (direction != Direction.Forward && direction != Direction.Backward)
                {
                    nextDirection = Direction.Forward;
                }
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (direction != Direction.Forward && direction != Direction.Backward)
                {
                    nextDirection = Direction.Backward;
                }
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (direction != Direction.Left && direction != Direction.Right)
                {
                    nextDirection = Direction.Left;
                }
            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (direction != Direction.Left && direction != Direction.Right)
                {
                    nextDirection = Direction.Right;
                }
            }
        }
    }

    void ToNextGrid()
    {
        //when moving forward
        if(direction == Direction.Forward)
        {
            if (nextDirection == Direction.Left)
            {
                for (int i = -4; i <= 5; i++)
                {
                    if (this.transform.position.z + 0.5f < i && i - (this.transform.position.z + 0.5f) <= turnDistance)
                    {
                        Vector3 currentPos = this.transform.position;
                        this.transform.position = new Vector3(currentPos.x, currentPos.y, i - 0.5f);
                        moving = moveLeft;
                        direction = Direction.Left;
                        nextDirection = Direction.None;
                        break;
                    }
                }
            }else if (nextDirection == Direction.Right)
            {
                for (int i = -4; i <= 5; i++)
                {
                    if (this.transform.position.z + 0.5f < i && i - (this.transform.position.z + 0.5f) <= turnDistance)
                    {
                        Vector3 currentPos = this.transform.position;
                        this.transform.position = new Vector3(currentPos.x, currentPos.y, i - 0.5f);
                        moving = moveRight;
                        direction = Direction.Right;
                        nextDirection = Direction.None;
                        break;
                    }
                }
            }
        }

        //when moving backward
        if (direction == Direction.Backward)
        {
            
                if (nextDirection == Direction.Left)
                {
                    for (int i = -4; i <= 5; i++)
                    {
                        if (this.transform.position.z + 0.5f > i && (this.transform.position.z + 0.5f)-i <= turnDistance)
                        {
                            Vector3 currentPos = this.transform.position;
                            this.transform.position = new Vector3(currentPos.x, currentPos.y, i - 0.5f);
                            moving = moveLeft;
                            direction = Direction.Left;
                            nextDirection = Direction.None;
                            break;
                        }
                    }
                }
                else if (nextDirection == Direction.Right)
                {
                    for (int i = -4; i <= 5; i++)
                    {
                        if (this.transform.position.z + 0.5f > i && (this.transform.position.z + 0.5f) - i <= turnDistance)
                        {
                            Vector3 currentPos = this.transform.position;
                            this.transform.position = new Vector3(currentPos.x, currentPos.y, i - 0.5f);
                            moving = moveRight;
                            direction = Direction.Right;
                            nextDirection = Direction.None;
                            break;
                        }
                    }
                }
        }

        //when moving left
        if (direction == Direction.Left)
        {
            if (nextDirection == Direction.Forward)
            {
                for (int i = -4; i <= 5; i++)
                {
                    if (this.transform.position.x + 0.5f < i && i - (this.transform.position.x + 0.5f) <= turnDistance)
                    {
                        Vector3 currentPos = this.transform.position;
                        this.transform.position = new Vector3(i - 0.5f, currentPos.y, currentPos.z);
                        moving = moveForward;
                        direction = Direction.Forward;
                        nextDirection = Direction.None;
                        break;
                    }
                }
            }

            if (nextDirection == Direction.Backward)
            {
                for (int i = -4; i <= 5; i++)
                {
                    if (this.transform.position.x + 0.5f > i && (this.transform.position.x + 0.5f) - i <= turnDistance)
                    {
                        Vector3 currentPos = this.transform.position;
                        this.transform.position = new Vector3(i - 0.5f, currentPos.y, currentPos.z);
                        moving = moveBackward;
                        direction = Direction.Backward;
                        nextDirection = Direction.None;
                        break;
                    }
                }
            }







        }

        //when moving right
        if (direction == Direction.Right)
        {
            if (nextDirection == Direction.Forward)
            {
                for (int i = -4; i <= 5; i++)
                {
                    if (this.transform.position.x + 0.5f < i && i - (this.transform.position.x + 0.5f) <= turnDistance)
                    {
                        Vector3 currentPos = this.transform.position;
                        this.transform.position = new Vector3(i - 0.5f, currentPos.y, currentPos.z);
                        moving = moveForward;
                        direction = Direction.Forward;
                        nextDirection = Direction.None;
                        break;
                    }
                }
            }

            if (nextDirection == Direction.Backward)
            {
                for (int i = -4; i <= 5; i++)
                {
                    if (this.transform.position.x + 0.5f > i && (this.transform.position.x + 0.5f) - i <= turnDistance)
                    {
                        Vector3 currentPos = this.transform.position;
                        this.transform.position = new Vector3(i - 0.5f, currentPos.y, currentPos.z);
                        moving = moveBackward;
                        direction = Direction.Backward;
                        nextDirection = Direction.None;
                        break;
                    }
                }
            }
        }
    }

    void FaceToDirection()
    {
        if (direction == Direction.Forward)
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction == Direction.Right)
        {
            this.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (direction == Direction.Left)
        {
            this.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if (direction == Direction.Backward)
        {
            this.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void SpeedUp()
    {
        speed *= 1.25f;
    }

    public Vector3 GetPos()
    {
        return this.transform.position;
    }

    public Quaternion GetRotation()
    {
        return this.transform.rotation;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Trace" || other.tag == "Wall")
        {
            Time.timeScale = 0.0f;
            GameObject.Find("UIController").GetComponent<UIController>().ShowUIGameOver();
            isGameOver = true;
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

}
