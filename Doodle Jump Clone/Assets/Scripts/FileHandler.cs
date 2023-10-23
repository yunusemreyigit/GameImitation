using System;
using System.IO;
using UnityEngine;

public static class FileHandler
{
    public static void saveToJSON(InputHandler content, string file)
    {
        Debug.Log(getPath(file));
        string convertedContent = JsonUtility.ToJson(content);
        Debug.Log(convertedContent);
        writeToFile(convertedContent, getPath(file));
    }
    public static InputHandler loadFromJson(string file)
    {
        string content = readFromFile(getPath(file));
        if (String.IsNullOrEmpty(content) || content == "{}")
        {
            return new InputHandler(0, 0);
        }
        InputHandler result = JsonUtility.FromJson<InputHandler>(content);
        return result;
    }
    private static string getPath(string fileName)
    {
        return Application.persistentDataPath + "/" + fileName;
    }
    private static void writeToFile(string content, string path)
    {
        FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
        if (File.Exists(path))
        {
            StreamWriter sw = new StreamWriter(fileStream);
            sw.WriteLine(content);
            sw.Close();
        }
    }
    private static string readFromFile(string path)
    {

        if (File.Exists(path))
        {
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fileStream);
            string temp = reader.ReadLine();
            reader.Close();
            return temp;
        }
        return "";
    }
}
