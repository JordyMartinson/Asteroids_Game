using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections; 
using System.Collections.Generic;

public static class SaveManager
{
    private static string pathBase = Application.persistentDataPath;
    private static string path;
    public static ArrayList profiles;
    public static PlayerData currentPlayer;

    public static void SavePlayer(PlayerData playerData) {
        path = pathBase + "/" + playerData.name + ".save";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);
        formatter.Serialize(stream, playerData);
        stream.Close();
        currentPlayer = playerData;
    }

    public static void UpdateSave(PlayerData playerData) {
        PlayerData old = SaveManager.LoadPlayer(playerData.getPlayerID());
        if(playerData.curScore > old.highScore) {
            playerData.highScore = playerData.curScore;
        } else {
            playerData.highScore = old.highScore;
        }
        playerData.timePlayed = old.timePlayed + (int)playerData.curTime;
        playerData.bulletsFired += old.bulletsFired;
        SavePlayer(playerData);
    }

    public static PlayerData LoadPlayer(int id) {
        PlayerData temp = null;
        foreach(PlayerData p in profiles) {
            if(p.getPlayerID() == id) {
                temp = p;
            }
        }
        string name = temp.name;
        path = pathBase + ("/" + name + ".save");
        if (File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            data.playerID = id;
            return data;            
        } else {
            // Debug.LogError("Save file not found, creating default");
            return null;
            // Player defPlayer = new Player();
            // defPlayer.playerName = "Default";
            // PlayerData defPlayerData = new PlayerData(defPlayer);
            // SavePlayer(defPlayerData);

            // BinaryFormatter formatter = new BinaryFormatter();
            // FileStream stream = new FileStream(path, FileMode.Open);
            // PlayerData defData = formatter.Deserialize(stream) as PlayerData;
            // stream.Close();
            // return defData;
        }
    }

    public static ArrayList loadProfiles() {
        int i = 0;
        BinaryFormatter formatter1 = new BinaryFormatter();

        if(Directory.GetFiles(pathBase, "*.save").Length == 0) {
            Player newPlayer = new Player();
            newPlayer.playerName = "Default";
            PlayerData pd = new PlayerData(newPlayer);
            pd.setMusicVol(1f);
            pd.setSFXVol(1f);
            Debug.Log(pd.getCodes()[0]);
            SavePlayer(pd);
        }

        ArrayList profiles = new ArrayList();
        foreach (string f in Directory.EnumerateFiles(pathBase, "*.save")) {
            FileStream stream1 = new FileStream(f, FileMode.Open);
            PlayerData data1 = formatter1.Deserialize(stream1) as PlayerData;
            data1.playerID = i;
            // Debug.Log(data1.name + " " + data1.playerID);
            stream1.Close();
            profiles.Add(data1);
            i++;
        }
        return profiles;
    }
}
