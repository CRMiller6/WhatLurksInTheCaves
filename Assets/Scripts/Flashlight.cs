using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Flashlight : MonoBehaviour
{
   public bool turnedBack;

   public GameObject leftDoor;
   public GameObject middleDoor;
   public GameObject rightDoor;
   public GameObject backDoor;

   public Camera playerCamera;
   
   public SpriteRenderer leftDoorSprite;
   public SpriteRenderer middleDoorSprite;
   public SpriteRenderer rightDoorSprite;
   public SpriteRenderer backDoorSprite;
   
   public float leftFlashTime;
   public float middleFlashTime;
   public float rightFlashTime;
   public float backFlashTime;
   
   public TMP_Text flashTimeText;

   public float leftDoorEnterTimer;
   public float rightDoorEnterTimer;
   public float middleDoorEnterTimer;
   public float backDoorEnterTimer;

   public TMP_Text doorEnterText;

   public TMP_Text totalDoorsEnteredText;
   
   private bool lDoorSelect = false;
   private bool mDoorSelect = false;
   private bool rDoorSelect = false;
   //private bool bDoorSelect = false;

   public bool flashLightOn = false;
   public bool midFlashing = false;
   public bool leftFlashing = false;
   public bool rightFlashing = false;

   public int doorCounter = 0;

   public float flashLightCooldown = 0f;

   public float justExitMiddle = 1f;
   public float justExitLeft = 1f;
   public float justExitRight = 1f;

   public float timeToEnterDoor = 0.3f;

   public int midDoorCounter;
   public int leftDoorCounter;
   public int rightDoorCounter;
   public int backDoorCounter;
   public int totalDoorsCounter;

   void Start()
   {
    leftDoorSprite.color = Color.black;
    middleDoorSprite.color = Color.black;
    rightDoorSprite.color = Color.black;
    backDoorSprite.color = Color.black;
   }


   void Update()
   {
        flashLightCooldown += Time.deltaTime;
        if (flashLightCooldown >= 0.5 && Input.GetMouseButton(0))
        {
            flashLightOnAndOff();
        }

        if (flashLightOn == false)
        {
            stopFlashingTheLeftDoor();
            stopFlashingTheMiddleDoor();
            stopFlashingTheRightDoor();
        }

        justExitMiddle += Time.deltaTime;
        justExitLeft += Time.deltaTime;
        justExitRight += Time.deltaTime;
        
        flashTimeText.text = "Left: " + leftFlashTime + "\n" + "Mid: " + middleFlashTime + "\n" + "Right: " + rightFlashTime + "\n" + "Back: " + backFlashTime;
        doorEnterText.text = "Left: " + leftDoorEnterTimer + "\n" + "Mid: " + middleDoorEnterTimer + "\n" + "Right: " + rightDoorEnterTimer + "\n" + "Back: " + backDoorEnterTimer;
        totalDoorsEnteredText.text = "Total: " + totalDoorsCounter + "\n" + "Left: " + leftDoorCounter + "\n" + "Mid: " + midDoorCounter + "\n" + "Right: " + rightDoorCounter + "\n" + "Back: " + backDoorCounter;

        if (Input.GetKey(KeyCode.A) && mDoorSelect == false && rDoorSelect == false && turnedBack == false)
        {    
            lDoorSelect = true;
            leftDoorEnterTimer += Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            lDoorSelect = false;
        }

        if (Input.GetKey(KeyCode.W) && lDoorSelect == false && rDoorSelect == false && turnedBack == false)
        {    
            mDoorSelect = true;
            middleDoorEnterTimer += Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            mDoorSelect = false;
        }

        if (Input.GetKey(KeyCode.D) && lDoorSelect == false && mDoorSelect == false && turnedBack == false)
        {    
            rDoorSelect = true;
            rightDoorEnterTimer += Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            rDoorSelect = false;
        }

        if (leftFlashing == true)
        {
            leftFlashTime += Time.deltaTime;
        }

        if (midFlashing == true)
        {
            middleFlashTime += Time.deltaTime;
        }
        
        if (rightFlashing == true)
        {
            rightFlashTime += Time.deltaTime;
        }

        moveToNextDoor();
   }

   public void flashLightOnAndOff()
   {
        if (flashLightOn == false)
        {
            flashLightOn = true;
            flashLightCooldown = 0;
        }
        else if (flashLightOn == true)
        {
            flashLightOn = false;
            flashLightCooldown = 0;
        }
   }

   public void moveToNextDoor()
   {
        if (leftDoorEnterTimer >= timeToEnterDoor)
        {
            leftDoorCounter += 1;
            totalDoorsCounter += 1;

            middleDoorEnterTimer = 0;
            leftDoorEnterTimer = 0;
            rightDoorEnterTimer = 0;
            backDoorEnterTimer = 0;
        }

        if (middleDoorEnterTimer >= timeToEnterDoor)
        {
            midDoorCounter += 1;
            totalDoorsCounter += 1;

            middleDoorEnterTimer = 0;
            leftDoorEnterTimer = 0;
            rightDoorEnterTimer = 0;
            backDoorEnterTimer = 0;
        }

        if (rightDoorEnterTimer >= timeToEnterDoor)
        {
            rightDoorCounter += 1;
            totalDoorsCounter += 1;

            middleDoorEnterTimer = 0;
            leftDoorEnterTimer = 0;
            rightDoorEnterTimer = 0;
            backDoorEnterTimer = 0;
        }

        if (backDoorEnterTimer >= timeToEnterDoor)
        {
            backDoorCounter += 1;
            totalDoorsCounter -= 1;

            middleDoorEnterTimer = 0;
            leftDoorEnterTimer = 0;
            rightDoorEnterTimer = 0;
            backDoorEnterTimer = 0;
        }

        
   }

   public void flashTheMiddleDoor()
   {
        if (justExitMiddle >= 0.1)
        {    
            if (flashLightOn == true)
            {
                middleDoorSprite.color = Color.yellow;
                midFlashing = true;

                leftFlashing = false;
                leftDoorSprite.color = Color.black;

                rightFlashing = false;
                rightDoorSprite.color = Color.black;
            }
            else
            {
                middleDoorSprite.color = Color.black;
                midFlashing = false;
            }
        }
   }

   public void stopFlashingTheMiddleDoor()
   {
        middleDoorSprite.color = Color.black;
        midFlashing = false;
        justExitMiddle = 0;
        Debug.Log ("exiting mid");
   }

   public void flashTheLeftDoor()
   {
        if (justExitLeft >= 0.1)
        {
            if (flashLightOn == true)
            {
                leftDoorSprite.color = Color.yellow;
                leftFlashing = true;

                midFlashing = false;
                middleDoorSprite.color = Color.black;

                rightFlashing = false;
                rightDoorSprite.color = Color.black;
            }
            else 
            {
                leftDoorSprite.color = Color.black;
                leftFlashing = false;
            }
        }
   }

   public void stopFlashingTheLeftDoor()
   {
        leftDoorSprite.color = Color.black;
        leftFlashing = false;
        justExitLeft = 0;
        Debug.Log ("exiting left");
   }

    public void flashTheRightDoor()
   {
        if (justExitRight >= 0.1)
        {
            if (flashLightOn == true)
            {
                rightDoorSprite.color = Color.yellow;
                rightFlashing = true;

                midFlashing = false; 
                middleDoorSprite.color = Color.black;

                leftFlashing = false;
                leftDoorSprite.color = Color.black;
            }
            else 
            {
                rightDoorSprite.color = Color.black;
                rightFlashing = false;
            }
        }
   }

   public void stopFlashingTheRightDoor()
   {
        rightDoorSprite.color = Color.black;
        rightFlashing = false;
        justExitRight = 0;
        Debug.Log ("exiting right");
   }

}
