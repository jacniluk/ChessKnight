using UnityEngine;

public class KnightController : MonoBehaviour
{
    private Vector2Int chessboardSquare; // e.g. A8 = (1, 8)

    private void Awake()
    {
        chessboardSquare = new Vector2Int(7, 1); // G1
    }

    private void Start()
    {
        transform.position = ChessboardManager.Instance.GetPositionBySquare(chessboardSquare);

        ChessboardManager.Instance.UpdateChessboard(chessboardSquare);
    }
}
