using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateRoom : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask room; 
    public LevelGeneration levelGeneration;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position,1,room);
        if(roomDetection==null){
            
        }

    }
}
