using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapgenerator : MonoBehaviour
{
    [SerializeField] private Transform platformPrefab;
    public int height;
    public int separate;
    public int size;

    private void Awake()
    {
        Vector3 currentPosition = transform.position;
        int sceneVariable = 42; 

        for (int i = 0; i < size; i++)
        {
            Instantiate(platformPrefab, new Vector3(currentPosition.x + i * separate, currentPosition.y, 0), Quaternion.identity);
        }
        PlatformGenerator platformGenerator = GetComponent<PlatformGenerator>();
        if (platformGenerator != null)
        {
            platformGenerator.SetSceneVariable(sceneVariable);
        }
    }
}
