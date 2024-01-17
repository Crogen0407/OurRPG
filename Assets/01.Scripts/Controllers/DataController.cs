using System;
using System.IO;
using UnityEngine;

public class DataController : MonoBehaviour
{
    private object _saveData;
    private string _filePath;
    private string _jsonData;
    
    private void Awake()
    {
        _filePath = Application.persistentDataPath + "/SaveData.json";
    }

    public string Save<T>(T saveData)
    {
        _saveData = saveData;

        string jsonData = JsonUtility.ToJson(_saveData, true);
        _jsonData = jsonData;
        FileStream fs = File.Create(_filePath);
        StreamWriter sw = new StreamWriter(fs);
        sw.Write(jsonData);
        sw.Close();
        Debug.Log(_filePath);
        return jsonData;
        
    }

    public T Load<T>()
    {
        FileStream fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs);
        T saveData = JsonUtility.FromJson<T>(sr.ReadToEnd());
        sr.Close();

        _saveData = saveData;
        return saveData;
    }
}
