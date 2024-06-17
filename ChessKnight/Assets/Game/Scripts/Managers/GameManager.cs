using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	private void Awake()
	{
		Instance = this;

		Application.targetFrameRate = 60;
	}
}
