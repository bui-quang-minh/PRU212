using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomValidator : MonoBehaviour
{
    public int RoomType;
    public void Delete(){
        Destroy(gameObject);
    }
}
