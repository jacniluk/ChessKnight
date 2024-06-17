using UnityEngine;

public class KnightController : MonoBehaviour
{
    public static KnightController Instance;

    private Vector2Int square; // e.g. A8 = (1, 8)

    private void Awake()
    {
        Instance = this;

        square = new Vector2Int(7, 1); // G1
    }

    private void Start()
    {
        transform.position = ChessboardManager.Instance.GetPositionBySquare(square);

        ChessboardManager.Instance.UpdateChessboard(square);
    }

    public void MoveToSquare(SquareController squareController)
    {
        square = squareController.Square;
        transform.position = squareController.transform.position;

        ChessboardManager.Instance.UpdateChessboard(square);
    }
}
