using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ObjectChecking : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   void FixedUpdate()
    {
     
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

       
    }  
    }

    public void MouseUp()
    {
         ray = Camera.main.ViewportPointToRay(Camera.main.transform.position);
        if(Physics.Raycast(ray, out hit, 1000))
        {
            if(hit.transform.tag !="one")
            {
                Debug.Log("Right");
            }
        }
    }
}
