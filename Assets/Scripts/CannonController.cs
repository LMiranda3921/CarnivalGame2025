using TMPro;  // Needed for UI text
using UnityEngine;
using UnityEngine.SceneManagement;

public class CannonController : MonoBehaviour
{
    [Header("Cannon Settings")]
    public Transform cannon;           // Reference to cannon GameObject
    public Transform firePoint;        // Where the ball spawns
    public GameObject ballPrefab;      // Prefab of the ball
    public float launchForce = 15f;    // Force applied to the ball

    [Header("Rotation Settings")]
    public float rotationSpeed = 50f;  // Speed of rotation

    [Header("Ammo Settings")]
    public int maxBalls = 3;           // Max balls available
    private int ballsLeft;

    [Header("UI")]
    public TextMeshProUGUI ballsLeftText; // Reference to UI text

    void Start()
    {
        ballsLeft = maxBalls;
        UpdateUI();
    }

    void Update()
    {
        HandleRotation();
        HandleFire();

        if (Input.GetKeyDown(KeyCode.R)) // use GetKeyDown so it only triggers once
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void HandleRotation()
    {
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.A)) horizontal = -1f;
        if (Input.GetKey(KeyCode.D)) horizontal = 1f;
        if (Input.GetKey(KeyCode.S)) vertical = 1f;
        if (Input.GetKey(KeyCode.W)) vertical = -1f;
        

        // Rotate cannon around Y-axis (left/right)
        cannon.Rotate(Vector3.up, horizontal * rotationSpeed * Time.deltaTime, Space.World);

        // Rotate cannon around X-axis (up/down)
        cannon.Rotate(Vector3.right, vertical * rotationSpeed * Time.deltaTime, Space.Self);
    }

    void HandleFire()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ballsLeft > 0)
        {
            ShootBall();
        }
    }

    void ShootBall()
    {
        if (ballPrefab != null && firePoint != null)
        {
            GameObject ball = Instantiate(ballPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = ball.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddForce(firePoint.forward * launchForce, ForceMode.Impulse);
            }

            ballsLeft--;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        if (ballsLeftText != null)
        {
            ballsLeftText.text = "Balls Left: " + ballsLeft;
        }
    }
}
 