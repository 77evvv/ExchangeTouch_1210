using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class SpriteHitPic : MonoBehaviour
{
    [SerializeField]  SpriteAtlas atlas;
    public Image myImage;
    [SerializeField]  public static string spriteName;
    // Start is called before the first frame update

    private void Awake()
    {
       
        
    }

    void Start()
    {
        myImage = GetComponent<Image>();
        spriteName = "";
    }

    // Update is called once per framez
    void Update()
    {
        if (spriteName == "")
        {
            myImage.color = Color.clear;
        }
        else
        {
            myImage.color = Color.white;
            myImage .sprite = atlas.GetSprite(spriteName);
        }
        
    }
}
