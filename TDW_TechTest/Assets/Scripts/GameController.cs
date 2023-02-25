using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : MonoBehaviour
{
    public GameObject editPanel;
    public GameObject pausePanel;

    public bool objectIsActive = false;
    public bool gameIsPaused = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UpdatePauseState(!gameIsPaused);
        }
    }
    public void UpdatePauseState(bool state)
    {
        gameIsPaused = state;
        pausePanel.SetActive(state);
    }
    public void RemoveObject(ObjectController target)
    {
        UpdateActiveState(false, target);
        Destroy(target.gameObject);
    }
    public void UpdateActiveState(bool isActive, ObjectController objectController)
    {
        objectIsActive = isActive;
       editPanel.SetActive(isActive);

        if (isActive)
            editPanel.GetComponent<EditController>().targetObject = objectController;
        else
            editPanel.GetComponent<EditController>().targetObject = null;
    }
  
}
