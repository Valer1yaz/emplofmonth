using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SliderDifficulty : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _sliderText;
    public static int _difficultyLevel;

    void Start()
    {
        _slider.onValueChanged.AddListener((v) =>
        {
            _sliderText.text = v.ToString("0");
        });
    }
    private void Update()
    {
        _difficultyLevel = Convert.ToInt32(_slider.value);
    }

}
