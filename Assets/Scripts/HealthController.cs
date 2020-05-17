using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{

    //publics
    public GameObject player;
    public Image[] hearths;
    public Sprite filledHearth;
    public Sprite emptyHearth;

    //privates
    private int indexCounter;
    private int maxHealth;
    private readonly int minHealth = 0;

    public void Start() {
        indexCounter = 0;
        maxHealth = 3;
    }

    public void Update() {
        if (maxHealth == minHealth) {
            //TODO: make an explosion or something to indicate.
            player.gameObject.SetActive(false);
        }
    }

    public void DeductHealth() {
        maxHealth--;
        hearths[indexCounter].sprite = emptyHearth;
        indexCounter++;
    }

}
