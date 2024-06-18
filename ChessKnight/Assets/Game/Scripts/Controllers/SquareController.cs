using UnityEngine;

public class SquareController : MonoBehaviour
{
    private Vector2Int square;
    
    public Vector2Int Square { get => square; }

    public void SetSquare(Vector2Int _square, Vector3 squarePosition)
    {
        square = _square;
        transform.position = squarePosition;

        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public bool IsHidden()
    {
        return gameObject.activeSelf == false;
    }
}
