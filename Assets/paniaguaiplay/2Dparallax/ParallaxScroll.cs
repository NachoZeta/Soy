using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScroll : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed;
    [SerializeField]
    private Transform playerTransform;

    private List<GameObject> spritesList;
    private int playerPosIndex = 1;
    private float playerXOffset;
    private float lastXPlayerPosition;
    private float xScale;
    private float pixelsPerUnit;

    private void Awake()
    {
        lastXPlayerPosition = playerTransform.position.x;
        SetInitialSpritesPosition();
    }

    void FixedUpdate()
    {
        playerXOffset = playerTransform.position.x - lastXPlayerPosition;
        lastXPlayerPosition = playerTransform.position.x;
        transform.Translate(Vector2.right * playerXOffset * scrollSpeed);

        float xPlayer = playerTransform.position.x;
        GameObject currentGO = spritesList[playerPosIndex];
        Sprite currentSprite = currentGO.GetComponent<SpriteRenderer>().sprite;
        Texture currentTexture = currentSprite.texture;
        
        float xBG = currentGO.transform.position.x;
        float realCurrentSpriteWidth = currentTexture.width * xScale / pixelsPerUnit;
        if (xPlayer > (xBG + realCurrentSpriteWidth / 2))
        {
            spritesList[0].transform.position = spritesList[1].transform.position;
            spritesList[1].transform.position = spritesList[2].transform.position;
            spritesList[2].transform.position = new Vector2(
                spritesList[2].transform.position.x + currentSprite.texture.width * xScale / pixelsPerUnit,
                spritesList[2].transform.position.y
            );
        } 
        else if (xPlayer < (xBG - realCurrentSpriteWidth / 2))
        {
            spritesList[2].transform.position = spritesList[1].transform.position;
            spritesList[1].transform.position = spritesList[0].transform.position;
            spritesList[0].transform.position = new Vector2(
                spritesList[0].transform.position.x - currentSprite.texture.width * xScale / pixelsPerUnit,
                spritesList[0].transform.position.y
            );
        }
    }

    private void SetInitialSpritesPosition()
    {
        spritesList = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            spritesList.Add(transform.GetChild(i).gameObject);
        }
        Sprite sprite0 = spritesList[0].GetComponent<SpriteRenderer>().sprite;
        xScale = spritesList[0].transform.localScale.x;
        pixelsPerUnit = sprite0.pixelsPerUnit;

        spritesList[0].transform.position = new Vector2(
            spritesList[0].transform.position.x - sprite0.texture.width * xScale / pixelsPerUnit,
            spritesList[0].transform.position.y
        );
        spritesList[2].transform.position = new Vector2(
            spritesList[2].transform.position.x + sprite0.texture.width * xScale/ pixelsPerUnit,
            spritesList[2].transform.position.y
        );
    }
}
