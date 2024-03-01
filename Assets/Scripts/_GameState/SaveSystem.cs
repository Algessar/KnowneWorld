using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;

[System.Serializable]
public static class SaveSystem
{
    //public static readonly string SAVE_FOLDER = Application.dataPath + "/Saves/";

    // TODO: SaveSystem: Make functionality for saving new file based on name.


    public static void SaveCharacter( Character character )
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string fileName = character._name + ".saved";
        string path = Path.Combine(Application.dataPath + "/Saves/", fileName);
        //string path = Application.dataPath + "/Saves/character.saved";

        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(character);

        formatter.Serialize(stream, data);
        stream.Close();
                
        //Perhaps possible to put all the saved file in a list somewhere?

    }

    public static PlayerData LoadCharacter( string characterName ) // public static PlayerData LoadCharacter(string characterName) /// somehow get the name of the specific character to load
    {

        string fileName = characterName + ".saved";
        string path = Path.Combine(Application.dataPath + "/Saves/", fileName);
        //string path = Application.dataPath + "/Saves/character.saved";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("Save file not found in " + path);

            return null;
        }
    }

    public static void Save<T>( T obj, string fileName, int ID = 0 ) where T : class
    {
        string path = Path.Combine(Application.dataPath, "/Saves/", fileName + ".saved");
        string path2 = Path.Combine(Application.dataPath, "/Saves/", ID + ".saved");

        try
        {
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);

                stream.Close();
            }

            Debug.Log("Object saved successfully to: " + path);
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to save object: " + e.Message);
        }        
    }

    public static void Load<T>( string fileName, int ID = 0 ) where T : class
    {
        string path = Path.Combine(Application.dataPath + "/Saves/", fileName);
        //string path = Application.dataPath + "/Saves/character.saved";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            
        }
        else
        {
            Debug.Log("Save file not found in " + path);
           
        }
    }
}
