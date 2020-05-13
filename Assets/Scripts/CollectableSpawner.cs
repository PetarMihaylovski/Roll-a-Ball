using System;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    //publics
    public Vector3 size;
    public GameObject collectable;
    public GameObject enemyCollectable;
    public float repeatRate;
    public int percentageThreshold;

    //privates
    private int collectableCounter;
  
    //monos
    void Start() {
        //playerScore = GameObject.Find
        InvokeRepeating("CreateCollectable", 0.5f, repeatRate);
    }

    //privates
    private void CreateCollectable() {
        //caluclate the new position
        Vector3 position = new Vector3(0,0,0) + new Vector3(UnityEngine.Random.Range(-size.x / 2, size.x / 2), 0.25f, UnityEngine.Random.Range(-size.z / 2, size.z / 2));
        
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

        collectableCounter++;

        //stop the spawning of new collectables
        if (collectableCounter == 15) {
            CancelInvoke();
        }
    }

    private bool ShouldSpawnEnemyCollectable() {
        int percentage = UnityEngine.Random.Range(0, 100);
        Debug.Log("Percentage is: " + percentage.ToString());
        if (percentage <= percentageThreshold) {
            return true;
        }
        return false;
    }
}
