using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    GameObject duplicated = null;
    [SerializeField] GameObject music;

    void Awake()
    {
        try
        {
            duplicated = GameObject.FindGameObjectWithTag("Music");
        }
        catch (System.Exception)
        {
            
        }
    }

    void Start()
    {
        if (duplicated == null)
        {
            Instantiate(music, Vector3.zero, Quaternion.identity);
        }
    }
}
