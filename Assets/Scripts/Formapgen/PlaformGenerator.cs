using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private Transform part1Prefab;
    [SerializeField] private Transform part2Prefab;

    public int num;

    private void Awake()
    {
        Instantiate(part1Prefab, transform.position, Quaternion.identity);
        Instantiate(part2Prefab, new Vector3(transform.position.x, transform.position.y + 3, 0), Quaternion.identity);

        Debug.Log("Received variable from Mapgenerator: " + num);
    }

    public void SetSceneVariable(int value)
    {
                num = value;
    }
}
