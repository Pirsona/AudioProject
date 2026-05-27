using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ToggleSound : MonoBehaviour
{
    [SerializeField] private VolumeSlider _mainSlider;
    [SerializeField] private UnityEngine.UI.Image _muteButtonImage;
    [SerializeField] private Sprite _soundOnSprite;
    [SerializeField] private Sprite _soundOffSprite;

    private const float DECIBEL_OFF = -80;
    private const float DECIBEL_MULTIPLIER = 25f;

    private bool _isMute = false;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ToggleMute);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ToggleMute);
    }

    public void ToggleMute()
    {
        _isMute = !_isMute;

        _mainSlider.SetMuteState(_isMute);

        if (_isMute)
        {
            _muteButtonImage.sprite = _soundOffSprite;
            _mainSlider.AudioMixer.SetFloat(_mainSlider.ParameterName, DECIBEL_OFF);
        }
        else
        {
            _muteButtonImage.sprite = _soundOnSprite;
            _mainSlider.AudioMixer.SetFloat(_mainSlider.ParameterName, Mathf.Log10(_mainSlider.CurrentLvlAudio) * DECIBEL_MULTIPLIER);
        }
    }
}