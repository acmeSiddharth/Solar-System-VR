using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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
      Debug.DrawRay(Camera.main.transform.position,fwd,Color.red);
    }

    public void DownButton()
    {
      this.gameObject.transform.parent = PlayerController.transform;
      gameObject.GetComponent<SphereCollider>().enabled = false;
    }

    public void UpButton()
    {
       Vector3 fwd = gameObject.transform.TransformDirection(Vector3.forward);
       if(Physics.Raycast(Camera.main.transform.position,fwd,out hit))
       {  
        //Right Hit
        

        if(hit.transform.tag == gameObject.transform.tag)
        {
            Debug.Log("Right-Hit");
            this.gameObject.transform.position = hit.transform.position;
            this.gameObject.transform.parent =  hit.transform;
            gameObject.transform.localScale= new Vector3(1.5f,1.5f,1.5f);

        }
        else
        {
            Debug.Log("Wrong-Hit");
            gameObject.transform.parent = InitParent;
            gameObject.transform.localPosition = InitialPos;
            gameObject.GetComponent<SphereCollider>().enabled = true;

        }
       }
       else
       {
            Debug.Log("No-hit");
            gameObject.transform.parent = InitParent;
            gameObject.transform.localPosition = InitialPos;
            gameObject.GetComponent<SphereCollider>().enabled = true;

       }  
    }


}
