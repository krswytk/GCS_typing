using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class dictionaryScene : MonoBehaviour
{
    public GetClickedGameObject _clickedGameObject;
    public GameObject Cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_clickedGameObject.clickedGameObject == Cube)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
