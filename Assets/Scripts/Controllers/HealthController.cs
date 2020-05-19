using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour {
    //publics
    public GameObject player;
    public Image[] hearths;
    public Sprite filledHearth;
    public Sprite emptyHearth;
    

    //privates
    private int indexCounter;
    private int currentHealth;
    private const int minHealth = 0;
    private AudioManager audioManager;
    
    public void Start() {
        indexCounter = 0;
        currentHealth = 3;
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void Update() {
        if (currentHealth == minHealth) {
            //TODO: make an explosion or something to indicate.
            player.gameObject.SetActive(false);
            audioManager.Play("Death");
            currentHealth = -1;
        }
    }

    public void DeductHealth() {
        currentHealth--;
        hearths[indexCounter].sprite = emptyHearth;
        indexCounter++;
    }
}