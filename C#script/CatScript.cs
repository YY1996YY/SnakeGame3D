using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //this.transform.SetParent(this.transform.Find("TracePrefab"));
        this.transform.position = new Vector3(0,1,0);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.localPosition = new Vector3(0, 1, 0);
        //this.transform.position = new Vector3(0, 1, 0);
    }
}
