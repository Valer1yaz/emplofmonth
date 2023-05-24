using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour
{
    public TextMeshProUGUI KillsText;
    public TextMeshProUGUI ObjectsText;

    public int _enemyKills = 0;
    public int _objects = 0;

    void Update() 
    {
        KillsText.text = Convert.ToString(_enemyKills);
        ObjectsText.text = Convert.ToString(_objects);
    }
}
