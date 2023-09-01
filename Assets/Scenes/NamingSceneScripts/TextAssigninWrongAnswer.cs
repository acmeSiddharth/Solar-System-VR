using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextAssigninWrongAnswer : MonoBehaviour
{
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(TextCheck.Counter == 0)
       {
          gameObject.GetComponent<TextMeshProUGUI>().text = "Mercury";
       }
       else if(TextCheck.Counter == 1)
       {
         gameObject.GetComponent<TextMeshProUGUI>().text = "Asteroidbelt";
       }
       else if(TextCheck.Counter == 2)
       {
         gameObject.GetComponent<TextMeshProUGUI>().text = "365";
       }
    }

}
