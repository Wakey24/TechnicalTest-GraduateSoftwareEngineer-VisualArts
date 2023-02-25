using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public Rigidbody objectBody;
    public MeshRenderer objectRenderer;
    public Collider objectCollider;
    public int colourValue = 3;
    private Color markerColour = new Color(0.0f, 0.8f, 0.0f, 0.5f);
    private bool stateCheck = false;
    public GameController gameController;
    public AudioSource audioSource;
    public int scaleValue = 1;


    // Start is called before the first frame update
    void Start()
    {
        gameController = GameController.FindObjectOfType<GameController>();
        gameController.UpdateActiveState(stateCheck, this);
        SetColour(3);
        objectRenderer.material.DisableKeyword("_EMISSION");
    }

    // Update is called once per frame
    void Update()
    {
        if (stateCheck && !gameController.gameIsPaused)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                setObjectState(false);
            }
            if (Input.GetKey(KeyCode.UpArrow))
                gameObject.transform.position += new Vector3(0.0f, 0.0f, 0.1f);
            if (Input.GetKey(KeyCode.DownArrow)) 
                gameObject.transform.position += new Vector3(0.0f, 0.0f, -0.1f);
            if (Input.GetKey(KeyCode.RightArrow))
                gameObject.transform.position += new Vector3(0.1f, 0.0f, 0.0f);
            if (Input.GetKey(KeyCode.LeftArrow))
                gameObject.transform.position += new Vector3 (-0.1f, 0.0f, 0.0f);

            if (Input.GetKey(KeyCode.I))
                gameObject.transform.Rotate(0.5f, 0.0f, 0.0f);
            if (Input.GetKey(KeyCode.K))
                gameObject.transform.Rotate(-0.5f, 0.0f, 0.0f);
            if (Input.GetKey(KeyCode.L))
                gameObject.transform.Rotate(0.0f, 0.5f, 0.0f);
            if (Input.GetKey(KeyCode.J))
                gameObject.transform.Rotate(0.0f, -0.5f, 0.0f);

        }
    }

    private void OnMouseEnter()
    {
        objectRenderer.material.EnableKeyword("_EMISSION");
        objectRenderer.material.SetColor("_EmissionColor", markerColour);
    }
    private void OnMouseExit()
    {
        objectRenderer.material.DisableKeyword("_EMISSION");
    }
    private void OnMouseDown()
    {
        if (!stateCheck && !gameController.objectIsActive && !gameController.gameIsPaused)
            setObjectState(true);
    }
    private void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
    }

    public void setObjectState(bool newState)
    {
        objectBody.velocity = new Vector3(0.0f, 0.0f, 0.0f);

        objectBody.useGravity = !newState;
        objectCollider.enabled = !newState;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, 5.0f, gameObject.transform.position.z);
        if (!newState)
            objectRenderer.material.color = new Color(markerColour.r, markerColour.g, markerColour.b);
        else
            objectRenderer.material.color = markerColour;
        stateCheck = newState;
        if (gameController != null)
            gameController.UpdateActiveState(stateCheck, this);
    }

    public void SetColour(int value)
    {
        switch (value)
        {
            case 0:
                markerColour = new Color(0.8f, 0.0f, 0.0f, 0.5f);
                break;
            case 1:
                markerColour = new Color(0.8f, 0.4f, 0.0f, 0.5f);
                break;
            case 2:
                markerColour = new Color(0.4f, 0.8f, 0.0f, 0.5f);
                break;
            case 3:
                markerColour = new Color(0.0f, 0.8f, 0.0f, 0.5f);
                break;
            case 4:
                markerColour = new Color(0.0f, 0.8f, 0.4f, 0.5f);
                break;
            case 5:
                markerColour = new Color(0.0f, 0.4f, 0.8f, 0.5f);
                break;
            case 6:
                markerColour = new Color(0.0f, 0.0f, 0.8f, 0.5f);
                break;
            case 7:
                markerColour = new Color(0.4f, 0.8f, 0.8f, 0.5f);
                break;
            case 8:
                markerColour = new Color(0.8f, 0.8f, 0.4f, 0.5f);
                break;
        }
        objectRenderer.material.color = markerColour;
        colourValue = value;
    }
}
