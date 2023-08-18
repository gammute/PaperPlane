using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void SceneChanger(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1;
    }
}