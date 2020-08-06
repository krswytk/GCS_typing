using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimeout : MonoBehaviour
{
    [SerializeField] private GameObject Difficulty;
    public float outtimer = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Difficulty = GameObject.Find("Difficulty");
        Destroy(Difficulty, outtimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
