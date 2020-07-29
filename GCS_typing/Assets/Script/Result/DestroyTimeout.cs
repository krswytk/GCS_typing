using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimeout : MonoBehaviour
{
    public GameObject obj;
    public float timer = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(obj, timer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
