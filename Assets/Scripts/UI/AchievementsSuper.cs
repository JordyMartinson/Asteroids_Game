using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementsSuper : MonoBehaviour
{
    public AchPanel achPrefab;

    public static int numAchs = 4;

    public string[] codes =
        new string[] {"", "Ach01", "Ach02", "Ach03"};
    public string[] titles =
        new string[] {"", "High Scorer", "Watch Where You're Going", "Survivor"};
    public string[] descriptions =
        new string[] {"?", "Score 1000 points", "Die to the same asteroid twice", "Survive for 60 seconds"};
    public Texture[] textures = new Texture[numAchs];

    // public string achTitle;
    public string achDescStr;
    public Texture achImage;

    public void Reset() {
        GameObject[] prefabs = GameObject.FindGameObjectsWithTag("Achievement");
        foreach(GameObject prefab in prefabs) {
            Destroy(prefab);
        }
    }
}
