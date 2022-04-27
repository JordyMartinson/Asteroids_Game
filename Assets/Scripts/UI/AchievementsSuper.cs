using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsSuper : MonoBehaviour
{
    public AchPanel achPrefab;
    public Texture achImage;
    public Texture[] textures = new Texture[numAchs];
    public static int numAchs = 4;
    protected string[] codes =
        new string[] {"", "Ach01", "Ach02", "Ach03"};
    protected string[] titles =
        new string[] {"", "High Scorer", "Watch Where You're Going", "Survivor"};
    protected string[] descriptions =
        new string[] {"?", "Score 1000 points", "Die to the same asteroid twice", "Survive for 60 seconds"};
    protected string achDescStr;
    
    protected void Reset() {
        GameObject[] prefabs = GameObject.FindGameObjectsWithTag("Achievement");
        foreach(GameObject prefab in prefabs) {
            Destroy(prefab);
        }
    }
}
