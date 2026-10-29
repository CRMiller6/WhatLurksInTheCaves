using UnityEngine;

public class BasicMonsterManager : MonoBehaviour
{
    private Flashlight totalDoorsCounter;

    void Awake()
    {
        totalDoorsCounter = GetComponent<Flashlight>();
        Debug.Log("TDC: " + totalDoorsCounter);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
