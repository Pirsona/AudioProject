using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioMixer _masterMixer;
    [SerializeField] private UnityEngine.UI.Image _muteButtonImage;
    [SerializeField] private Sprite _soundOnSprite;
    [SerializeField] private Sprite _soundOffSprite;

    private float _masterLvl = 1;
    private float _musicLvl;
    private float _audioLvl;
    private bool _isMute = false;


    public void SetMasterVolume(float volume)
    {
        _masterLvl = volume;

        if (!_isMute)
        {
            _masterMixer.SetFloat("MasterVolume", Mathf.Log10(_masterLvl) * 20);
        }
    }
    public void SetMusicVolume(float volume)
    {
        _musicLvl = volume;
        _masterMixer.SetFloat("BackgroundVolume", Mathf.Log10(_musicLvl) * 20);
    }

    public void SetAudioVolume(float volume)
    {
        _audioLvl = volume;
        _masterMixer.SetFloat("AudioVolume", Mathf.Log10(_audioLvl) * 20);
    }

    public void ToggleMute()
    {
        _isMute = !_isMute;

        if (_isMute)
        {
            _muteButtonImage.sprite = _soundOffSprite;
            _masterMixer.SetFloat("MasterVolume", -80);
        }
        else
        {
            _muteButtonImage.sprite = _soundOnSprite;
            _masterMixer.SetFloat("MasterVolume", Mathf.Log10(_masterLvl) * 20);
        }
    }

}
