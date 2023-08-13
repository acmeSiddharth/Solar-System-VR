using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManageMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VrTour()
    {
        SceneManager.LoadScene("VrTour");
    }

    public void SelfExplore()
    {
        SceneManager.LoadScene("SelfExplore");
    }

    public void Activities()
    {
        SceneManager.LoadScene("Activities");
    }

   

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    public void OpenMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartVrTourScene()
    {
        SceneManager.LoadScene("VrTour");
    }

    public void RestartSelfExploreScene()
    {
        SceneManager.LoadScene("SelfExplore");
    }

    
}
