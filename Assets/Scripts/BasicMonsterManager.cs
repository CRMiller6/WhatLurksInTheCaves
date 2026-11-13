
using UnityEngine;

public class BasicMonsterManager : MonoBehaviour
{
    public int totalDoorsCounter;
    public int doorCounterNumber = 1;

    public bool flashedAwayLeft = true;
    public bool flashedAwayMid = true;
    public bool flashedAwayRight = true;
    public bool flashedAwayDave = true;
    public bool flashedAwayJohn = true;

    public int doorsTillPlayerDave = 0;
    public int doorsTillPlayerJohn = 0;
    public int pickLeftDoor = 1;
    public int pickMiddleDoor = 2;
    public int pickRightDoor = 3;

    public bool isDave = true;
    public bool isJohn = false;

    public int pickNextDoorDave;
    public int pickNextDoorJohn;

    public GameObject daveEyesLeft;
    public GameObject daveEyesMid;
    public GameObject johnEyesMid;
    public GameObject johnEyesRight; 

    public GameObject deathScreen;
    public GameObject demoScreen;
    public GameObject instructions;

    public float animationStall;
    public float stallTime;

    void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        daveEyesLeft.SetActive(false);
        daveEyesMid.SetActive(false);
        johnEyesMid.SetActive(false);
        johnEyesRight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        animationStall += Time.deltaTime;

        if ((animationStall + 0.3) >= stallTime)
        {
            if (doorsTillPlayerDave == 0)
            {
                if (pickNextDoorDave == 1 && flashedAwayDave == false)
                {
                    daveEyesLeft.SetActive(true);
                }
                else if (pickNextDoorDave == 2 && flashedAwayDave == false)
                {
                    daveEyesMid.SetActive(true);
                }
            }

            if (doorsTillPlayerJohn == 0)
            {
                if (pickNextDoorJohn == 2 && flashedAwayJohn == false)
                {
                    johnEyesMid.SetActive(true);
                }
                else if (pickNextDoorJohn == 3 && flashedAwayJohn == false)
                {
                    johnEyesRight.SetActive(true);
                }
            }
        }
    }

    public void MonstersInYourDoors()
    {
        
    }

    public void FlashingMonsters()
    {
        if (doorsTillPlayerDave == 0 || doorsTillPlayerJohn == 0)
        {
            if (flashedAwayLeft == true && pickNextDoorDave == 1)
            {
                flashedAwayDave = true;
                daveEyesLeft.SetActive(false);
            }
            if (flashedAwayMid == true && pickNextDoorDave == 2 && doorsTillPlayerDave == 0)
            {
                flashedAwayDave = true;
                daveEyesMid.SetActive(false);
            }
            if (flashedAwayMid == true && pickNextDoorJohn == 2 && doorsTillPlayerJohn == 0)
            {
                flashedAwayJohn = true;
                johnEyesMid.SetActive(false);
            }
            if (flashedAwayRight == true && pickNextDoorJohn == 3)
            {
                flashedAwayJohn = true;
                johnEyesRight.SetActive(false);
            }
        }
        else
        {
            flashedAwayLeft = false;
            flashedAwayMid = false;
            flashedAwayRight = false;
        }
    }

    public void BasicMonsterPhase()
    {
        if (totalDoorsCounter >= doorCounterNumber) //if you go forward
        {
            Debug.Log("if u go forward");

            if (totalDoorsCounter < 30)
            {
                    //3-5
                if (doorsTillPlayerDave == 0 && doorsTillPlayerJohn == 0 && flashedAwayDave == true && flashedAwayJohn == true)
                {
                    doorsTillPlayerDave = Random.Range(3,6);
                    pickNextDoorDave = Random.Range(1,3);
                    doorsTillPlayerJohn = Random.Range(3,6);
                    pickNextDoorJohn = Random.Range(2,4);
                }


                else if (doorsTillPlayerDave == 0 && flashedAwayDave == true)
                {
                    doorsTillPlayerDave = Random.Range(3,6);
                    pickNextDoorDave = Random.Range(1,3); //x through y-1
                    doorsTillPlayerJohn --;
                }

                else if (doorsTillPlayerJohn == 0 && flashedAwayJohn == true)
                {
                    doorsTillPlayerJohn = Random.Range(3,6);
                    pickNextDoorJohn = Random.Range(2,4);
                    doorsTillPlayerDave --;
                }

                else if (doorsTillPlayerDave < 0 || doorsTillPlayerJohn < 0)
                {
                    deathScreen.SetActive(true);
                }

                else if ((doorsTillPlayerDave == 0 && flashedAwayDave == false) || (doorsTillPlayerJohn == 0 && flashedAwayJohn == false))
                {
                    // deathScreen.SetActive(true);
                    doorsTillPlayerDave --;
                    doorsTillPlayerJohn --;
                    if (doorsTillPlayerDave < 0 || doorsTillPlayerJohn < 0)
                    {
                        deathScreen.SetActive(true);
                    }

                }

                else if (doorsTillPlayerDave != 0 && doorsTillPlayerJohn != 0)
                {
                    doorsTillPlayerDave --;
                    doorsTillPlayerJohn --;
                }
                    
                flashedAwayDave = false;
                flashedAwayJohn = false;
                flashedAwayLeft = false;
                flashedAwayMid = false;
                flashedAwayRight = false;
                    

                Debug.Log("TDC under 30");
                instructions.SetActive(false);

            }
            else if (totalDoorsCounter == 30)
            {
                Debug.Log("30");
                demoScreen.SetActive(true);
                // safe room
            }
            else if (30 < totalDoorsCounter && totalDoorsCounter < 60)
            {
                Debug.Log("30-60");
                //3-4
            }
            else if (totalDoorsCounter == 60)
            {
                Debug.Log("60");
                // safe
            }
            else if (60 < totalDoorsCounter && totalDoorsCounter < 90)
            {
                //2-4
            }
            else if (totalDoorsCounter == 90)
            {
                // safe
            }
            else if (90 < totalDoorsCounter && totalDoorsCounter < 100)
            {
                //1-3
            }
            else if (totalDoorsCounter == 100)
            {
                //WIN
            }
        }
        else if (totalDoorsCounter < doorCounterNumber)
        {
            //go backwards. monsters enter mid
        }
    }
}
