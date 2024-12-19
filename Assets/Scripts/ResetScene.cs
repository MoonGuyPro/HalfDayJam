using UnityEngine;
using UnityEngine.SceneManagement;
public class ResetScene : MonoBehaviour
{
    public void ResetGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
