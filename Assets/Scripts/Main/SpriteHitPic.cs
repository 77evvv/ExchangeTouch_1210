using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class SpriteHitPic : MonoBehaviour
{
    [SerializeField]  SpriteAtlas atlas;

    [SerializeField]  public static string spriteName;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
        spriteName = "Start";
       
        
    }

    // Update is called once per framez
    void Update()
    {
        gameObject.SetActive(true);
        GetComponent<Image>().sprite = atlas.GetSprite(spriteName);
    }
}
