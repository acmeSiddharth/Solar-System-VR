using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageAnimAndAudio : MonoBehaviour
{

    public bool Stoprevolution = false;

    public GameObject Mercury;
    public GameObject Venus;
    public GameObject Earth;
    public GameObject Mars;
    public GameObject Jupiter;
    public GameObject Satrun;
    public GameObject Uranus;
    public GameObject Neptune;
    public GameObject Pluto;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(RevolutionBool());

        if (Stoprevolution == true)
        {
            Mercury.GetComponent<Revloution>().enabled = false;
        }
    }

    IEnumerator RevolutionBool()
    {
        yield return new WaitForSeconds(5f);
        Stoprevolution = true;
    }


}
