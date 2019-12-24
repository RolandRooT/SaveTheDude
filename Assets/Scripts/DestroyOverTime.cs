using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float lifeTime;
    public GameObject mainBody;

    // Update is called once per frame
    void Update()
    {

        lifeTime -= Time.deltaTime;

        if (lifeTime < 0)
        {
            mainBody.SetActive(false);
        }
    }
}
