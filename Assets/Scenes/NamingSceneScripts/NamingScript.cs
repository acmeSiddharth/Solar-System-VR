using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NamingScript : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI Inputdata;
    [SerializeField] private TextMeshProUGUI OrgWord;
    [SerializeField] private Text point;
    [SerializeField] private Button[] Alphbets;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    public void CreateString()
    {
        var DataByUser = this.gameObject.name;
        Debug.Log(DataByUser);
        Inputdata.text =  DataByUser;
        OrgWord.text = OrgWord.text + Inputdata.text; 
        Debug.Log(OrgWord.text);
        point.text = OrgWord.text;
        
    }


}
