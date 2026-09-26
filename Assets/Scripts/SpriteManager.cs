using UnityEngine;

public class SpriteManager : MonoBehaviour
{
    public SpriteRenderer spriteRender;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ChangePlayerSprite(Sprite newSprite)
    {
        spriteRender.sprite = newSprite;
    }
}
