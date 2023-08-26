using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DargDropActivityTwo : MonoBehaviour
{
    private Vector3 InitialPos, ScaleLocal;
    [SerializeField] Transform TransformParent;
    private Transform InitialParent;
    private Vector3 Offset;
    private bool Isdrag;
    public GvrReticlePointer RectileRay;



    // Start is called before the first frame update
    void Start()
    {

        InitialPos = gameObject.transform.position;
        InitialParent = gameObject.transform.parent;
        ScaleLocal = gameObject.transform.localScale;

    }
    public void Update()
    {
            Debug.Log(RectileRay.ReticleDistanceInMeters);
        if (Isdrag)
        {
            gameObject.transform.position = Camera.main.GetComponentInChildren<GvrReticlePointer>().transform.position  +new Vector3(0,0, RectileRay.ReticleDistanceInMeters);


            Debug.Log(transform.position);
        }
    }

    public void OnMouseDown()
    {
        Isdrag = true;
       // Offset = gameObject.transform.position - Camera.main.transform.position;
        //gameObject.transform.parent = TransformParent.transform;
        gameObject.transform.parent = Camera.main.GetComponentInChildren<GvrReticlePointer>().transform;
        //gameObject.transform.position = TransformParent.transform.position;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        Debug.Log(Offset);
        Reshape();
    }

    public void OnMouseUp()
    {
        Isdrag = false;
        StartCoroutine(Waitr());

    }

    private void Reshape()
    {
        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    IEnumerator Waitr()
    {
        yield return new WaitForSeconds(4);
        gameObject.transform.parent = InitialParent;
        TransformParent.localPosition = InitialPos;
        TransformParent.localScale = ScaleLocal;
        gameObject.GetComponent<SphereCollider>().enabled = true;
    }
}
