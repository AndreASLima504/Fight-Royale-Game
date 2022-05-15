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
        SceneManager.LoadScene(0);
    }

    //public void carregarFase()
    //{
    //    SceneManager.LoadScene()
    //}
}
