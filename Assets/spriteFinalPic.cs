using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class spriteFinalPic : MonoBehaviour
{
    [SerializeField]  SpriteAtlas atlas;
    [SerializeField]  public static string spriteFinalName;
    // Start is called before the first frame update
    void Start()
    {
        spriteFinalName= "A_img";
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().sprite = atlas.GetSprite(spriteFinalName);

    }
}
