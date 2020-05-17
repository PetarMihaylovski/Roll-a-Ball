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
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        rb = GetComponent<Rigidbody>();
        audioManager = FindObjectOfType<AudioManager>();
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
        if (other.gameObject.CompareTag("Ally"))
        {
            //destroy the object we collected
            Destroy(other.gameObject);
            //play pop sound
            audioManager.Play("PlusOne");
            //increase the score
            score++;
            //update UI
            UpdateScoreDisplay();
        }
        else if(other.gameObject.CompareTag("Enemy")){
            Destroy(other.gameObject);
            audioManager.Play("MinusTen");
            score -= 10;
            UpdateScoreDisplay();
        }
    }

    private void UpdateScoreDisplay() {
        scoreDisplayText.text = "Score: " + score.ToString();
    }

    public int GetScore() {
        return score;
    }
}
