using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _parameterName;

    private const float DECIBEL_MULTIPLIER = 25f;

    private Slider _slider;
    private float _masterLvl = 1;
    private bool _isMuted = false;

    public string ParameterName => _parameterName;
    public float CurrentLvlAudio =>  _masterLvl;
    public AudioMixer AudioMixer => _audioMixer;


    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(SetVolume);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(SetVolume);
    }

    private void SetVolume(float value)
    {
        _masterLvl = value;

        if (!_isMuted)
        {
            _audioMixer.SetFloat(_parameterName, Mathf.Log10(value) * DECIBEL_MULTIPLIER);
        }
    }

    public void SetMuteState(bool isMuted)
    {
        _isMuted = isMuted;
    }
}
