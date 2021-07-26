using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Buttons : MonoBehaviour
{
    string chemin, jsonString;

    public void PlayGame() {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void ChangeColor(string couleur) {
        chemin = Application.streamingAssetsPath + "/color.json";
        jsonString = File.ReadAllText(chemin);
        Couleur color = JsonUtility.FromJson<Couleur>(jsonString);

        color.color = couleur;
        jsonString = JsonUtility.ToJson(color);
        File.WriteAllText(chemin, jsonString);
    }
}

public class Couleur {
    public string color;
}
