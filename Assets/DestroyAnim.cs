using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnim : MonoBehaviour
{
    public GameObject EXPCUBE;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DesMove()
    {
        Destroy(gameObject);
        //Debug.Log("OKDS");

    }
    
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CubeDS")
        {
           Destroy(gameObject);
            Debug.Log("有刪除");
        }
    }*/
}
