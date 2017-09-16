using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolSpawnManager : MonoBehaviour
{

    public GameObject prefab;
    public int poolSize;
    public float minScale;
    public float maxScale;


    // Use this for initialization
    void Start()
    {
        if (poolSize == 0)
        {
            poolSize = 5;
        }
        PoolManager.instance.CreatePool(prefab, poolSize);
        float scale = (Random.Range(minScale, maxScale));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float scale = (Random.Range(minScale, maxScale));
            PoolManager.instance.ReuseObject(prefab, Vector3.zero, Quaternion.identity, scale);
        }

    }
}
