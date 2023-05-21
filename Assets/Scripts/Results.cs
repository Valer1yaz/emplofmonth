using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour
{
    public Text KillsText;
    public Text ObjectsText;

    int Kills = 0;
    int Object = 0;

    void Update() {
        KillsText.text = Kills.ToString();
        ObjectsText.text = Object.ToString();
    }
}
