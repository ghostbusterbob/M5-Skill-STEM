using UnityEngine;

public class JumpController : MonoBehaviour
{
    [Header("Jump parameters")]
    public float g = -10f;   // zwaartekracht
    public float v0 = 9f;    // beginsnelheid
    public float h0 = -3f;   // beginhoogte

    private QuadraticFunction jumpFunction;
    private float jumpTime;
    private float currentTime;
    private bool isJumping;

    private Vector3 startPosition;

    void Start()
    {
        // f(t) = -1/2 g t² + v0 t + h0
        float a = -0.5f * g;
        float b = v0;
        float c = h0;

        jumpFunction = new QuadraticFunction(a, b, c);

        // nulpunten berekenen
        Vector2 zeros = jumpFunction.FindZero();

        // hoogste t is einde van sprong
        jumpTime = Mathf.Max(zeros.x, zeros.y);

        startPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            StartJump();
        }

        if (isJumping)
        {
            currentTime += Time.deltaTime;

            float y = jumpFunction.EvaluateValue(currentTime);
            transform.position = new Vector3(
                startPosition.x,
                startPosition.y + y,
                startPosition.z
            );

            if (currentTime >= jumpTime)
            {
                EndJump();
            }
        }
    }

    void StartJump()
    {
        isJumping = true;
        currentTime = 0f;
    }

    void EndJump()
    {
        isJumping = false;
        transform.position = startPosition;
    }
}