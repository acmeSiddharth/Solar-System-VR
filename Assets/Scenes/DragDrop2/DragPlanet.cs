using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class DragPlanet : MonoBehaviour
{
   
    [SerializeField] private Transform PlayerController;          //Drag the gameObject you want to make child of
    private Transform InitParent;
    private Vector3 InitialPos,fwd;
    Ray ray;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
      InitialPos = gameObject.transform.localPosition;
      InitParent = gameObject.transform.parent;
      this.gameObject.GetComponent<SphereCollider>().enabled =true;
      
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    public void DownButton()
    {
      this.gameObject.transform.parent = PlayerController.transform;
      gameObject.GetComponent<SphereCollider>().enabled = false;
    }

   

    public void UpButton()
    {
       Vector3 fwd = gameObject.transform.TransformDirection(Vector3.forward);
       if(Physics.Raycast(gameObject.transform.position,fwd,out hit, float.PositiveInfinity))
       {  
          
        if(hit.transform.tag == gameObject.transform.tag)
        {
           // Debug.Log("Right-Hit");
            this.gameObject.transform.position = hit.transform.position;
            this.gameObject.transform.parent =  hit.transform;
            gameObject.transform.localScale= new Vector3(1,1,1);
            Debug.Log(hit.transform.name);


        }
        else
        {
            //Debug.Log("Wrong-Hit");
            gameObject.transform.parent = InitParent;
            gameObject.transform.localPosition = InitialPos;
            gameObject.GetComponent<SphereCollider>().enabled = true;
            Debug.Log(hit.transform.name);

        }
       }
       else
       {
            //Debug.Log("No-hit");
            gameObject.transform.parent = InitParent;
            gameObject.transform.localPosition = InitialPos;
            gameObject.GetComponent<SphereCollider>().enabled = true;

       }  
    }


}
