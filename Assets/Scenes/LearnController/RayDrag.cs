using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayDrag : MonoBehaviour
{
    private Vector3 InitPos;
    private RaycastHit hit;
    private  Transform InitialParent;
    bool IsDragging;
    [SerializeField]private Transform ParentTransistion;
     private Vector3 DefaultScale,rot=new Vector3(0,0,0);


    // Start is called before the first frame update

    void Start()
    {
      InitialParent = gameObject.transform.parent;
      InitPos = gameObject.transform.position;
      DefaultScale = gameObject.transform.localScale;
    }
    

    
    public void OnMouseDown()
    {
      IsDragging =true;
      gameObject.transform.parent =  ParentTransistion.transform;  
       
    }

   

    public void OnMouseUp()
    {  
      IsDragging =false;
       //gameObject.transform.parent = InitialParent;
      gameObject.transform.parent = InitialParent;
      gameObject.transform.position = InitPos;
      gameObject.transform.localRotation = Quaternion.identity;
     
    }
}
