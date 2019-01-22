using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBoxGenerator : MonoBehaviour
{

    public GameObject Sphere;
    public GameObject effect;
    public float spn = 1.0f;
    private float timeElapsed;
    public float timeOut = 10;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //経過時間で表示を消す
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeOut)
        {
            Vector3 pos = new Vector3(Random.Range(-40, 100), 3, Random.Range(-75, 43));
            GameObject AmmoBox = Instantiate(Sphere, pos, Quaternion.identity);
            Rigidbody rd = AmmoBox.transform.GetComponent<Rigidbody>();
            timeElapsed = 0.0f;
        }
        
    }
}
