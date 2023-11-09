using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTileLaunch : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject projectilePrefab2;

    public Transform launchPoint;

    public float defaultTime;

    public float shootTime;
    public float shootCounter;

    public bool Switch;
    
    void Start()
    {
        Switch = false;

        defaultTime = shootTime;

        shootCounter = shootTime;
        shootCounter = 0;
    }
    
    void Update()
    {
        if (Input.GetKey(KeyCode.R) && !Switch)
        {
            Switch = true;
            shootTime = 6f;
        }
        else if(Input.GetKey(KeyCode.R) && Switch)
        {
            Switch = false;
            shootTime = defaultTime;
        }

        shootCounter -= Time.deltaTime;
    }
    
    void OnLeftprojectile()
    {
        if (shootCounter < 0 && Switch == false)
        {
            Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
            shootCounter = shootTime;
            shootCounter -= Time.deltaTime;
        }
        if (shootCounter < 0 && Switch == true)
        {
            Instantiate(projectilePrefab2, launchPoint.position, Quaternion.identity);
            shootCounter = shootTime;
            shootCounter -= Time.deltaTime;
        }
    }

    void OnRightprojectile()
    {
        if (shootCounter < 0 && Switch == false)
        {
            Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
            shootCounter = shootTime;
            shootCounter -= Time.deltaTime;
        }
        if (shootCounter < 0 && Switch == true)
        {
            Instantiate(projectilePrefab2, launchPoint.position, Quaternion.identity);
            shootCounter = shootTime;
            shootCounter -= Time.deltaTime;
        }
    }
}
