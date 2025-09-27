using UnityEngine;
using TMPro;

public class BottleScript : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 startPosition;
    private Quaternion startRotation;

    public TextMeshProUGUI scoreText;
    private static int scoreCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            scoreCount += 10;

            if (scoreText != null)
            {
                scoreText.text = "Score: " + scoreCount;
            }
        }
    }

    /*// Optional: Reset bottle position
    public void ResetBottle()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = startPosition;
        transform.rotation = startRotation;
    }*/
}
