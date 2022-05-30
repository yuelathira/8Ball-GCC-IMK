using UnityEngine;

public class BallActions : MonoBehaviour
{
    Rigidbody[] allBalls;
    [SerializeField] GameObject stick;
    public float[] speed;
    
    void Update()
    {
        allBalls = GetComponentsInChildren<Rigidbody>();
        speed = new float[allBalls.Length];
        for (int i = 0; i < allBalls.Length; i++)
        {
            speed[i] = new Vector3(allBalls[i].velocity.x, 0, allBalls[i].velocity.z).magnitude;
        }

        if (SumArray(speed) > 0.02f)
        {
            stick.SetActive (false);
        }
        else
        {
            stick.SetActive (true);
        }
    }

    float SumArray(float[] toBeSummed)
    {
        float sum = 0;
        foreach (float item in toBeSummed)
        {
            sum += item;
        }

        return sum;
    }
}
