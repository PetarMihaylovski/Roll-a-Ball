using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //publics
    public float speed;
    public Text scoreDisplayText;

    //privates
    private Rigidbody rb;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        rb = GetComponent<Rigidbody>();
        UpdateScoreDisplay();
    }

    // FixedUpdate is called once per frame before physics is applied.
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(moveHorizontal, 0, moveVertical)*speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            score++;
            UpdateScoreDisplay();
        }
        else if(other.gameObject.CompareTag("Enemy")){
            Destroy(other.gameObject);
            score -= 10;
            UpdateScoreDisplay();
        }
    }

    private void UpdateScoreDisplay() {
        scoreDisplayText.text = "Score: " + score.ToString();
    }

}
