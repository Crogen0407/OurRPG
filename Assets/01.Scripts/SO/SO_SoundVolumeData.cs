using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/SoundVolumeData", fileName = "SoundVolumeData")]
public class SO_SoundVolumeData : ScriptableObject
{
    private TextMeshProUGUI _msSoundVolumeText;
    private TextMeshProUGUI _bgmSoundVolumeText;
    private TextMeshProUGUI _sfSoundVolumeText;
    
    [SerializeField] private int _msSoundVolume = 0;
    [SerializeField] private int _bgmSoundVolume = 0;
    [SerializeField] private int _sfSoundVolume = 0;

    public void Init(TextMeshProUGUI[] volumeText)
    {
        _msSoundVolumeText = volumeText[0];
        _bgmSoundVolumeText = volumeText[1];
        _sfSoundVolumeText = volumeText[2];
        
        _msSoundVolumeText.text = $"{MSSoundVolume.ToString()}";
        _bgmSoundVolumeText.text = $"{BGMSoundVolume.ToString()}";
        _sfSoundVolumeText.text = $"{SFSoundVolume.ToString()}";
    }

    //0~10
    public int MSSoundVolume
    {
        get => _msSoundVolume;
        set
        {
            _msSoundVolume = value;
            _msSoundVolume = Mathf.Clamp(_msSoundVolume, 0, 10);     
            _msSoundVolumeText.text = $"{_msSoundVolume}";
        }
    }
    
    //0~10
    public int SFSoundVolume
    {
        get => _sfSoundVolume;
        set
        {
            _sfSoundVolume = value;
            _sfSoundVolume = Mathf.Clamp(_sfSoundVolume, 0, 10);     
            _sfSoundVolumeText.text = $"{_sfSoundVolume}";
        }
    }

    //0~10
    public int BGMSoundVolume
    {
        get => _bgmSoundVolume;
        set
        {
            _bgmSoundVolume = value;
            _bgmSoundVolume = Mathf.Clamp(_bgmSoundVolume, 0, 10);     
            _bgmSoundVolumeText.text = $"{_bgmSoundVolume}";
        }
    }
    
    
}