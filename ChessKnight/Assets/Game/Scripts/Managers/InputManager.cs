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
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity, squareLayerMask))
            {
                KnightController.Instance.MoveToSquare(raycastHit.transform.GetComponent<SquareController>());
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.Instance.Exit();
        }
    }
}
