using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class MenuRemote : MonoBehaviour
{
    public GameObject SwitchOnOBJ;
    
    // Start is called before the first frame update
    void Start()
    {
        SwitchOnOBJ.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice RightControllerDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        if (RightControllerDevice.TryGetFeatureValue(new InputFeatureUsage<bool>("MenuButton"), out bool clickvalue))
        {
            float ResetbuttonKey = 0;

            if (clickvalue == true)
            {
                ResetbuttonKey = 1;
                SwitchOnOBJ.SetActive(true);
            }

            if(ResetbuttonKey==1 && clickvalue == true)
            {
                ResetbuttonKey = 0;
                SwitchOnOBJ.SetActive(false);
                
            }


        }
    }
     
}
