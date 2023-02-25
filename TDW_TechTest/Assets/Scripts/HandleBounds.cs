using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleBounds : MonoBehaviour
{
    public Collider playArea;
    public GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        gameController.RemoveObject(other.gameObject.GetComponent<ObjectController>());
    }
}
