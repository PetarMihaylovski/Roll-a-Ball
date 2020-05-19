using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableSpawner : MonoBehaviour {
    //publics
    public Vector3 size;
    public GameObject collectable;
    public GameObject enemyCollectable;
    public float delay;
    public float repeatRate;
    public int percentageThreshold;
    public Text winnerText;

    //privates
    private ScoreController scoreController;

    //monos
    void Start() {
        InvokeRepeating("CreateCollectable", delay, repeatRate);
    }

    private void Update() {
        //could not think of an other way to get the player. i know it is slow..
        if (GameObject.Find("Player") != null) {
            scoreController = GameObject.Find("Player").GetComponent<ScoreController>();
        }
    }

    //privates
    private void CreateCollectable() {
        //caluclate the new position
        Vector3 position = new Vector3(0, 0, 0) + new Vector3(UnityEngine.Random.Range(-size.x / 2, size.x / 2), 0.25f,
            UnityEngine.Random.Range(-size.z / 2, size.z / 2));

        //set the rotation of the new object
        Quaternion quaternion = new Quaternion();
        quaternion.Set(15, 30, 45, 1);

        GameObject newCollectable = null;
        if (ShouldSpawnEnemyCollectable()) {
            //enemy
            newCollectable = Instantiate(enemyCollectable, position, Quaternion.identity);
        }
        else {
            //good
            newCollectable = Instantiate(collectable, position, Quaternion.identity);
        }

        newCollectable.transform.rotation = quaternion;

        //stop the spawning of new collectables and remove all the existing, game is won!
        if (scoreController.score == 15) {
            CancelInvoke();
            DestroyAllCollectables();
            winnerText.text = "Congratulations, you have won the game!";
        }
    }

    private bool ShouldSpawnEnemyCollectable() {
        int percentage = UnityEngine.Random.Range(0, 100);
        return percentage <= percentageThreshold;
    }

    private void DestroyAllCollectables() {
        GameObject[] allyCollectables = GameObject.FindGameObjectsWithTag("Ally");
        GameObject[] enemyCollectibles = GameObject.FindGameObjectsWithTag("Enemy");
        List<GameObject> collectables = new List<GameObject>();
        collectables.AddRange(allyCollectables);
        collectables.AddRange(enemyCollectibles);

        foreach (GameObject go in collectables) {
            Destroy(go);
        }
    }
}