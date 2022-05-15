using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalEventos : MonoBehaviour
{
    // Start is called before the first frame update
    public void fecharJogo()
    {
        Application.Quit();
    }

    public void carregarFase(int indiceFase)
    {
        SceneManager.LoadScene(indiceFase);

    }
}
