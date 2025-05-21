using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceScript : MonoBehaviour
{
    int score;
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("AppleGenerator").GetComponent<AppleGeneratorControl>().GetScore();

        //this.transform.Find("Cat").transform.localPosition = new Vector3(0,-1,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            this.transform.position = GameObject.Find("PosRecorder").GetComponent<PosRecorControl>().GetRecordedPos(score * 20);
            this.transform.rotation = GameObject.Find("PosRecorder").GetComponent<PosRecorControl>().GetRecordedRot(score * 20);
        }
    }
}
