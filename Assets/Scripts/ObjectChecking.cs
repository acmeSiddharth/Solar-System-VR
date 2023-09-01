using UnityEngine;

public class ObjectChecking : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    public NamingTextEnabler NamedScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   void Update()
    {
     
    {
               
    }  
    }

    public void MouseUp()
    {
        Vector3 fwd = Camera.main.transform.TransformDirection(Vector3.forward);
        
         if (Physics.Raycast(Camera.main.transform.position, fwd, out hit))
         {
                
            Debug.Log("hited the " + hit.collider.gameObject.name);
            if(hit.transform.tag == gameObject.transform.tag)
            {
               Debug.Log("Right Hit Siddharth ");
               NamedScript.EnableName();
               gameObject.SetActive(false);
               
            }
            else
            {
               Debug.Log("Wrong Hit");
            }
         }
         else 
         {
            Debug.Log("NO-Hit");
         }
       
         Debug.DrawRay(Camera.main.transform.position,fwd,Color.red);
    }
}
