using UnityEngine;
using UnityEngine.UI;

namespace Controllers {
    public class PlayerController : MonoBehaviour {
        //publics
        public float speed;
        public Text scoreDisplayText;

        //privates
        private Rigidbody rb;
        private AudioManager audioManager;
        private HealthController healthController;
        private ScoreController scoreController;

        // Start is called before the first frame update
        void Start() {
            rb = GetComponent<Rigidbody>();
            scoreController = GetComponent<ScoreController>();
            audioManager = FindObjectOfType<AudioManager>();
            healthController = FindObjectOfType<HealthController>();
            scoreController.UpdateScoreDisplay();
        }

        // FixedUpdate is called once per frame before physics is applied.
        void FixedUpdate() {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            rb.AddForce(new Vector3(moveHorizontal, 0, moveVertical) * speed);
        }

        private void OnTriggerEnter(Collider other) {
            if (other.gameObject.CompareTag("Ally")) {
                //destroy the object we collected
                Destroy(other.gameObject);
                //play pop sound
                audioManager.Play("PlusOne");
                //increase the score
                scoreController.IncreaseScore();
                //update UI
                scoreController.UpdateScoreDisplay();
            }
            else if (other.gameObject.CompareTag("Enemy")) {
                Destroy(other.gameObject);
                audioManager.Play("MinusTen");
                healthController.DeductHealth();
                scoreController.DecreaseScore();
                scoreController.UpdateScoreDisplay();
            }
        }
    }
}