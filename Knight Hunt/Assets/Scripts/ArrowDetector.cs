using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ArrowDetector : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI SArrow;
    [SerializeField] TextMeshProUGUI wait;
    [SerializeField] float selectWait;
    [SerializeField] float selectCounter;

    [SerializeField] float changeTime;
    [SerializeField] float changeCounter;
    public bool Switch;
    
    void Start()
    {
        Switch = false;
        selectCounter = selectWait;
        changeCounter = changeTime;
        changeCounter = 0f;
    }

    void Update()
    {
        if(changeCounter > -0.5f)
        {
            wait.text = "Wait!";
        }
        else if(changeCounter < -0.5f)
        {
            wait.text = "Switch";
        }


        if (Input.GetKey(KeyCode.R) && !Switch && changeCounter <= 0f)
        {
            Switch = true;
            SArrow.text = "Metal Arrow";
            selectCounter = selectWait;
            changeCounter = changeTime;
        }
        else if (Input.GetKey(KeyCode.R) && Switch && changeCounter <= 0f)
        {
            Switch = false;
            SArrow.text = "Wood Arrow";
            selectCounter = selectWait;
            changeCounter = changeTime;
        }
        selectCounter -= Time.deltaTime;

        changeCounter -= Time.deltaTime;
    }
}
