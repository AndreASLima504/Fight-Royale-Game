using UnityEngine.SceneManagement;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public void ReiniciarFase()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void FecharJogo()
    {
        Application.Quit();
    }
}
