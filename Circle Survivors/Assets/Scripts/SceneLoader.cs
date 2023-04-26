using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void mainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void game()
	{
		SceneManager.LoadScene("GameplayScene");
	}

	public void quit()
	{
		Application.Quit();
	}
}
