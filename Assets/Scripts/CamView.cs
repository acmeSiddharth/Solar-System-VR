using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamView : MonoBehaviour
{
    public GameObject player;

    public GameObject SunView;
    public GameObject MercuryView;
    public GameObject VenusView;
    public GameObject EarthView;
    public GameObject MarsView;
    public GameObject JupiterView;
    public GameObject SaturnView;
    public GameObject UranusView;
    public GameObject NeptuneView;
    public GameObject MoonView;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UiSun()
    {
        player.transform.position = SunView.transform.position;
        //player.GetComponent<SvrPlayerController>().enabled = false;
    }

    public void UiMercury()
    {
        player.transform.position= MercuryView.transform.position;
        //player.GetComponent<SvrPlayerController>().enabled = false;
    }

    public void UIVenus()
    {
        player.transform.position = VenusView.transform.position;
        //player.GetComponent<SvrPlayerController>().enabled = false;

    }

    public void UIEarth()
    {
        player.transform.position = EarthView.transform.position;
        //player.GetComponent<SvrPlayerController>().enabled = false;
    }

    public void UIMars()
    {
        player.transform.position = MarsView.transform.position;
        //player.GetComponent<SvrPlayerController>().enabled = false;
    }

    public void UIJupiter()
    {
        player.transform.position = JupiterView.transform.position;
        //player.GetComponent<SvrPlayerController>().enabled = false;
    }

    public void UISaturn()
    {
        player.transform.position = SaturnView.transform.position;
        //player.GetComponent<SvrPlayerController>().enabled = false;
    }

    public void UIUranus()
    {
        player.transform.position = UranusView.transform.position;
        //player.GetComponent<SvrPlayerController>().enabled = false;
    }

    public void UINeptune()
    {
        player.transform.position = NeptuneView.transform.position;
        //player.GetComponent<SvrPlayerController>().enabled = false;
    }

    public void UiMoon()
    {
        player.transform.position = MoonView.transform.position;
        //player.GetComponent<SvrPlayerController>().enabled = false;
    }
}
