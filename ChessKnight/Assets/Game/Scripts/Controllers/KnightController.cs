using System.Collections;
using UnityEngine;

public class KnightController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float moveSpeed;

    public static KnightController Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Vector2Int square = new Vector2Int(7, 1); // G1

        transform.position = ChessboardManager.Instance.GetSquarePosition(square);

        ChessboardManager.Instance.UpdatePossibleSquares(square);
    }

    public void MoveToSquare(SquareController squareController)
    {
        ChessboardManager.Instance.HidePossibleSquares();

        StartCoroutine(MoveCoroutine(squareController));
    }

    private IEnumerator MoveCoroutine(SquareController squareController)
    {
        Vector3 offset;
        Vector3 distanceToTarget;

        Vector3 twoSquaresOffset;
        Vector3 oneSquareOffset;
        if (Mathf.Abs(squareController.transform.position.x - transform.position.x) > Mathf.Abs(squareController.transform.position.z - transform.position.z))
        {
            twoSquaresOffset = new Vector3(squareController.transform.position.x - transform.position.x, 0.0f, 0.0f);
            oneSquareOffset = new Vector3(0.0f, 0.0f, squareController.transform.position.z - transform.position.z);
        }
        else
        {
            twoSquaresOffset = new Vector3(0.0f, 0.0f, squareController.transform.position.z - transform.position.z);
            oneSquareOffset = new Vector3(squareController.transform.position.x - transform.position.x, 0.0f, 0.0f);
        }

        Vector3 target1 = transform.position + twoSquaresOffset;
        while (transform.position != target1)
        {
            offset = moveSpeed * Time.deltaTime * twoSquaresOffset.normalized;
            distanceToTarget = target1 - transform.position;
            if (offset.magnitude > distanceToTarget.magnitude)
            {
                offset = distanceToTarget;
            }

            transform.position += offset;

            yield return null;
        }

        Vector3 target2 = transform.position + oneSquareOffset;
        while (transform.position != target2)
        {
            offset = moveSpeed * Time.deltaTime * oneSquareOffset.normalized;
            distanceToTarget = target2 - transform.position;
            if (offset.magnitude > distanceToTarget.magnitude)
            {
                offset = distanceToTarget;
            }

            transform.position += offset;

            yield return null;
        }

        ChessboardManager.Instance.UpdatePossibleSquares(squareController.Square);
    }
}
