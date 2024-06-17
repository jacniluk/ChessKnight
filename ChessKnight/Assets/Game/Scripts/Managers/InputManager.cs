using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        UpdateInput();
    }

    private void UpdateInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.Exit();
        }
    }
}
