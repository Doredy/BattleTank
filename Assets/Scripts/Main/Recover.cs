using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recover : MonoBehaviour
{
    private Vector3 rot;

    // Update is called once per frame
    void Update()
    {
        rot = transform.eulerAngles;

        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.eulerAngles = new Vector3(0, rot.y, 0);
        }
    }
}
