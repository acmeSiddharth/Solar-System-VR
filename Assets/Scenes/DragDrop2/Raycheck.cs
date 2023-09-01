using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycheck : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    [SerializeField] private GameObject SvrCarrier;
    [SerializeField] private GameObject GvrCarrier;

    private Transform InitialParent;
    // Start is called before the first frame update
    void Start()
    {
      InitialParent = SvrCarrier.transform.parent;
      //SvrCarrier.transform.position = GvrCarrier.transform.position;
       SvrCarrier.transform.parent = GvrCarrier.transform;
      SvrCarrier.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void DownPointer()
    {
     
    }

    public void UPpointer()
    {
      Vector3 fwd = gameObject.transform.TransformDirection(Vector3.forward);
       if(Physics.Raycast(Camera.main.transform.position,fwd,out hit,float.PositiveInfinity))
       {
         Debug.Log("Hit___Sid" + hit.transform.name);
        if(hit.transform.tag == gameObject.transform.tag)
        {
            Debug.Log("Right-Hit___Sid" + hit.transform.name); 
            Debug.DrawLine(this.gameObject.transform.position,fwd,Color.red);
        }
        else
        {
            Debug.Log("Wrong-Hit___Sid"+ hit.transform.name);
        }
       }
       else
       {
        Debug.Log("No-Hit___Sid");
       }

    }

}
