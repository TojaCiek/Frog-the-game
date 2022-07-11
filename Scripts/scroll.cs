using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+=new Vector3(-2*Time.deltaTime, 0);

        if(transform.position.x < -15.15)
        {
            transform.position = new Vector3(22.8f, transform.position.y);
        }
    }
}
