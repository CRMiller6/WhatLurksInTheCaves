using UnityEngine;

public class TurnAround : MonoBehaviour
{
    public bool turned = false;


    public void Turn()
    {
        transform.Rotate(0,180,0);

        if (turned == false)
        {
            turned = true;
            Debug.Log("facing back");
        }

        else if (turned == true)
        {
            turned = false;
            Debug.Log("facing front");
        }
    }

}
