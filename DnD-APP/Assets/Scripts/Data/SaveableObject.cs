using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public abstract class SaveableObject {

    public string name = "";

    protected string DataLocation = "/";

    public int identifier = -1;

	protected  void Save(object serializableObject)
    {
        Directory.CreateDirectory(Application.persistentDataPath + DataLocation);

        if (!File.Exists(Application.persistentDataPath + DataLocation + identifier + ".dat") || identifier == -1)
        {
            identifier = GetIdentifier();
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + DataLocation + identifier + ".dat");

        formatter.Serialize(file, serializableObject);
        file.Close();

        Debug.Log("Saved: " + DataLocation + identifier);
    }

    protected object Load()
    {
        if(File.Exists( Application.persistentDataPath + DataLocation + identifier + ".dat" ))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + DataLocation + identifier + ".dat", FileMode.Open);
            object data = formatter.Deserialize(file);
            file.Close();

            Debug.Log("Loaded: " + DataLocation + identifier);

            return data;
        }
        return null;
    }

    protected void Delete(object serializableObject)
    {
        if (File.Exists(Application.persistentDataPath + DataLocation + identifier + ".dat"))
        {
            File.Delete(Application.persistentDataPath + DataLocation + identifier + ".dat");
            Debug.Log("Deleted: " + DataLocation + identifier + ".dat");
        }
    }

    protected int GetIdentifier()
    {
        try
        {
            string file = Directory.GetFiles(Application.persistentDataPath + DataLocation)
            .OrderByDescending(d => new FileInfo(d).CreationTime)
            .Select(filename => Path.GetFileNameWithoutExtension(filename))
            .First();
            int.TryParse(file, out identifier);
            identifier++;
        }
        catch
        {
            identifier = 0;
        }
        return identifier;
    }

    public abstract void SaveObject();
    public abstract void LoadObject();

    public List<T> LoadAll<T> () where T : SaveableObject, new()
    {
        List<T> returnList = new List<T>();

        Directory.CreateDirectory(Application.persistentDataPath + DataLocation);

        List<string> files = Directory.GetFiles(Application.persistentDataPath + DataLocation)
            .OrderBy(d => new FileInfo(d).CreationTime)
            .Select(filename => Path.GetFileNameWithoutExtension(filename))
            .ToList();

        foreach(string file in files)
        {
            T saveableObject = new T();
            saveableObject.identifier = int.Parse(file);
            saveableObject.LoadObject();

            returnList.Add(saveableObject);
        }
        return returnList;
    }
}
