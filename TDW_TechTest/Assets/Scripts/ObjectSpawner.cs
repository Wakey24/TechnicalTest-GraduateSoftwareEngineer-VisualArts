using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject targetObject;
    public GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameController.FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnNewTargetObject ()
    {
        if (!gameController.objectIsActive && !gameController.gameIsPaused)
        {
            GameObject newObject = Instantiate(targetObject, new Vector3(0.0f, 10.0f, 0.0f), targetObject.transform.rotation);
            newObject.GetComponent<ObjectController>().setObjectState(true);
        }
    }
    
}
