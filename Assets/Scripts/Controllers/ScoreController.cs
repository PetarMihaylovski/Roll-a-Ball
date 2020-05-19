using UnityEngine;
using UnityEngine.UI;
public class ScoreController : MonoBehaviour
{
    //publics
    public int score;
    public int allyCollectableValue;
    public int enemyCollectableValue;
    public Text scoreDisplayText;

    public void IncreaseScore() {
        score += allyCollectableValue;
    }

    public void DecreaseScore() {
        score += enemyCollectableValue;
    }

    public void UpdateScoreDisplay() {
        scoreDisplayText.text = "Score: " + score.ToString();
    }
}
