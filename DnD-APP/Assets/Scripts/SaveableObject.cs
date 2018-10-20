using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public abstract class SaveableObject : MonoBehaviour {

    protected string DataLocation = "/";

    protected int identifier = -1;

	protected  void Save(object serializableObject)
    {
        Directory.CreateDirectory(Application.persistentDataPath + DataLocation);

        if (!File.Exists(Application.persistentDataPath + DataLocation + identifier + ".dat") || identifier == -1)
        {
            identifier = GetIdentifier();
        }

        Debug.Log(Application.persistentDataPath + DataLocation + identifier + ".dat");

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + DataLocation + identifier + ".dat");

        formatter.Serialize(file, serializableObject);
        file.Close();
    }

    protected object Load()
    {
        if(File.Exists( Application.persistentDataPath + DataLocation + identifier + ".dat" ))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + DataLocation + identifier + ".dat", FileMode.Open);
            object data = formatter.Deserialize(file);
            file.Close();

            return data;
        }
        return null;
    }

    protected int GetIdentifier()
    {
        try
        {
            string file = Directory.GetFiles(Application.persistentDataPath + DataLocation)
            .Select(filename => Path.GetFileNameWithoutExtension(filename))
            .OrderBy(f => f)
            .Max();
            int.TryParse(file, out identifier);
            identifier++;
        }
        catch (DirectoryNotFoundException e)
        {
            Debug.Log(e);
            identifier = 0;
        }
        return identifier;
    }

    public abstract void SaveObject();
    public abstract void LoadObject();
}
