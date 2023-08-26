using System.Collections;
using Svr.Keyboard;
using UnityEngine;
using UnityEngine.UI;

public class TextCheck : MonoBehaviour
{
    [SerializeField] private Text InputText1;
    [SerializeField] private GameObject Question1,Question2,Question3;
    private Button btn;
    [SerializeField] private GameObject RightPanel,WrongPanel;
    [SerializeField] private SvrInputField I_Field;

    public static int Counter =0; 
    
    public void Start()
    {
      btn = this.gameObject.GetComponent<Button>();
      
    }

#region  FIrstQuestionCheckZone

    public void TextCheckingOfQuestionOne()
    {

        if(InputText1.text.ToUpper() == "MERCURY")
        {
            Counter =0;
            I_Field.GetComponent<SvrInputField>().interactable = false;
            RightPanel.SetActive(true);
            Invoke("RightPanelOff",2.0f);
          //  btn.onClick.RemoveListener(TextCheckingOfQuestionOne);
          //  btn.onClick.AddListener(TextCheckingOfQuestionTwo);
            InputText1.text = "";
            StartCoroutine(WaitingTimer1());
            Question1.SetActive(false);
            Question2.SetActive(true);
           
        }
        else
        {
            Counter =0;
            I_Field.GetComponent<SvrInputField>().interactable = false;
           WrongPanel.SetActive(true);
           Invoke("WrongPanelOff",2.0f);
         //  btn.onClick.RemoveListener(TextCheckingOfQuestionOne);
         //  btn.onClick.AddListener(TextCheckingOfQuestionTwo);
           Question1.SetActive(false);
           Question2.SetActive(true);
        }
    }


#endregion FIrstQuestionCheckZone


#region SecondQuestionEndRegion
    public void TextCheckingOfQuestionTwo()
    {
       if(InputText1.text.ToUpper() == "ASTEROID BELT" ||InputText1.text.ToUpper() == "ASTEROIDBELT"|| InputText1.text.ToUpper() == "ASTEROID-BELT" )
        {
            Counter =1;
            I_Field.GetComponent<SvrInputField>().interactable = false;
            RightPanel.SetActive(true);
            Invoke("RightPanelOff",2.0f);
            btn.onClick.RemoveListener(TextCheckingOfQuestionTwo);
            btn.onClick.AddListener(TextCheckingOfQuestionThree);
            InputText1.text = " ";
            StartCoroutine(WaitingTimer2());
            Question2.SetActive(false);
            Question3.SetActive(true);
           
        }
        else
        {
            Counter =1;
            I_Field.GetComponent<SvrInputField>().interactable = false;
            WrongPanel.SetActive(true);
            Invoke("WrongPanelOff",2.0f);
            btn.onClick.RemoveListener(TextCheckingOfQuestionTwo);
            btn.onClick.AddListener(TextCheckingOfQuestionThree);
            Question2.SetActive(false);
            Question3.SetActive(true);
        }
    }

#endregion SecondQuestionEndRegion


#region  ThirdQuestionEndRegion
    public void TextCheckingOfQuestionThree()
    {
 if(InputText1.text.ToUpper() == "365")
        {   
            Counter =2;
            I_Field.GetComponent<SvrInputField>().interactable = false;
            RightPanel.SetActive(true);
            Invoke("RightPanelOff",2.0f);
            // final result panel.
            InputText1.text = " ";
            StartCoroutine(WaitingTimer3());
             Question3.SetActive(false);
            
        }
        else
        {
            Counter =2;
            I_Field.GetComponent<SvrInputField>().interactable = false;
            WrongPanel.SetActive(true);
            Invoke("WrongPanelOff",2.0f);
            Question3.SetActive(false);
        }
    }

#endregion ThirdQuestionEndRegion


#region WaitingPart
IEnumerator WaitingTimer1()
    {
        yield return new WaitForSeconds(3.0f);
        
    }

IEnumerator WaitingTimer2()
    {
        yield return new WaitForSeconds(3.0f);
         
    }

    IEnumerator WaitingTimer3()
    {
        yield return new WaitForSeconds(3.0f);
       
    }
#endregion WaitingPart


public void RightPanelOff()
{
    RightPanel.SetActive(false);
     I_Field.GetComponent<SvrInputField>().interactable = true;

}

public void WrongPanelOff()
{
    WrongPanel.SetActive(false);
     I_Field.GetComponent<SvrInputField>().interactable = true;

}

}
