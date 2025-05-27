using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteCHanger : MonoBehaviour
{
    public Sprite newSprite;

    private Image sprite;


    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<Image>();
    }

    public void ChangeSprite() 
    {
      sprite.sprite = newSprite;
        sprite.SetNativeSize();
    }
    public void ChangeColor() 
    {
        sprite.color = Color.cyan;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
