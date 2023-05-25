using UnityEngine;
using TMPro;

public class Results : MonoBehaviour
{
    public TextMeshProUGUI KillsText;
    public TextMeshProUGUI ObjectsText;

    int Kills = 0;
    int Objects = 0;

    void Update()
    {
        KillsText.text = Kills.ToString();
        ObjectsText.text = Objects.ToString();
    }
    public void AddKill()
    {
        Kills++;
    }
    public void AddObject()
    {
        Objects++;
    }
}
