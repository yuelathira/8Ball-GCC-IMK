using UnityEngine;

public class ControllerPower : MonoBehaviour
{
    public static ControllerPower instance;

    public float fullPower;
    float power;
    [SerializeField] float maxPower;
    bool isPower;

    [SerializeField] Transform indicator;
    [SerializeField] GameObject ind;

    float speed = 1;
    public AudioClip strikeClip;

    void Awake()
    {
        instance = this;
    }
    
    int once = 1;
    void Update()
    {
        if (isPower && power <= maxPower)
        {
            power += Time.deltaTime * speed;
            float clamp = power/maxPower;
            indicator.localScale = new Vector3(indicator.localScale.x, 1-clamp, indicator.localScale.z);
            ind.SetActive(true);
        }
        else if (once == 1)
        {
            ind.SetActive(false);
            Strike(power);
            once += 1;
        }
    }

    public void StartPower()
    {
        once = 1;
        power = 0;
        isPower = true;
    }

    public void EndPower()
    {
        isPower = false;
        Strike(power);
    }

    void Strike(float power)
    {
        ControllerStick stick = ControllerStick.instance;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().AddForce(stick.transform.forward * (power * fullPower), ForceMode.VelocityChange);
        AudioSource.PlayClipAtPoint(strikeClip, GameObject.FindGameObjectWithTag("Player").transform.position, 1);
    }
}
