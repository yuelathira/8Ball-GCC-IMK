using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] GameObject stick;
    Rigidbody rb;

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        if (new Vector3(rb.velocity.x, 0, rb.velocity.z).magnitude <= 0.05f)
        {
            //stick.SetActive(true);
            rb.velocity = Vector3.zero;
        }
        else
        {
            //stick.SetActive(false);
        }
    }
}
