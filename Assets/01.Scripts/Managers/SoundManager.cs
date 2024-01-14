using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoSingleton<SoundManager>
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private SO_SoundVolumeData _soundVolumeData;
    [SerializeField] private TextAsset _data;
    
    [Space]
    public TextMeshProUGUI _msSoundVolumeText;
    public TextMeshProUGUI _bgmSoundVolumeText;
    public TextMeshProUGUI _sfSoundVolumeText;
    
    private SoundData _saveData;
    private string _filePath;
    private string _jsonData;
    
    void Awake()
    {
        _soundVolumeData.Init(new []{_msSoundVolumeText, _bgmSoundVolumeText, _sfSoundVolumeText});
        _filePath = Application.persistentDataPath + "/SoundData.json";

    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void Start()
    {
        LoadSoundVolume();
    }
    
    public void LoadSoundVolume()
    {
        Save(new SoundData()
        {
            msVolume = Mathf.Log10((_soundVolumeData.MSSoundVolume == 0 ? 0.0001f : _soundVolumeData.MSSoundVolume) /
                                   10f) * 20,
            bgVolume = Mathf.Log10((_soundVolumeData.BGMSoundVolume == 0 ? 0.0001f : _soundVolumeData.BGMSoundVolume) /
                                   10f) * 20,
            sfVolume = Mathf.Log10((_soundVolumeData.SFSoundVolume == 0 ? 0.0001f : _soundVolumeData.SFSoundVolume) /
                                   10f) * 20
        });
        
        _audioMixer.SetFloat("Master", Load().msVolume);
        _audioMixer.SetFloat("BGM", Load().bgVolume);
        _audioMixer.SetFloat("SFX", Load().sfVolume);
    }

    public string Save(SoundData saveData)
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

    public SoundData Load()
    {
        FileStream fs = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
        StreamReader sr = new StreamReader(fs);
        SoundData saveData = JsonUtility.FromJson<SoundData>(sr.ReadToEnd());
        sr.Close();

        _saveData = saveData;
        return saveData;
    }
}
