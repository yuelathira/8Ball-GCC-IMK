using UnityEngine;

public class ControllerStick : MonoBehaviour
{
    [SerializeField] LayerMask layer;
    [SerializeField] LineRenderer line;
    [SerializeField] Transform focusPoint;
    
    Transform bola;
    Rigidbody bolaRb;
    public bool canLook = true;
    [SerializeField] GameManager gameManager;

    public static ControllerStick instance;

    void Awake() 
    {
        instance = this;
        bola = GameObject.FindGameObjectWithTag("Player").transform;
        bolaRb = bola.GetComponent<Rigidbody>();
    }

    void OnEnable() 
    {
        
        canLook = true;

        if (gameManager.ball1 is GameManager.balls.none)
        {
            gameManager.SwitchPlayer();
        }
        else
        {   
            gameManager.CheckCount();
        }
    }

    public void EnableLook(bool value)
    {
        canLook = value;
    }
    
    void Update()
    {
        transform.position = bola.position;
        if (Input.GetMouseButton(0) && canLook)
        {
            Vector3 mouse = Input.mousePosition;
            Vector3 pos = Camera.main.ScreenToWorldPoint(mouse);

            transform.LookAt(new Vector3(pos.x, transform.position.y, pos.z));
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            focusPoint.position = hit.point;
            line.SetPosition(1, new Vector3(0, 0, focusPoint.localPosition.z));
        }
    }
}
