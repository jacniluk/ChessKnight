using UnityEngine;

public class InputManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private LayerMask squareLayerMask;

    private void Update()
    {
        UpdateInput();
    }

    private void UpdateInput()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity, squareLayerMask))
        {
            SquareController squareController = raycastHit.transform.GetComponent<SquareController>();
            if (Input.GetMouseButtonDown(0))
            {
                KnightController.Instance.MoveToSquare(squareController);
            }
            else
            {
                ChessboardManager.Instance.HighlightSquare(squareController);
            }
        }
        else
        {
            ChessboardManager.Instance.HighlightSquare(null);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.Exit();
        }
    }
}
