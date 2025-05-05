using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void OnRestartClicked()
    {
        SceneManager.LoadScene("Game");
    }
    public void OnBackClicked()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnCreditClicked()
    {
        SceneManager.LoadScene("Credit");
    }
}
