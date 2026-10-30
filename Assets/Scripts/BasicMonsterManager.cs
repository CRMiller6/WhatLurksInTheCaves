using UnityEngine;

public class BasicMonsterManager : MonoBehaviour
{
    private Flashlight totalDoorsCounter;
    private int doorCounterNumber;

    public int doorsTillPlayer = 0;

    void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeterminePhase()
    {
        if (doorsTillPlayer == 0)
        {
            if (doorCounterNumber <= 20)
            {
                
            }
        }
    }
}
