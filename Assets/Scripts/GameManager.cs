using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Gun[] guns;

    public void quit()
    {
        Application.Quit();
    }

    public void restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
