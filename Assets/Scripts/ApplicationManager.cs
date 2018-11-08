using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ApplicationManager : MonoBehaviour {

    public static string playerName;

	public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}

    public void newGame() {
        print("New game");
        SceneManager.LoadScene("Layout Groups");
    }

    public void continueGame() {
        SceneManager.LoadScene("level_01");
    }
}
