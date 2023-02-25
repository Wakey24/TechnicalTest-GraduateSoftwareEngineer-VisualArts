using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditController : MonoBehaviour
{
    public ObjectController targetObject;
    public GameController gameController;

    // Start is called before the first frame update

    public void DeleteObject()
    {
        if (gameController.gameIsPaused)
            return;
        gameController.RemoveObject(targetObject);
    }
    public void ScaleObject(float scale)
    {
        if (gameController.gameIsPaused || ( scale > 1 && targetObject.scaleValue > 3) || (scale < 1 && targetObject.scaleValue < -1))
            return;
        Vector3 i = (targetObject.gameObject.transform.localScale);
        targetObject.gameObject.transform.localScale = new Vector3(i.x * scale, i.y * scale, i.z * scale);
        if (scale > 1)
            targetObject.scaleValue++;
        else
            targetObject.scaleValue--;
    }
    public void RecolourObject()
    {
        if (gameController.gameIsPaused)
            return;
        if (targetObject.colourValue >= 8)
            targetObject.colourValue = -1;
        targetObject.SetColour(targetObject.colourValue + 1);
    }
    public void NewObjectShape()
    {
        if (gameController.gameIsPaused)
            return;
    }
}
