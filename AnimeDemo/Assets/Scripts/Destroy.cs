using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float timeOut;
    private float timeElapsed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= timeOut)
        {
            Destroy(this.gameObject);
            timeElapsed = 0;
        }


    }
}
