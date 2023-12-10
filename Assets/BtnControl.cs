using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnControl : MonoBehaviour
{
    public GameObject Stopplane;
    public GameObject Againplane;


    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnClick(){
        Application.Quit();
    }
    public void Stopppplane(){
        Stopplane.SetActive(true);
    }

    public void Lv1_Stop()
    {
        SceneManager.LoadScene("StopPlane");
    }
    public void Lv1_Scene()
    {
        SceneManager.LoadScene("S1");
    }
    public void AgainLv1()
    {
        SceneManager.LoadScene("S1");
        Againplane.SetActive(false);
        
    }
    
    
  
}

