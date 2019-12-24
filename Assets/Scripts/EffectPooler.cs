using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectPooler : MonoBehaviour
{
    public GameObject effectObject;
    private int pooledAmount = 6;

    List<GameObject> effectObjects;

    private void Start()
    {
  
        effectObjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject eff = Instantiate(effectObject);
            eff.SetActive(false);
            effectObjects.Add(eff);
        }
    }
    public GameObject GetPooledEffect()
    {
        for (int i = 0; i < effectObjects.Count; i++)
        {
            if (!effectObjects[i].activeInHierarchy)
            {
                return effectObjects[i];
            }
        }

        GameObject eff = (GameObject)Instantiate(effectObject);
        eff.SetActive(false);
        effectObjects.Add(eff);
        return eff;
    }
}
