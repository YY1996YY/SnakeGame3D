using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
    // Start is called before the first frame update
    float r;
    int score;
    void Start()
    {
        r = 0;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        r = r + 0.5f;
        if (r == 360)
        {
            r=0; 
        }

        this.transform.rotation = Quaternion.Euler(0f, r, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject.Find("AppleGenerator").GetComponent<AppleGeneratorControl>().PlayerEatApple();
            GameObject.Find("PosRecorder").GetComponent<PosRecorControl>().InitiateTrace();
            
            Destroy(this.gameObject);
        }
    }


}
