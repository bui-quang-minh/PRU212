using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFl : MonoBehaviour
{

    public float flCamera = 2f;
    public Transform taget;

    // Update is called once per frame
    void Update()
    {
        Vector3 newpos = new Vector3(taget.position.x, taget.position.y + 1.2f, -10f);
        transform.position = Vector3.Slerp(transform.position, newpos, flCamera * Time.deltaTime);
    }
}
