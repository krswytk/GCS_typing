using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GetClickedGameObject2 : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("Favorite");
    }
}