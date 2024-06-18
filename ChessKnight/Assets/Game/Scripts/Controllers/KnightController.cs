using System.Collections;
using UnityEngine;

public class KnightController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float rotateTime;
    [SerializeField] private float moveTime;
    [SerializeField] private AnimationCurve jumpCurve;

    public static KnightController Instance;

    private Vector3 newPosition;

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

        StartCoroutine(MoveToSquareCoroutine(squareController));
    }

    private IEnumerator MoveToSquareCoroutine(SquareController squareController)
    {
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

        yield return StartCoroutine(JumpCoroutine(squareController, twoSquaresOffset));
        yield return StartCoroutine(JumpCoroutine(squareController, oneSquareOffset));

        ChessboardManager.Instance.UpdatePossibleSquares(squareController.Square);
    }

    private IEnumerator JumpCoroutine(SquareController squareController, Vector3 offset)
    {
        Vector3 startPosition = transform.position;
        Vector3 targetPosition = transform.position + offset;
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, Mathf.Atan2(offset.x, offset.z) * Mathf.Rad2Deg, 0);
        float startTime = Time.realtimeSinceStartup;
        float endTime = startTime + rotateTime;
        while (Time.realtimeSinceStartup <= endTime)
        {
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, Utilities.CalculateProgress01(Time.realtimeSinceStartup, startTime, endTime));

            yield return null;
        }
        transform.rotation = targetRotation;
        startTime = Time.realtimeSinceStartup;
        endTime = startTime + moveTime;
        while (Time.realtimeSinceStartup <= endTime)
        {
            float timeProgress = Utilities.CalculateProgress01(Time.realtimeSinceStartup, startTime, endTime);
            newPosition = startPosition + offset * timeProgress;
            newPosition = new Vector3(newPosition.x, jumpCurve.Evaluate(timeProgress), newPosition.z);
            transform.position = newPosition;

            yield return null;
        }
        transform.position = targetPosition;
    }
}
