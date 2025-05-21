using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosRecorControl : MonoBehaviour
{

    public GameObject playerTrace;
    float traceDeltaTime;
    int interval;
    struct PlayerPosInfo
    {
        public Vector3 pos;
        public Quaternion rot;
        public bool IsOn;
    }

    PlayerPosInfo[] playerPosInfo;

    // Start is called before the first frame update
    void Start()
    {
        playerPosInfo = new PlayerPosInfo[3000];
        interval = 0;
    }

    // Update is called once per frame
    void Update()
    {
        interval++;
        if (interval == 1)
        {

            for (int i = playerPosInfo.Length - 1; i > 0; i--)
            {
                playerPosInfo[i] = playerPosInfo[i - 1];
            }
            playerPosInfo[0] = GetPlayerPos();
            interval = 0;
        }
        //    traceDeltaTime += Time.deltaTime;
        //if (traceDeltaTime >= 0.5)
        //{
        //    GameObject trace = Instantiate(playerTrace);
        //    trace.transform.position = playerPosInfo[0].pos;
        //    trace.transform.rotation = playerPosInfo[0].rot;
        //    traceDeltaTime = 0;
        //}
        

        //for (int i = playerPosInfo.Length - 1; i > 0; i--)
        //{
        //    GameObject trace = Instantiate(playerTrace);
        //    trace.transform.position = playerPosInfo[i].pos;
        //    trace.transform.rotation = playerPosInfo[i].rot;
        //}



    }

    PlayerPosInfo GetPlayerPos()
    {
        PlayerPosInfo tempPosInfo = new PlayerPosInfo();
        tempPosInfo.pos = GameObject.Find("Player").GetComponent<PlayerControl>().GetPos();
        tempPosInfo.rot = GameObject.Find("Player").GetComponent<PlayerControl>().GetRotation();
        tempPosInfo.IsOn = true;

        return tempPosInfo;
    }

    public Vector3 GetRecordedPos(int i)
    {
        Vector3 _pos = playerPosInfo[i].pos;
        return _pos;
    }

    public Quaternion GetRecordedRot(int i)
    {
        Quaternion _rot = playerPosInfo[i].rot;
        return _rot;
    }

    public void InitiateTrace()
    {
        GameObject trace = Instantiate(playerTrace);
    }

}
