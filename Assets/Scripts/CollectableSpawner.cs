using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    //publics
    public Vector3 size;
    public GameObject collectable;
    public float repeatRate;

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
        Vector3 position = new Vector3(0,0,0) + new Vector3(Random.Range(-size.x / 2, size.x / 2), 0.5f, Random.Range(-size.z / 2, size.z / 2));
        GameObject newCollectable = Instantiate(collectable, position, Quaternion.identity);
        //set the rotation of the new collectable
       
        Quaternion quaternion = new Quaternion();
        quaternion.Set(15, 30, 45, 1);
        newCollectable.transform.rotation = quaternion;

        collectableCounter++;

        //stop the spawning of new collectables
        if (collectableCounter == 15) {
            CancelInvoke();
        }
    }
}
