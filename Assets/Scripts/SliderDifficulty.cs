using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderDifficulty : MonoBehaviour
{
    [SerializeField] private Slider _sliderDif;
    [SerializeField] private Slider _sliderVol;
    [SerializeField] private TextMeshProUGUI _sliderDifText;
    public static int _difficultyLevel;
    public static int _volume;

    void Start()
    {
        _sliderDif.onValueChanged.AddListener((v) =>
        {
            _sliderDifText.text = v.ToString("0");
        });

        _sliderVol.value = 0.5f;

    }
    private void Update()
    {
        _difficultyLevel = Convert.ToInt32(_sliderDif.value);

        ChangeVol();
        
    }

    public void ChangeVol()
    {
        AudioListener.volume = _sliderVol.value;
    }



}
