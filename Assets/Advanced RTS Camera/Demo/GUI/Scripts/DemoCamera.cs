using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DemoCamera : MonoBehaviour {

    public RTSCamera rtsCamera;
    public InputField[] directionInps;

    public bool Vertical
    {
        get { return rtsCamera.verticalSetup == RTSCamera.ControlSetup.Axis; }
        set
        {
            if (value)
                rtsCamera.verticalSetup = RTSCamera.ControlSetup.Axis;
            else
                rtsCamera.verticalSetup = RTSCamera.ControlSetup.Disabled;
        }
    }

    public bool Horizontal
    {
        get { return rtsCamera.horizontalSetup == RTSCamera.ControlSetup.Axis; }
        set
        {
            if (value)
                rtsCamera.horizontalSetup = RTSCamera.ControlSetup.Axis;
            else
                rtsCamera.horizontalSetup = RTSCamera.ControlSetup.Disabled;
        }
    }

    public bool Rotate
    {
        get { return rtsCamera.rotateSetup == RTSCamera.ControlSetup.Axis; }
        set
        {
            if (value)
                rtsCamera.rotateSetup = RTSCamera.ControlSetup.KeyCode;
            else
                rtsCamera.rotateSetup = RTSCamera.ControlSetup.Disabled;
        }
    }

    public bool Tilt
    {
        get { return rtsCamera.tiltSetup == RTSCamera.ControlSetup.Axis; }
        set
        {
            if (value)
                rtsCamera.tiltSetup = RTSCamera.ControlSetup.KeyCode;
            else
                rtsCamera.tiltSetup = RTSCamera.ControlSetup.Disabled;
        }
    }

    public bool Orbit
    {
        get { return rtsCamera.orbitSetup == RTSCamera.ControlSetup.Axis; }
        set
        {
            if (value)
                rtsCamera.orbitSetup = RTSCamera.ControlSetup.Axis;
            else
                rtsCamera.orbitSetup = RTSCamera.ControlSetup.Disabled;
        }
    }

    public void SetDirectionX()
    {

        float x = Mathf.Clamp(int.Parse(directionInps[0].text), -1, 1);
        float y = Mathf.Clamp(int.Parse(directionInps[1].text), -1, 1);
        float z = Mathf.Clamp(int.Parse(directionInps[2].text), -1, 1);

        directionInps[0].text = x.ToString();
        directionInps[1].text = y.ToString();
        directionInps[2].text = z.ToString();


        rtsCamera.directionToMove = new Vector3(x,y,z);
    }

}
