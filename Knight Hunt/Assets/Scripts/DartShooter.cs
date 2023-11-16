using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DartShooter : MonoBehaviour
{
    public GameObject Dart;

    public Transform dartlaunch;

    public float dartTime;
    public float dartCount;

    void Start()
    {
        dartCount = dartTime;
        dartCount = 0f;
    }


    void Update()
    {
        dartCount -= Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (dartCount <= 0)
            {
                Instantiate(Dart, dartlaunch.position, Quaternion.identity);
                dartCount = dartTime;
            }
            
        }
    }
}
