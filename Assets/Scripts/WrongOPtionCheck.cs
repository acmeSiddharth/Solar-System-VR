using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WrongOPtionCheck : MonoBehaviour
{
    [SerializeField] private GameObject WrongPanel;
    [SerializeField] private GameObject NextQuestionPanel;
    [SerializeField] private GameObject SelfPanel;
    // Start is called before the first frame update
       

       public void Start()
       {
        WrongPanel.SetActive(false);
       }
     public void WrongClick()
    {
        this.gameObject.GetComponentInChildren<TextMeshProUGUI>().faceColor = Color.red;
       WrongPanel.SetActive(true);
        Invoke("WrongAnsColorChange",.5f);
        gameObject.GetComponent<Button>().interactable= false;
    }

    private void WrongAnsColorChange()
    {
        WrongPanel.SetActive(false);
        SelfPanel.SetActive(false);
        NextQuestionPanel.SetActive(true);
    }


    
    
    public void HoverOption()
    {
        gameObject.GetComponent<Image>().color = new Color(2,37,85);
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(69, 201, 2);
    }


    public void HoverExit() 
    {
         gameObject.GetComponent<Image>().color = new Color(0,0,0,150);
         gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(191,191,191);
         
    }
    

}
