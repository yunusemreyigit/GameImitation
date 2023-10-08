using UnityEngine;
using System.IO;

public class DataHandling : MonoBehaviour
{
    public static DataHandling Instance;
    private void Awake()
    {
        Instance = this;
    }
    string getPath(string file)
    {
        return Application.dataPath + "/Data/" + file + ".txt";
    }
    void WritetoFile(string path, string content)
    {
        File.WriteAllText(path, content);
    }
    string ReadFile(string path)
    {
        return File.ReadAllText(path);
    }
    public void Save(string file, string content)
    {
        WritetoFile(getPath(file), content);
    }
    public string Load(string file)
    {
        return ReadFile(getPath(file));
    }
}
