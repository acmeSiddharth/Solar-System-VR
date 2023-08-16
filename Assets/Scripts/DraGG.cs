
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class DraGG : MonoBehaviour
{
    [SerializeField] private  GameObject ParentTransistion;
    private bool isDraging;
    private Transform InitParent;
    private Vector3 InitPos;
    private Vector3 SCaleValue;
    


    // Start is called before the first frame update
    void Start()
    {
       InitPos = gameObject.GetComponent<RectTransform>().transform.position;
       InitParent = gameObject.transform.parent;
       SCaleValue= gameObject.transform.localScale;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(isDraging)
        {
            gameObject.transform.position = ParentTransistion.transform.position;
        }
    }

    public void DownMouse()
    {
        isDraging = true;
      gameObject.transform.parent = ParentTransistion.transform;
      //gameObject.transform.position = new Vector3(0,0,0);
      gameObject.transform.localScale = new Vector3(1,1,1);
        
    }
    public void UpMouse()
    {
        
        isDraging =false;
       
       
       gameObject.transform.parent = InitParent;
       gameObject.transform.position = InitPos;
       gameObject.transform.localScale = SCaleValue;
        
    
    }
}
