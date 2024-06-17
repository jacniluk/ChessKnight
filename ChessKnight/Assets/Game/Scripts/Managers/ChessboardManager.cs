using System.Collections.Generic;
using UnityEngine;

public class ChessboardManager : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private Vector2Int a1SquarePosition;
    [SerializeField] private float squareSize;

    [Header("References")]
    [SerializeField] private List<SquareController> possibleSquares;
    [SerializeField] private GameObject squareHighlight;

    public static ChessboardManager Instance;

    private List<Vector2Int> knightMoveOffsets;
    private Vector2Int knightSquare;

    private void Awake()
    {
        Instance = this;

        knightMoveOffsets = new List<Vector2Int>
        {
            new Vector2Int(-1, 2),
            new Vector2Int(1, 2),
            new Vector2Int(-2, 1),
            new Vector2Int(2, 1),
            new Vector2Int(-2, -1),
            new Vector2Int(2, -1),
            new Vector2Int(-1, -2),
            new Vector2Int(1, -2)
        };
    }

    public void UpdateChessboard(Vector2Int _knightSquare)
    {
        knightSquare = _knightSquare;

        for (int i = 0; i < possibleSquares.Count; i++)
        {
            possibleSquares[i].Hide();
        }

        Vector2Int square;
        for (int i = 0; i < knightMoveOffsets.Count; i++)
        {
            square = knightSquare + knightMoveOffsets[i];
            if (ValidateSquare(square))
            {
                SetPossibleSquare(square);
            }
        }
    }

    private bool ValidateSquare(Vector2Int square)
    {
        return square.x >= 1 && square.x <= 8 && square.y >= 1 && square.y <= 8;
    }

    private void SetPossibleSquare(Vector2Int square)
    {
        for (int i = 0; i < possibleSquares.Count; i++)
        {
            if (possibleSquares[i].IsHidden())
            {
                possibleSquares[i].SetSquare(square, GetPositionBySquare(square));

                return;
            }
        }
    }

    public Vector3 GetPositionBySquare(Vector2Int square)
    {
        float x = a1SquarePosition.x + square.x - 1;
        float z = a1SquarePosition.y + square.y - 1;

        return new Vector3(x, 0.0f, z);
    }

    public void HighlightSquare(SquareController squareController)
    {
        if (squareController == null)
        {
            squareHighlight.SetActive(false);
        }
        else
        {
            squareHighlight.SetActive(true);
            squareHighlight.transform.position = squareController.transform.position;
        }
    }
}
