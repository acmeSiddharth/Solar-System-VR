using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextCheckNew : MonoBehaviour
{
    [SerializeField] private Text InputText1;
    [SerializeField] private GameObject Question1,Question2,Question3,Question4,Question5;
    private Button btn;
    [SerializeField] private GameObject RightPanel,WrongPanel;
    
    public void Start()
    {
      btn = this.gameObject.GetComponent<Button>();
    }

#region  FIrstQuestionCheckZone

    public void TextCheckingOfQuestionOne()
    {
        if(InputText1.text.ToUpper() == "MERCURY")
        {
           RightPanel.SetActive(true);
           Invoke("RightPanelOff",2.0f);
           btn.onClick.RemoveListener(TextCheckingOfQuestionOne);
           btn.onClick.AddListener(TextCheckingOfQuestionTwo);
            InputText1.text = "";
            StartCoroutine(WaitingTimer());
            Question1.SetActive(false);
            Question2.SetActive(true);
        }
        else
        {
           WrongPanel.SetActive(true);
           Invoke("WrongPanelOff",2.0f);
           btn.onClick.RemoveListener(TextCheckingOfQuestionOne);
           btn.onClick.AddListener(TextCheckingOfQuestionTwo);
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
             RightPanel.SetActive(true);
           Invoke("RightPanelOff",2.0f);
            btn.onClick.RemoveListener(TextCheckingOfQuestionTwo);
            btn.onClick.AddListener(TextCheckingOfQuestionThree);
            InputText1.text = " ";
             StartCoroutine(WaitingTimer());
           Question2.SetActive(false);
           Question3.SetActive(true);
        }
        else
        {
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
             RightPanel.SetActive(true);
           Invoke("RightPanelOff",2.0f);

          // final result panel.
          InputText1.text = " ";
           StartCoroutine(WaitingTimer());
          Question3.SetActive(false);
        }
        else
        {
             WrongPanel.SetActive(true);
           Invoke("WrongPanelOff",2.0f);
           Question3.SetActive(false);
        }
    }

#endregion ThirdQuestionEndRegion


#region  ForthQuestionEndRegion
    public void TextCheckingOfQuestionFour()
    {
 if(InputText1.text.ToUpper() == "SOLID")
        {
             RightPanel.SetActive(true);
           Invoke("RightPanelOff",2.0f);
          InputText1.text = " ";
           StartCoroutine(WaitingTimer());
          Question4.SetActive(false);
          Question5.SetActive(true);
        }
        else
        {
             WrongPanel.SetActive(true);
           Invoke("WrongPanelOff",2.0f);
           Question4.SetActive(false);
           Question5.SetActive(true);
        }
    }

#endregion ForthQuestionEndRegion


#region  FifthQuestionEndRegion
    public void TextCheckingOfQuestionFive()
    {
 if(InputText1.text.ToUpper() == "OCEANIC")
        {
             RightPanel.SetActive(true);
           Invoke("RightPanelOff",2.0f);

          // final result panel.
          InputText1.text = " ";
           StartCoroutine(WaitingTimer());
          Question5.SetActive(false);
        }
        else
        {
             WrongPanel.SetActive(true);
           Invoke("WrongPanelOff",2.0f);
           Question5.SetActive(false);
        }
    }

#endregion FifthQuestionEndRegion


#region WaitingPart
    IEnumerator WaitingTimer()
    {
        yield return new WaitForSeconds(3.0f);
    }
#endregion WaitingPart


public void RightPanelOff()
{
    RightPanel.SetActive(false);
}

public void WrongPanelOff()
{
    WrongPanel.SetActive(false);
}

}
