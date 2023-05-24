using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Results : MonoBehaviour
{
    public Text KillsText;
    public Text ObjectsText;

    int Kills = 0;
    int Objects = 0;

    void Update() {
        KillsText.text = Kills.ToString();
        ObjectsText.text = Objects.ToString();
    }

    public void AddKill(){
        Kills += 1;
    }

    public void AddObject(){
        Objects += 1;
    }
}
