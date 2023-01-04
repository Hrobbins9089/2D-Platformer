using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public void LvL1()
    {
        SceneManager.LoadScene("lvl_1");
    }

    public void Lvl2()
    {
        SceneManager.LoadScene("lvl_2");
    }

    public void Congrats()
    {
        SceneManager.LoadScene("Congrats");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tututorial");
    }
}
