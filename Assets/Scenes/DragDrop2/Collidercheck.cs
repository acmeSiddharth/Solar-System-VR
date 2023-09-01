using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collidercheck : MonoBehaviour
{
    Vector3 scle;
    // Start is called before the first frame update
    void Start()
    {
        scle= gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnCollisionStay(Collision collide)
    {
        if(collide.transform.tag == gameObject.transform.tag)
        {
            gameObject.transform.localScale = new Vector3(.2f,.2f,.2f);
        }
    }

    public void OnCollisionExit(Collision collide)
    {
       if(collide.transform.tag == gameObject.transform.tag)
       {
        gameObject.transform.localScale = scle;
       }
    }
}
