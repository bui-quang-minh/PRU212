using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleGenerator : MonoBehaviour
{
    [SerializeField] private Transform Plaform;
    private void Awake()
    {
        Instantiate(Plaform, transform.position, Quaternion.identity);
    }
}
