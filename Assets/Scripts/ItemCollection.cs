using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollection : MonoBehaviour
{
    private int apple = 0;
    private int banana = 0;
    [SerializeField]
    private TextMesh resultTxt;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.gameObject.CompareTag("Banana"))
        {
            Destroy(collision.gameObject);
            banana++;
            Debug.Log(banana);
            resultTxt.text = "Cherry : " + banana;
        }
        if (collision.gameObject.CompareTag("Apple") )
        {
            Destroy(collision.gameObject);
            apple++;
            Debug.Log(apple);
            resultTxt.text = "Cherry : " + apple;
        }
    }
}
