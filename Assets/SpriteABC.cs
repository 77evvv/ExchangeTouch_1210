using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class SpriteABC : MonoBehaviour

{
    [SerializeField]  SpriteAtlas atlas;
    [SerializeField]  public static string spriteABCName;
    // Start is called before the first frame update
    void Start()
    {
        spriteABCName = "S";
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().sprite = atlas.GetSprite(spriteABCName);
    }
}
