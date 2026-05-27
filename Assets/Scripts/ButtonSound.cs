using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSound : MonoBehaviour
{
    [SerializeField] private AudioSource _source;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Play);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Play);
    }

    private void Play()
    {
        _source.Play();
    } 
}
