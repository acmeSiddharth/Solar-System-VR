using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR;

public class NewInputSystemSample : MonoBehaviour
{
    [Header("HMD")]
    public Text HMD_position;
    public Text HMD_rotation;
    public GameObject HMD_BackButton;
    public GameObject HMD_ClickButton;
    public GameObject HMD_VolumeUpButton;
    public GameObject HMD_VolumeDownButton;
    [Header("RightController")]
    public Text R_position;
    public Text R_rotation;
    public Text R_trigger;
    public GameObject R_ClickButton;
    public GameObject R_AppButton;
    public GameObject R_HomeButton;
    public GameObject R_TriggerButton;
    public GameObject R_GripButton;
    public Text R_Touch;
    public GameObject R_Touched;
    [Header("LeftController")]
    public Text L_position;
    public Text L_rotation;
    public Text L_trigger;
    public GameObject L_ClickButton;
    public GameObject L_AppButton;
    public GameObject L_HomeButton;
    public GameObject L_TriggerButton;
    public GameObject L_GripButton;
    public Text L_Touch;
    public GameObject L_Touched;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    #region HMD
    public void HMD_Position(InputAction.CallbackContext context)
    {
        HMD_position.text = context.ReadValue<Vector3>().ToString();
    }
    public void HMD_Rotation(InputAction.CallbackContext context)
    {
        HMD_rotation.text = context.ReadValue<Quaternion>().ToString();
    }
    public void HMD_Enter(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            HMD_ClickButton.SetActive(true);
        }
        if (context.canceled)
        {
            HMD_ClickButton.SetActive(false);
        }
    }
    public void HMD_Back(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            HMD_BackButton.SetActive(true);
        }
        if (context.canceled)
        {
            HMD_BackButton.SetActive(false);
        }
    }
    
    public void HMD_VolumeUp(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            HMD_VolumeUpButton.SetActive(true);
        }
        if (context.canceled)
        {
            HMD_VolumeUpButton.SetActive(false);
        }
    }
    public void HMD_VolumeDown(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            HMD_VolumeDownButton.SetActive(true);
        }
        if (context.canceled)
        {
            HMD_VolumeDownButton.SetActive(false);
        }
    }
    #endregion
    #region RightController
    public void Right_Position(InputAction.CallbackContext context)
    {
        R_position.text = context.ReadValue<Vector3>().ToString();
    }
    public void Right_Rotation(InputAction.CallbackContext context)
    {
        R_rotation.text = context.ReadValue<Quaternion>().ToString();
    }
    public void Right_Trigger(InputAction.CallbackContext context)
    {
        R_trigger.text = context.ReadValue<float>().ToString();
    }
    public void Right_ClickButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            R_ClickButton.SetActive(true);
        }
        if (context.canceled)
        {
            R_ClickButton.SetActive(false);
        }
    }
    public void Right_AppButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            R_AppButton.SetActive(true);
        }
        if (context.canceled)
        {
            R_AppButton.SetActive(false);
        }
    }
    public void Right_HomeButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            R_HomeButton.SetActive(true);
        }
        if (context.canceled)
        {
            R_HomeButton.SetActive(false);
        }
    }
    public void Right_TriggerButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            R_TriggerButton.SetActive(true);
        }
        if (context.canceled)
        {
            R_TriggerButton.SetActive(false);
        }
    }
    public void Right_GripButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            R_GripButton.SetActive(true);
        }
        if (context.canceled)
        {
            R_GripButton.SetActive(false);
        }
    }
    public void Right_Touch(InputAction.CallbackContext context)
    {
        R_Touch.text = context.ReadValue<Vector2>().ToString();
    }
    public void Right_Touched(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            R_Touched.SetActive(true);
        }
        if (context.canceled)
        {
            R_Touched.SetActive(false);
        }
    }
    #endregion
    #region LeftController
    public void Left_Position(InputAction.CallbackContext context)
    {
        L_position.text = context.ReadValue<Vector3>().ToString();
    }
    public void Left_Rotation(InputAction.CallbackContext context)
    {
        L_rotation.text = context.ReadValue<Quaternion>().ToString();
    }
    public void Left_Trigger(InputAction.CallbackContext context)
    {
        L_trigger.text = context.ReadValue<float>().ToString();
    }
    public void Left_ClickButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            L_ClickButton.SetActive(true);
        }
        if (context.canceled)
        {
            L_ClickButton.SetActive(false);
        }
    }
    public void Left_AppButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            L_AppButton.SetActive(true);
        }
        if (context.canceled)
        {
            L_AppButton.SetActive(false);
        }
    }
    public void Left_HomeButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            L_HomeButton.SetActive(true);
        }
        if (context.canceled)
        {
            L_HomeButton.SetActive(false);
        }
    }
    public void Left_TriggerButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            L_TriggerButton.SetActive(true);
        }
        if (context.canceled)
        {
            L_TriggerButton.SetActive(false);
        }
    }
    public void Left_GripButton(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            L_GripButton.SetActive(true);
        }
        if (context.canceled)
        {
            L_GripButton.SetActive(false);
        }
    }
    public void Left_Touch(InputAction.CallbackContext context)
    {
        L_Touch.text = context.ReadValue<Vector2>().ToString();
    }
    public void Left_Touched(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            L_Touched.SetActive(true);
        }
        if (context.canceled)
        {
            L_Touched.SetActive(false);
        }
    }
    #endregion
}
