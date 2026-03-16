using UnityEngine;
using System.Collections.Generic;
using System.IO;
public class FileDataService : IDataService
{
    private ISerializer serializer;
    private string datapath; //location of file
    private string fileExt;

    public FileDataService(ISerializer serializer)
    {
        this.serializer = serializer; //injecting the serializer dependency
        datapath = Application.persistentDataPath; //saved at LocalLow/comp-397
        fileExt = ".json";
    } //define the location for save files, using Unity's persistent data path
    private string GetPathFile(string filename)
    {
        return Path.Combine(datapath, string.Concat(filename, fileExt));
    }
    public void Save(GameData data, bool overwrite = true)
    {
        string fileLoc = GetPathFile(data.fileName);
        if (!overwrite && File.Exists(fileLoc))
            throw new IOException("File already exists and can't be overwritten.");
        File.WriteAllText(fileLoc, serializer.Serialize(data));
    } //adds data to file location

    public GameData Load(string fileName)
    {
        string fileLoc = GetPathFile(fileName);
        if (!File.Exists(fileLoc))
            throw new System.Exception("No persistent data found at " + fileLoc + ".");
        return serializer.Deserialize<GameData>(File.ReadAllText(fileLoc));
    }

    public void Delete(string fileName)
    {
        string fileLoc = GetPathFile(fileName);
        if (File.Exists(fileLoc))
            File.Delete(fileLoc);
    }

    public IEnumerable<string> ListSaves()
    {
        foreach (string path in Directory.EnumerateFiles(datapath))
        {
            if (Path.GetExtension(path) == fileExt)
                yield return Path.GetFileNameWithoutExtension(path);
        } //iterates through files in the data path and returns
    }     //names of files with the correct extension
}