using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ChangeMaterial : MonoBehaviour
{
    string chemin, jsonString;

    public Material materialRed;
    public Material materialBlue;
    public Material materialYellow;
    public Material materialGreen;
    public GameObject player;

    void Awake() {
        chemin = Application.streamingAssetsPath + "/color.json";
        jsonString = File.ReadAllText(chemin);
        Couleur color = JsonUtility.FromJson<Couleur>(jsonString);
        if(color.color == "red") {
            player.GetComponent<SkinnedMeshRenderer>().material = materialRed;
        } else if(color.color == "blue") {
            player.GetComponent<SkinnedMeshRenderer>().material = materialBlue;
        } else if(color.color == "yellow") {
            player.GetComponent<SkinnedMeshRenderer>().material = materialYellow;
        } else if(color.color == "green") {
            player.GetComponent<SkinnedMeshRenderer>().material = materialGreen;
        }
    }
}
