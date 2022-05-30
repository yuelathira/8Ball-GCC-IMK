using UnityEngine;
using UnityEngine.Events;

public class OnCollisions : MonoBehaviour
{
    [SerializeField] string[] tags;
    public UnityEvent<Collision>  onEnter, onExit, onStay;

    void OnCollisionEnter(Collision other)
    {
        Check(other, onEnter);
    }   
    void OnCollisionExit(Collision other)
    {
        Check(other, onExit);
    }  
    void OnCollisionStay(Collision other)
    {
        Check(other, onStay);
    }  

    void Check(Collision other, UnityEvent<Collision> value)
    {
        foreach (string tag in tags)
        {
            if (other.gameObject.CompareTag(tag))
            {
                value.Invoke(other);
            }
        }
    }
}
