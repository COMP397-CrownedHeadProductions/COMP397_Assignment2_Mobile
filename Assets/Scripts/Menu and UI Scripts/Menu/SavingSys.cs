using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SavingSys
{
    public static void SavePlayer(PlayerController player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath+"/player.bin";
        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerDat dat = new PlayerDat(player);
        formatter.Serialize(stream, dat);
        stream.Close();
    }
    public static PlayerDat LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.bin";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerDat dat = formatter.Deserialize(stream) as PlayerDat;
            stream.Close();
            return dat;
        }
        else
        {
            Debug.LogError("NO SAVES IN " + path);
            return null;
        }
    }
}
