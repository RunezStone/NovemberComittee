using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Win and Lose Conditions")]
    public Canvas winUI;
    public Canvas loseUI;

    [Header("Scripts")]
    [SerializeField] MatchSystem matchSystem;

    private void Start()
    {
        winUI.gameObject.SetActive(false);
        loseUI.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        matchSystem.matchOut += GameOver;


    }

    private void OnDisable()
    {
        matchSystem.matchOut -= GameOver;


    }

    void GameOver()
    {
        Time.timeScale  = 0;
        loseUI.gameObject.SetActive(true);
    }

    void GameWin()
    {

    }

}
