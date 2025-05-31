using UnityEngine;

public class SC_MainMenu : MonoBehaviour
{
    // Referencia al panel del menú principal
    public GameObject MainMenu;

    void Start()
    {
        MainMenuButton();
    }

    public void PlayNowButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MaratonMadnes");
    }

    public void MainMenuButton()
    {
        if (MainMenu != null)
        {
            MainMenu.SetActive(true);
        }
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Saliendo del juego..."); // Para probar en el editor
    }
}
