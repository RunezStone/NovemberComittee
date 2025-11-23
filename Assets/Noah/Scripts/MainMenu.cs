using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Button1Press()
    {
        SceneManager.LoadScene("RopeTest", LoadSceneMode.Single);
    }
}
