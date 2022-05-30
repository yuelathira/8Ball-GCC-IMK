using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OnPointer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public UnityEvent onEnter, onExit, onDown, onUp;

    public void OnPointerEnter(PointerEventData data)
    {
        onEnter.Invoke();
    }

    public void OnPointerExit(PointerEventData data)
    {
        onExit.Invoke();
    }

    public void OnPointerDown(PointerEventData data)
    {
        onDown.Invoke();
    }

    public void OnPointerUp(PointerEventData data)
    {
        onUp.Invoke();
    }
}
