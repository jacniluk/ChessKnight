using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	private void Awake()
	{
		Instance = this;

		Application.targetFrameRate = 60;
	}

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
