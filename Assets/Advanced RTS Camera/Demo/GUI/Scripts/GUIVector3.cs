using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIVector3 : MonoBehaviour {

    public InputField[] vectorInputs;

    private Vector3 vectorValue;

    public void ValidateVector()
    {
        float x, y, z;
        if (!float.TryParse(vectorInputs[0].text, out x))
            x = 0f;

        Debug.Log("valdated " + x);
    }

    public void ValidateVector(InputField inpField)
    {

    }


}
