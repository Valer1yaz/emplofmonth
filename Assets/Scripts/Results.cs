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

    public static Int32 _enemyKills = 0;

    int Object = 0;

    void Update() {
        KillsText.text = " " + _enemyKills;
        ObjectsText.text = Convert.ToString(Object);
    }
}
