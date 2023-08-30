using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropPlanets : MonoBehaviour
{
    [SerializeField] private Transform PlayerController;          //Drag the gameObject you want to make child of
    private Transform InitParent;
    private Vector3 InitialPos;
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
       if(Physics.Raycast(gameObject.transform.position,fwd,out hit))
       {
        if(hit.transform.tag == gameObject.transform.tag)
        {
            Debug.Log("Right-Hit");
            gameObject.transform.position = hit.transform.position;


        }
        else
        {
            Debug.Log("Wrong-Hit");
          //  gameObject.transform.parent = InitParent;
            gameObject.transform.localPosition = InitialPos;
            gameObject.GetComponent<SphereCollider>().enabled = true;

        }
       }
       else
       {
        Debug.Log("No-hit");
           // gameObject.transform.parent = InitParent;
            gameObject.transform.localPosition = InitialPos;
            gameObject.GetComponent<SphereCollider>().enabled = true;

       }

        Debug.DrawRay(Camera.main.transform.position,fwd,Color.red);
       
    }


}
