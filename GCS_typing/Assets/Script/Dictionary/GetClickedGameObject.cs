using UnityEngine;

public class GetClickedGameObject : MonoBehaviour
{

    public GameObject clickedGameObject;

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {

            clickedGameObject = null;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                clickedGameObject = hit.collider.gameObject;
            }

            Debug.Log(clickedGameObject);
        }
    }
}