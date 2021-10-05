using UnityEngine;
using UnityEngine.EventSystems;

public class BubbleButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    [SerializeField] private BubblesSpawnerPoint _bubblesSpawnerPoint;

    public void OnPointerDown(PointerEventData eventData)
    {
        _bubblesSpawnerPoint.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _bubblesSpawnerPoint.Stop();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _bubblesSpawnerPoint.Stop();
    }
}
