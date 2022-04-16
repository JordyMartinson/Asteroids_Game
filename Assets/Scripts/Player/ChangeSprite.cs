using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    private PlayerData playerData;
    public SpriteRenderer spriteRenderer;
    // private string path = "Assets/Galaxia Sprite Pack #1/Enemy/idle_bomber_green.png";
    private Sprite[] sprites;
    private int spriteNum;

    public void Awake() {

    }

    IEnumerator Start() {
        yield return new WaitForSeconds(0.1f);
        playerData = SaveManager.currentPlayer; //change to current player
        // Debug.Log("spritenum " + playerData.spriteNum);
        sprites = Resources.LoadAll<Sprite>("Sprites");
        spriteRenderer = GameObject.Find("PlayerSprite").GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[playerData.getSpriteNum()];
    }

    public void setSprite() {
        playerData = SaveManager.LoadPlayer(0); //change to current player
        // Debug.Log(playerData.name);
        spriteRenderer.sprite = sprites[playerData.getSpriteNum()];
    }

    public void spritePlus() {
        playerData = SaveManager.currentPlayer;
        spriteNum = playerData.getSpriteNum();
        spriteNum += 1;
        if(spriteNum >= sprites.Length) {
            spriteNum = 0;
        }
        spriteRenderer.sprite = sprites[spriteNum];
        // Debug.Log("before" + playerData.getSpriteNum());
        playerData.setSpriteNum(spriteNum);
        // Debug.Log("after" + playerData.getSpriteNum());
        SaveManager.SavePlayer(playerData);
    }

    public void spriteMinus() {
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
