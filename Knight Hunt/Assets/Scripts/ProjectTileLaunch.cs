using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ProjectTileLaunch : MonoBehaviour
{
    
   [SerializeField] float changeTime;
   [SerializeField] float changeCounter;
   [SerializeField] TextMeshProUGUI fire;
   
    public GameObject projectilePrefab;
    public GameObject projectilePrefab2;

    public Transform launchPoint;

    public float defaultTime;

    public float shootTime;
    public float shootCounter;

    public bool Switch;
    
    void Start()
    {
        changeCounter = changeTime;
        changeCounter = 0f;
        
        Switch = false;

        defaultTime = shootTime;

        shootCounter = shootTime;
        shootCounter = 0;
    }
    
    void Update()
    {
    
     if (shootCounter > 0f)
        {
            fire.text = "!Reloading!";
        }
        else if (shootCounter < 0f)
        {
           fire.text = "!!Fire!!";
        }
        
        if (Input.GetKey(KeyCode.R) && !Switch && changeCounter <= 0f)
        {
            Switch = true;
            shootTime = 6f;

            changeCounter = changeTime;
        }
        else if(Input.GetKey(KeyCode.R) && Switch && changeCounter <= 0f)
        {
            Switch = false;
            shootTime = defaultTime;

            changeCounter = changeTime;
        }

        shootCounter -= Time.deltaTime;

         changeCounter -= Time.deltaTime;
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
