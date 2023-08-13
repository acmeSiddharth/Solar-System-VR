using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageAnimationTime : MonoBehaviour
{
    public GameObject Mercury;
    public Transform MercuryOGPOS;

    public GameObject Venus;
    public Transform VenusOGPOS;

    public GameObject Earth;
    public Transform EarthOGPOS;

    public GameObject Mars;
    public Transform MarsOGPOS;

    public GameObject Jupiter;
    public Transform JupiterOGPOS;

    public GameObject Saturn;
    public Transform SaturnOGPOS;

    public GameObject Uranus;
    public Transform UranusOGPOS;

    public GameObject Neptune;
    public Transform NeptuneOGPOS;

    public GameObject Orbit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(StopAnim());
    }

    IEnumerator StopAnim()
    {
        yield return new WaitForSeconds(83f);
        Mercury.GetComponent<Revloution>().enabled = false;
        Mercury.transform.position =MercuryOGPOS.position;

        Venus.GetComponent<Revloution>().enabled = false;
        Venus.transform.position = VenusOGPOS.position;

        Earth.GetComponent<Revloution>().enabled = false;
        Earth.transform.position = EarthOGPOS.position;

        Mars.GetComponent<Revloution>().enabled = false;
        Mars.transform.position = MarsOGPOS.position;

        Jupiter.GetComponent<Revloution>().enabled = false;
        Jupiter.transform.position = JupiterOGPOS.position;

        Saturn.GetComponent<Revloution>().enabled = false;
        Saturn.transform.position = SaturnOGPOS.position;

        Uranus.GetComponent<Revloution>().enabled = false;
        Uranus.transform.position = UranusOGPOS.position;

        Neptune.GetComponent<Revloution>().enabled = false;
        Neptune.transform.position = NeptuneOGPOS.position;

        Orbit.SetActive(false);
    }
}
