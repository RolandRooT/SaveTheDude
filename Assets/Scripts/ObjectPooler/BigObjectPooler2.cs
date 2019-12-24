using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigObjectPooler2 : MonoBehaviour
{
    public GameObject pooledObject2;
    public int pooledAmount;
    List<GameObject> pooledObjects2;

    private void Start()
    {
        pooledObjects2 = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = (GameObject)Instantiate(pooledObject2);
            obj.SetActive(false);
            pooledObjects2.Add(obj);
        }

    }

    public GameObject GetPooledObject2()
    {
        for (int i = 0; i < pooledObjects2.Count; i++)
        {
            if (!pooledObjects2[i].activeInHierarchy)
            {
                return pooledObjects2[i];
            }
        }

        GameObject obj = (GameObject)Instantiate(pooledObject2);
        obj.SetActive(false);
        pooledObjects2.Add(obj);
        return obj;

    }
}
