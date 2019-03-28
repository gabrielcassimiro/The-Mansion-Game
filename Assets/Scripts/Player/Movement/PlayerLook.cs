﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private string mouseXInputName, mouseYInputName;
    [SerializeField] private float mouseSensitivity;

    [SerializeField] private Transform playerBody;

    private float xAxisClamp; 

    private void Awake() {
        LookCursor();
        xAxisClamp = 0.0f;
    }

    void Update()
    {
        cameraRotation();
    }

    private void cameraRotation(){
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if(xAxisClamp > 90.0f){
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            clampXAxisRotationToValue(270.0f);
        }
        else if(xAxisClamp < -90.0f){
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            clampXAxisRotationToValue(90.0f);
        }
        
        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void LookCursor(){
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void clampXAxisRotationToValue(float value){
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}