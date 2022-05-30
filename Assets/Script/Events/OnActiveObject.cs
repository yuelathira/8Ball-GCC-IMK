using UnityEngine;
using UnityEngine.Events;

public class OnActiveObject : MonoBehaviour
{
    [SerializeField] UnityEvent onEnable, onDisable;

    void OnEnable()
    {
        onEnable.Invoke();
    }

    void OnDisable()
    {
        onDisable.Invoke();
    }
}
