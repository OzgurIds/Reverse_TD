using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public void LoadMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadSettingsScene()
    {
        SceneManager.LoadScene("Settings");
    }
    public void LoadShopScene()
    {
        SceneManager.LoadScene("Shop");
    }
    public void LoadMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void LoadCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }
    public void LoadHowToPlayScene()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void LoadUpgradesScene()
    {
        SceneManager.LoadScene("Upgrades");
    }
    public void ExitGame()
    {
        const string path = @"D:\Unity_Projects\Reverse_TD\Assets\Scripts\SaveFile.ncr";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        Application.Quit();
    }
}
