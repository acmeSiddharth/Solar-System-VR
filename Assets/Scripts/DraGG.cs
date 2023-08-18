using UnityEngine;
using UnityEngine.UI;


public class DraGG : MonoBehaviour
{
    [SerializeField] private  GameObject ParentTransistion;
    private bool isDraging;
    private Transform InitParent;
    private Vector3 InitPos;
    private Vector3 SCaleValue;
     public Transform target,TransData;
   
    void Start()
    {
        InitParent = gameObject.transform.parent;
        InitPos =  gameObject.transform.localPosition;
        SCaleValue= gameObject.transform.localScale;
        TransData = gameObject.transform;
    }
    
   
    void Update()
    {
        if(isDraging)
        {
        gameObject.transform.position = ParentTransistion.transform.position;  
        gameObject.transform.LookAt(Camera.main.transform); 
        gameObject.transform.Rotate(0,180,0);
        }
    }


    public void DownMouse()
    {
        isDraging = true;
        gameObject.transform.parent= ParentTransistion.transform;
        gameObject.transform.localScale = new Vector3(2,1,1);   
        this.gameObject.GetComponent<Image>().raycastTarget = false; 
    }


    public void UpMouse()
    {
         isDraging =false;
        gameObject.transform.parent = InitParent;
        gameObject.transform.localPosition = InitPos;
        gameObject.transform.localScale = SCaleValue;
        gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0,0,0));
        this.gameObject.GetComponent<Image>().raycastTarget = true;   
    }

  
}
