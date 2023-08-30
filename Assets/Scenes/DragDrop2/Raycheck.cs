using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycheck : MonoBehaviour
{
    // Ray ray;
    // RaycastHit hit;

    [SerializeField] private GameObject SvrCarrier;
    [SerializeField] private GameObject GvrCarrier;

    private Transform InitialParent;
    // Start is called before the first frame update
    void Start()
    {
      //InitialParent = SvrCarrier.transform.parent;
      // SvrCarrier.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    //    Vector3 fwd = gameObject.transform.TransformDirection(Vector3.forward);
    //    if(Physics.Raycast(Camera.main.transform.position,fwd,out hit,float.PositiveInfinity))
    //    {
    //     if(hit.transform.tag == gameObject.transform.tag)
    //     {
    //         Debug.Log("Right-Hit");
    //         gameObject.transform.position = hit.transform.position;
    //         Debug.Log(hit.transform.name);
    //     }
    //     else
    //     {
    //         Debug.Log("Wrong-Hit");
           
    //         gameObject.GetComponent<SphereCollider>().enabled = true;

    //     }
    //    }
    //    else
    //    {
    //     Debug.Log("No-hit");
           
    //         gameObject.GetComponent<SphereCollider>().enabled = true;

    //    }

    //     Debug.DrawRay(this.gameObject.transform.position,fwd,Color.red);  
    }

    public void DownPointer()
    {
       // SvrCarrier.transform.parent = GvrCarrier.transform;
    }

    public void UPpointer()
    {
     // SvrCarrier.transform.parent = InitialParent;
    }

}
