using UnityEngine.SceneManagement;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public void Reload()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
