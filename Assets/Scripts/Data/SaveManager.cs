using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveManager
{
    private static string pathBase = Application.persistentDataPath; // + "/player.save";
    private static string path;
    private static PlayerData[] profiles;

    // public static void SavePlayer(Player player) {
    //     path = pathBase + "/" + player.playerName + ".save";
    //     BinaryFormatter formatter = new BinaryFormatter();
    //     FileStream stream = new FileStream(path, FileMode.Create);
    //     PlayerData data = new PlayerData(player);
    //     formatter.Serialize(stream, data);
    //     stream.Close();
    // }

    public static void SavePlayer(PlayerData playerData) {
        // Debug.Log(player.name);
        path = pathBase + "/" + playerData.name + ".save";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        // PlayerData data = new PlayerData(player);
        formatter.Serialize(stream, playerData);
        stream.Close();
        // Debug.Log(LoadPlayer().highScore);
    }

    // public static void UpdateSave(Player player) {
    //     Debug.Log("Name: " + player.name);
    //     PlayerData old = SaveManager.LoadPlayer();
    //     if(player.curScore > old.highScore) {
    //         Debug.Log("CurScore: " + player.curScore);
    //         Debug.Log("HighScore: " + old.highScore);
    //         player.highScore = player.curScore;
    //     } else {
    //         player.highScore = old.highScore;
    //     }
    //     player.timePlayed = old.timePlayed + (int)player.curTime;
    //     player.bulletsFired += old.bulletsFired;
    //     SaveManager.SavePlayer(player);
    // }

    public static void UpdateSave(PlayerData playerData) {
        // Debug.Log("Name: " + playerData.name);
        PlayerData old = SaveManager.LoadPlayer();
        // Debug.Log("CurScore old: " + old.curScore);
        // Debug.Log("CurScore new: " + playerData.curScore);
        if(playerData.curScore > old.highScore) {
            // Debug.Log("CurScore: " + playerData.curScore);
            // Debug.Log("HighScore old: " + playerData.highScore);
            playerData.highScore = playerData.curScore;
            // Debug.Log("HighScore new: " + playerData.highScore);
        } else {
            playerData.highScore = old.highScore;
        }
        // Debug.Log("HighScore new: " + playerData.highScore);
        playerData.timePlayed = old.timePlayed + (int)playerData.curTime;
        Debug.Log("bullets " + playerData.bulletsFired);
        playerData.bulletsFired += old.bulletsFired;
        SaveManager.SavePlayer(playerData);
    }

    public static PlayerData LoadPlayer() {
        // path += ("/" + playerName + ".save");
        path = pathBase + "/" + "Default" + ".save";
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;            
        } else {
            // Debug.LogError("Save file not found, creating default");
            Player defPlayer = new Player();
            defPlayer.playerName = "Default";
            PlayerData defPlayerData = new PlayerData(defPlayer);
            SavePlayer(defPlayerData);

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData defData = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return defData;
        }
    }

    // public static PlayerData LoadPlayer(string name) {
    //     path += ("/" + name + ".save");
    //     // path = pathBase + "/" + "Default" + ".save";
    //     if (File.Exists(path)) {
    //         BinaryFormatter formatter = new BinaryFormatter();
    //         FileStream stream = new FileStream(path, FileMode.Open);
    //         PlayerData data = formatter.Deserialize(stream) as PlayerData;
    //         stream.Close();
    //         return data;            
    //     } else {
    //         Debug.LogError("Save file not found, creating default");
    //         return null;
    //         // Player defPlayer = new Player();
    //         // defPlayer.playerName = "Default";
    //         // PlayerData defPlayerData = new PlayerData(defPlayer);
    //         // SavePlayer(defPlayerData);

    //         // BinaryFormatter formatter = new BinaryFormatter();
    //         // FileStream stream = new FileStream(path, FileMode.Open);
    //         // PlayerData defData = formatter.Deserialize(stream) as PlayerData;
    //         // stream.Close();
    //         // return defData;
    //     }
    // }

    public static void Start() {
        DirectoryInfo dir = new DirectoryInfo(pathBase);
        FileInfo[] info = dir.GetFiles("*.save*");
        foreach (FileInfo f in info) {
            Debug.Log(f);
        }
    }
}
