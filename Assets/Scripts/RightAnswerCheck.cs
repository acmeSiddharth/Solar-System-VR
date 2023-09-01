using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RightAnswerCheck : MonoBehaviour
{
    public GameObject NextQuestionPanel;
    public GameObject ClosePanel;
    [SerializeField] GameObject RightPanel;
   
    

    // Start is called before the first frame update
    void Start()
    {
        NextQuestionPanel.SetActive(false);
        RightPanel.SetActive(false);  
    }


    public void RightClick()
    {
        gameObject.GetComponentInChildren<TextMeshProUGUI>().faceColor = Color.green;
        gameObject.GetComponent<Image>().color = new Color(2,37,85);
        RightPanel.SetActive(true);
        Invoke("NextQuestion",.5f);
    }

    public void NextQuestion()
    {
         RightPanel.SetActive(false);
        ClosePanel.SetActive(false);
        NextQuestionPanel.SetActive(true);
    }

    public void HoverColorOfCircle()
    {
        gameObject.GetComponent<Image>().color = new Color(2,37,85);
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(69, 201, 2);
    }


    public void HoverExit() 
    {
         gameObject.GetComponent<Image>().color = new Color(66,66,66,255);
         gameObject.transform.GetChild(0).GetChild(0).GetComponent<Image>().color = new Color(191,191,191);
    }
    
}
