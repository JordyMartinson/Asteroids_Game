using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    private PlayerData playerData;
    private SpriteRenderer spriteRenderer;
    private Sprite[] sprites;
    private int spriteNum;

    private IEnumerator Start() {
        yield return new WaitForSeconds(0.1f);
        playerData = SaveManager.currentPlayer;
        sprites = Resources.LoadAll<Sprite>("Sprites");
        spriteRenderer = GameObject.Find("PlayerSprite").GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[playerData.getSpriteNum()];
    }

    private void setSprite() {
        playerData = SaveManager.LoadPlayer(0);
        spriteRenderer.sprite = sprites[playerData.getSpriteNum()];
    }

    private void spritePlus() {
        playerData = SaveManager.currentPlayer;
        spriteNum = playerData.getSpriteNum();
        spriteNum += 1;
        if(spriteNum >= sprites.Length) {
            spriteNum = 0;
        }
        spriteRenderer.sprite = sprites[spriteNum];
        playerData.setSpriteNum(spriteNum);
        SaveManager.SavePlayer(playerData);
    }

    private void spriteMinus() {
        playerData = SaveManager.currentPlayer;
        spriteNum = playerData.getSpriteNum();
        spriteNum -= 1;
        if(spriteNum < 0) {
            spriteNum = sprites.Length-1;
        }
        spriteRenderer.sprite = sprites[spriteNum];
        playerData.setSpriteNum(spriteNum);
        SaveManager.SavePlayer(playerData);
    }

    public int getSpriteNum() {
        return this.spriteNum;
    }
}
