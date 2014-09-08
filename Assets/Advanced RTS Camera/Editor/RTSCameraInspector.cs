using UnityEngine;
using System.Collections;
using UnityEditor;
using System;

[CustomEditor(typeof(RTSCamera))]
public class RTSCameraInspector : Editor
{
    #region Inspector Variables

    #region Tabs Foldouts
    private bool controlTabFoldout = false;
    private bool camConfigTabFoldout = false;
    private bool behaviourTabFoldout = false;
    #endregion

    #region Behaviour Foldouts
    private bool autoAdjustBehavFoldout = false;
    private bool smoothBehavFoldout = false;
    private bool followBehavFoldout = false;
    private bool heightAdjustBehavFoldout = false;
    private bool edgeScrollingBehavFoldout = false;
    private bool cloudBehavFoldout = false;

    #endregion

    #region Controls Foldout
    private bool verticalContFoldout = false;
    private bool horizontalContFoldout = false;
    private bool rotateContFoldout = false;
    private bool tiltContFoldout = false;
    private bool directionalContFoldout = false;
    private bool middleMouseContFoldout = false;
    #endregion

    #region Camera Config Foldout
    //private bool speedConfFoldout = false;
    //private bool tiltConfFoldout = false;
    //private bool heightConfFoldout = false;
    //private bool rotateConfFoldout = false;
    #endregion

    private int directionContPreset = 0;
    private RTSCamera RTSCameraInstance;
    #endregion

    void OnEnable()
    {
        RTSCameraInstance = target as RTSCamera;
    }

    public override void OnInspectorGUI()
    {
        GUIStyle smallButtonStyle = new GUIStyle(EditorStyles.toolbarButton);
        smallButtonStyle.fixedWidth = 50;

        GUIStyle helpButtonStyle = new GUIStyle(EditorStyles.toolbarButton);
        helpButtonStyle.fixedWidth = 25;

        EditorGUILayout.BeginVertical("box");

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Controls", EditorStyles.toolbarDropDown)) controlTabFoldout = !controlTabFoldout;
        if (GUILayout.Button("[+]", smallButtonStyle))
        {
            controlTabFoldout = true;

            horizontalContFoldout = true;
            rotateContFoldout = true;
            tiltContFoldout = true;
            verticalContFoldout = true;
            directionalContFoldout = true;
            middleMouseContFoldout = true;
        }
        if (GUILayout.Button("[-]", smallButtonStyle))
        {
            controlTabFoldout = false;

            horizontalContFoldout = false;
            rotateContFoldout = false;
            tiltContFoldout = false;
            verticalContFoldout = false;
            directionalContFoldout = false;
            middleMouseContFoldout = false;
        }

        GUILayout.EndHorizontal();
        if (controlTabFoldout)
        {
            ControlEditor();
        }


        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Behaviour", EditorStyles.toolbarDropDown)) behaviourTabFoldout = !behaviourTabFoldout;

        if (GUILayout.Button("[+]", smallButtonStyle))
        {
            behaviourTabFoldout = true;

            autoAdjustBehavFoldout = true;
            smoothBehavFoldout = true;
            followBehavFoldout = true;
            heightAdjustBehavFoldout = true;
            edgeScrollingBehavFoldout = true;
            cloudBehavFoldout = true;


        }
        if (GUILayout.Button("[-]", smallButtonStyle))
        {
            behaviourTabFoldout = false;

            autoAdjustBehavFoldout = false;
            smoothBehavFoldout = false;
            followBehavFoldout = false;
            heightAdjustBehavFoldout = false;
            edgeScrollingBehavFoldout = false;
            cloudBehavFoldout = false;
        }


        GUILayout.EndHorizontal();
        if (behaviourTabFoldout)
        {
            BehaviourEditor();
        }

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Camera Configuration", EditorStyles.toolbarDropDown)) camConfigTabFoldout = !camConfigTabFoldout;
        if (GUILayout.Button("[+]", smallButtonStyle))
        {
            camConfigTabFoldout = true;

            //heightConfFoldout = true;
            //speedConfFoldout = true;
            //tiltConfFoldout = true;
        }
        if (GUILayout.Button("[-]", smallButtonStyle))
        {
            camConfigTabFoldout = false;

            //heightConfFoldout = false;
            //speedConfFoldout = false;
            //tiltConfFoldout = false;
        }

        GUILayout.EndHorizontal();
        if (camConfigTabFoldout)
        {
            CameraConfigEditor();
        }



        EditorGUILayout.EndVertical();
    }

    private void ControlEditor()
    {

        #region Vertical
        EditorGUILayout.BeginVertical("box");

        verticalContFoldout = GUILayout.Toggle(verticalContFoldout, new GUIContent("Vertical Controls", "Control the forward and backward movements of the Camera"), EditorStyles.foldout);

        if (verticalContFoldout)
        {
            EditorGUI.indentLevel++;



            GUILayout.BeginHorizontal();
            RTSCameraInstance.verticalSetup = (RTSCamera.ControlSetup)EditorGUILayout.EnumPopup(new GUIContent("Vertical Setup", "The control setup, should this movement use an axis or should keys be specified"), RTSCameraInstance.verticalSetup);
            GUILayout.EndHorizontal();

            if (RTSCameraInstance.verticalSetup == RTSCamera.ControlSetup.Axis)
            {

                GUILayout.BeginHorizontal();
                RTSCameraInstance.verticalAxis = EditorGUILayout.TextField(new GUIContent("Vertical Axis", "Specify the name of the axis to use, to control this movement"), RTSCameraInstance.verticalAxis);
                GUILayout.EndHorizontal();
            }
            else if (RTSCameraInstance.verticalSetup == RTSCamera.ControlSetup.KeyCode)
            {
                GUILayout.BeginHorizontal();
                RTSCameraInstance.forwardKey = (KeyCode)EditorGUILayout.EnumPopup("Positive Key (Forward)", RTSCameraInstance.forwardKey);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                RTSCameraInstance.backwardKey = (KeyCode)EditorGUILayout.EnumPopup("Negative Key (Backward)", RTSCameraInstance.backwardKey);
                GUILayout.EndHorizontal();
            }

            EditorGUI.indentLevel--;
        }
        EditorGUILayout.EndVertical();
        #endregion

        #region Horizontal
        EditorGUILayout.BeginVertical("box");

        horizontalContFoldout = GUILayout.Toggle(horizontalContFoldout, new GUIContent("Horizontal Controls", "Control the left and right movements of the Camera"), EditorStyles.foldout);
        if (horizontalContFoldout)
        {
            EditorGUI.indentLevel++;

            GUILayout.BeginHorizontal();
            RTSCameraInstance.horizontalSetup = (RTSCamera.ControlSetup)EditorGUILayout.EnumPopup(new GUIContent("Horizontal Setup", "The control setup, should this movement use an axis or should keys be specified"), RTSCameraInstance.horizontalSetup);
            GUILayout.EndHorizontal();


            if (RTSCameraInstance.horizontalSetup == RTSCamera.ControlSetup.Axis)
            {

                GUILayout.BeginHorizontal();
                RTSCameraInstance.horizontalAxis = EditorGUILayout.TextField(new GUIContent("Horizontal Axis", "Specify the name of the axis to use, to control this movement"), RTSCameraInstance.horizontalAxis);
                GUILayout.EndHorizontal();
            }
            else if (RTSCameraInstance.horizontalSetup == RTSCamera.ControlSetup.KeyCode)
            {
                GUILayout.BeginHorizontal();
                RTSCameraInstance.leftKey = (KeyCode)EditorGUILayout.EnumPopup("Negative Key (Left)", RTSCameraInstance.leftKey);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                RTSCameraInstance.rightKey = (KeyCode)EditorGUILayout.EnumPopup("Positive Key (Right)", RTSCameraInstance.rightKey);
                GUILayout.EndHorizontal();
            }

            EditorGUI.indentLevel--;
        }
        EditorGUILayout.EndVertical();
        #endregion

        #region Rotate
        EditorGUILayout.BeginVertical("box");

        rotateContFoldout = GUILayout.Toggle(rotateContFoldout, new GUIContent("Rotate Controls", "Controls Camera Rotation, i.e, looking around the current direction"), EditorStyles.foldout);
        if (rotateContFoldout)
        {
            EditorGUI.indentLevel++;

            GUILayout.BeginHorizontal();
            RTSCameraInstance.rotateYSetup = (RTSCamera.ControlSetup)EditorGUILayout.EnumPopup(new GUIContent("Rotate Setup", "The control setup, should this movement use an axis or should keys be specified"), RTSCameraInstance.rotateYSetup);
            GUILayout.EndHorizontal();


            if (RTSCameraInstance.rotateYSetup == RTSCamera.ControlSetup.Axis)
            {

                GUILayout.BeginHorizontal();
                RTSCameraInstance.rotateAxis = EditorGUILayout.TextField(new GUIContent("Rotate Axis", "Specify the name of the axis to use, to control this movement"), RTSCameraInstance.rotateAxis);
                GUILayout.EndHorizontal();
            }
            else if (RTSCameraInstance.rotateYSetup == RTSCamera.ControlSetup.KeyCode)
            {
                GUILayout.BeginHorizontal();
                RTSCameraInstance.rotateLeftKey = (KeyCode)EditorGUILayout.EnumPopup("Negative Key (Left)", RTSCameraInstance.rotateLeftKey);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                RTSCameraInstance.rotateRightKey = (KeyCode)EditorGUILayout.EnumPopup("Positive Key (Right)", RTSCameraInstance.rotateRightKey);
                GUILayout.EndHorizontal();
            }

            EditorGUI.indentLevel--;
        }
        EditorGUILayout.EndVertical();
        #endregion

        #region Tilt
        EditorGUILayout.BeginVertical("box");

        tiltContFoldout = GUILayout.Toggle(tiltContFoldout, new GUIContent("Tilt Controls", "Control the camera tilting, i.e, looking up (Max Tilt) and looking down (Min Tilt)"), EditorStyles.foldout);
        if (tiltContFoldout)
        {
            EditorGUI.indentLevel++;

            GUILayout.BeginHorizontal();
            RTSCameraInstance.rotateXSetup = (RTSCamera.ControlSetup)EditorGUILayout.EnumPopup(new GUIContent("Tilt Setup", "The control setup, should this movement use an axis or should keys be specified"), RTSCameraInstance.rotateXSetup);
            GUILayout.EndHorizontal();


            if (RTSCameraInstance.rotateXSetup == RTSCamera.ControlSetup.Axis)
            {

                GUILayout.BeginHorizontal();
                RTSCameraInstance.tiltAxis = EditorGUILayout.TextField(new GUIContent("Tilt Axis", "Specify the name of the axis to use, to control this movement"), RTSCameraInstance.tiltAxis);
                GUILayout.EndHorizontal();
            }
            else if (RTSCameraInstance.rotateXSetup == RTSCamera.ControlSetup.KeyCode)
            {

                GUILayout.BeginHorizontal();
                RTSCameraInstance.tiltIncKey = (KeyCode)EditorGUILayout.EnumPopup("Positive Key (Up)", RTSCameraInstance.tiltIncKey);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                RTSCameraInstance.tiltDecKey = (KeyCode)EditorGUILayout.EnumPopup("Negative Key (Down)", RTSCameraInstance.tiltDecKey);
                GUILayout.EndHorizontal();
            }

            EditorGUI.indentLevel--;
        }
        EditorGUILayout.EndVertical();
        #endregion

        #region Orbit
        EditorGUILayout.BeginVertical("box");

        tiltContFoldout = GUILayout.Toggle(tiltContFoldout, new GUIContent("Orbit Controls", "Control the camera orbiting around a point"), EditorStyles.foldout);
        if (tiltContFoldout)
        {
            EditorGUI.indentLevel++;

            GUILayout.BeginHorizontal();
            RTSCameraInstance.orbitSetup = (RTSCamera.ControlSetup)EditorGUILayout.EnumPopup(new GUIContent("Orbit Setup", "The control setup, should this movement use an axis or should keys be specified"), RTSCameraInstance.orbitSetup);
            GUILayout.EndHorizontal();


            if (RTSCameraInstance.orbitSetup == RTSCamera.ControlSetup.Axis)
            {

                GUILayout.BeginHorizontal();
                RTSCameraInstance.orbitAxis = EditorGUILayout.TextField(new GUIContent("Orbit Axis", "Specify the name of the axis to use, to control this movement"), RTSCameraInstance.tiltAxis);
                GUILayout.EndHorizontal();
            }
            else if (RTSCameraInstance.orbitSetup == RTSCamera.ControlSetup.KeyCode)
            {

                GUILayout.BeginHorizontal();
                RTSCameraInstance.orbitLeftKey = (KeyCode)EditorGUILayout.EnumPopup("Negative Key (Left)", RTSCameraInstance.orbitLeftKey);
                GUILayout.EndHorizontal();

                GUILayout.BeginHorizontal();
                RTSCameraInstance.orbitRightKey = (KeyCode)EditorGUILayout.EnumPopup("Positive Key (Right)", RTSCameraInstance.orbitRightKey);
                GUILayout.EndHorizontal();

            }

            EditorGUI.indentLevel--;
        }
        EditorGUILayout.EndVertical();
        #endregion

        #region DirectionalControl
        EditorGUILayout.BeginVertical("box");

        directionalContFoldout = GUILayout.Toggle(directionalContFoldout, new GUIContent("Direction Controls", "Move the camera in a user specified local direction"), EditorStyles.foldout);
        if (directionalContFoldout)
        {
            EditorGUI.indentLevel++;

            GUILayout.BeginHorizontal();
            RTSCameraInstance.directionSetup = (RTSCamera.ControlSetup)EditorGUILayout.EnumPopup(new GUIContent("Direction Setup", "The control setup, should this movement use an axis or should keys be specified"), RTSCameraInstance.directionSetup);
            GUILayout.EndHorizontal();

            switch (RTSCameraInstance.directionSetup)
            {

                case RTSCamera.ControlSetup.Axis:

                    GUILayout.BeginHorizontal();
                    RTSCameraInstance.directionAxis = EditorGUILayout.TextField(new GUIContent("Direction Axis", "Specify the name of the axis to use, to control this movement"), RTSCameraInstance.directionAxis);
                    GUILayout.EndHorizontal();
                    break;
                case RTSCamera.ControlSetup.KeyCode:

                    GUILayout.BeginHorizontal();
                    RTSCameraInstance.directionPositiveKey = (KeyCode)EditorGUILayout.EnumPopup("Positive Key", RTSCameraInstance.directionPositiveKey);
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    RTSCameraInstance.directionNegativeKey = (KeyCode)EditorGUILayout.EnumPopup("Negative Key", RTSCameraInstance.directionNegativeKey);
                    GUILayout.EndHorizontal();
                    break;
            }

            EditorGUILayout.Separator();

            GUILayout.BeginHorizontal();
            RTSCameraInstance.directionToMove = EditorGUILayout.Vector3Field(new GUIContent("Move Direction", "The direction to move the camera in response to the input i.e. when the input is positive it will move in this direction times the direction multiplier and when the input is negative it will move in the inverse direction times the input multiplier"), RTSCameraInstance.directionToMove);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            RTSCameraInstance.directionMultiplier = EditorGUILayout.Vector3Field(new GUIContent("Direction Multiplier", "Think of this as direction speed. The camera will move in the previously specified direction times this amount"), RTSCameraInstance.directionMultiplier);
            GUILayout.EndHorizontal();

            EditorGUI.indentLevel--;
        }
        EditorGUILayout.EndVertical();
        #endregion

        #region Middle Mouse Control
        EditorGUILayout.BeginVertical("box");

        middleMouseContFoldout = GUILayout.Toggle(middleMouseContFoldout, new GUIContent("Middle Mouse Controls", "Configure what movements should be executed while the middle mouse button is held."), EditorStyles.foldout);
        if (middleMouseContFoldout)
        {
            EditorGUI.indentLevel++;


            GUILayout.BeginHorizontal();
            RTSCameraInstance.middleMouseLocksMouse = EditorGUILayout.Toggle(new GUIContent("Middle Mouse Locks Cursor", "Should the mouse cursor be locked when the middle mouse is held down and unlocked when it is up."), RTSCameraInstance.middleMouseLocksMouse);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            RTSCameraInstance.invertMouseX = EditorGUILayout.Toggle(new GUIContent("Invert Mouse X", "An easy way to invert mouse X input"), RTSCameraInstance.invertMouseX);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            RTSCameraInstance.invertMouseY = EditorGUILayout.Toggle(new GUIContent("Invert Mouse Y", "An easy way to invert mouse Y input"), RTSCameraInstance.invertMouseY);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            RTSCameraInstance.mouseXAxis = EditorGUILayout.TextField(new GUIContent("Mouse X Axis", "The Axis to use when the mouse is held down. By default this is Mouse X but it can be adjusted to suit your setup"), RTSCameraInstance.mouseXAxis);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            RTSCameraInstance.mouseYAxis = EditorGUILayout.TextField(new GUIContent("Mouse Y Axis", "The Axis to use when the mouse is held down. By default this is Mouse Y but it can be adjusted to suit your setup"), RTSCameraInstance.mouseYAxis);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            RTSCameraInstance.mouseXSetup = (RTSCamera.MiddleMouseSetup)EditorGUILayout.EnumPopup(new GUIContent("Mouse X Controls", "What type of movement should the X axis of the mouse control"), RTSCameraInstance.mouseXSetup);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            RTSCameraInstance.mouseYSetup = (RTSCamera.MiddleMouseSetup)EditorGUILayout.EnumPopup(new GUIContent("Mouse Y Controls", "What type of movement should the Y axis of the mouse control"), RTSCameraInstance.mouseYSetup);
            GUILayout.EndHorizontal();

            EditorGUI.indentLevel--;
        }
        EditorGUILayout.EndVertical();
        #endregion

        #region Misc Controls
        EditorGUILayout.BeginVertical("box");

        middleMouseContFoldout = GUILayout.Toggle(middleMouseContFoldout, new GUIContent("Misc Controls", "Miscellaneous controls for the camera."), EditorStyles.foldout);
        if (middleMouseContFoldout)
        {
            EditorGUI.indentLevel++;


            GUILayout.BeginHorizontal();
            RTSCameraInstance.resetKey = (KeyCode)EditorGUILayout.EnumPopup(new GUIContent("Reset Key", "When this key is pressed all of the Camera's values will reset to the initial Camera's setup. This only includes Camera Configuration variables an not behavioural or control variables"), RTSCameraInstance.resetKey);
            GUILayout.EndHorizontal();


            EditorGUI.indentLevel--;
        }
        EditorGUILayout.EndVertical();
        #endregion

    }

    private void BehaviourEditor()
    {
        #region Auto Adjust
        EditorGUILayout.BeginVertical("box");

        autoAdjustBehavFoldout = GUILayout.Toggle(autoAdjustBehavFoldout, "Tilt Auto Adjust", EditorStyles.foldout);
        if (autoAdjustBehavFoldout)
        {
            EditorGUI.indentLevel++;

            GUILayout.BeginHorizontal();
            RTSCameraInstance.autoAdjustState = (RTSCamera.AutoAdjustState)EditorGUILayout.EnumPopup("Auto Adjust State", RTSCameraInstance.autoAdjustState);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            RTSCameraInstance.terrainAdjustTilt = EditorGUILayout.FloatField("Adjust To Tilt", RTSCameraInstance.terrainAdjustTilt);
            GUILayout.EndHorizontal();

            switch (RTSCameraInstance.autoAdjustState)
            {

                case RTSCamera.AutoAdjustState.DistanceToGround:

                    GUILayout.BeginHorizontal();
                    RTSCameraInstance.distanceFromGroundFinishAdjust = EditorGUILayout.FloatField(new GUIContent("Finish Adjusting At Distance", "The distance from ground level that the camera should finish adjusting at and adjust to the value specified in the \"Adjust To Tilt\" field"), RTSCameraInstance.distanceFromGroundFinishAdjust);
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    RTSCameraInstance.distanceFromGroundStartAdjust = Mathf.Max(RTSCameraInstance.distanceFromGroundFinishAdjust, EditorGUILayout.FloatField(new GUIContent("Start Adjusting At Distance","The distance from ground level that the camera should begin adjusting towards the value specified in the \"Adjust To Tilt\" field.") , RTSCameraInstance.distanceFromGroundStartAdjust));
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    RTSCameraInstance.groundHeightTiltAdjustCurve = EditorGUILayout.CurveField("Adjust Curve", RTSCameraInstance.groundHeightTiltAdjustCurve);
                    GUILayout.EndHorizontal();
                    break;
                case RTSCamera.
                AutoAdjustState.Height:
                    GUILayout.BeginHorizontal();
                    RTSCameraInstance.adjustHeightMin = EditorGUILayout.FloatField("Finish Adjusting At", RTSCameraInstance.adjustHeightMin);
                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal();
                    RTSCameraInstance.adjustHeightMax = EditorGUILayout.FloatField("Start Adjusting At", RTSCameraInstance.adjustHeightMax);
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    RTSCameraInstance.heightTiltAdjustCurve = EditorGUILayout.CurveField("Adjust Curve", RTSCameraInstance.heightTiltAdjustCurve);
                    GUILayout.EndHorizontal();
                    break;
            }


            EditorGUI.indentLevel--;
        }
        EditorGUILayout.EndVertical();

        #endregion

        #region Smooth Adjust
        EditorGUILayout.BeginVertical("box");

        smoothBehavFoldout = GUILayout.Toggle(smoothBehavFoldout, "Smooth Adjust", EditorStyles.foldout);
        if (smoothBehavFoldout)
        {
            EditorGUI.indentLevel++;

            #region Movement

            GUILayout.BeginHorizontal();
            RTSCameraInstance.smoothPosition = EditorGUILayout.Toggle("Smooth Movement", RTSCameraInstance.smoothPosition);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            RTSCameraInstance.movementAdjustSpeed = EditorGUILayout.FloatField("Movement Adjust Speed", RTSCameraInstance.movementAdjustSpeed);
            GUILayout.EndHorizontal();


            #endregion

            EditorGUILayout.Separator();

            #region Rotation

            GUILayout.BeginHorizontal();
            RTSCameraInstance.smoothRotate = EditorGUILayout.Toggle("Smooth Rotation", RTSCameraInstance.smoothRotate);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            RTSCameraInstance.rotateAdjustSpeed = EditorGUILayout.FloatField("Rotate Adjust Speed", RTSCameraInstance.rotateAdjustSpeed);
            GUILayout.EndHorizontal();

            #endregion

            EditorGUILayout.Separator();

            #region Tilt

            GUILayout.BeginHorizontal();
            RTSCameraInstance.smoothTilt = EditorGUILayout.Toggle("Smooth Tilt", RTSCameraInstance.smoothTilt);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            RTSCameraInstance.tiltAdjustSpeed = EditorGUILayout.FloatField("Tilt Adjust Speed", RTSCameraInstance.tiltAdjustSpeed);
            GUILayout.EndHorizontal();

            #endregion

            EditorGUI.indentLevel--;
        }
        EditorGUILayout.EndVertical();

        #endregion


        #region Height Adjust
        EditorGUILayout.BeginVertical("box");

        heightAdjustBehavFoldout = GUILayout.Toggle(heightAdjustBehavFoldout, "Height Adjust", EditorStyles.foldout);
        if (heightAdjustBehavFoldout)
        {
            EditorGUI.indentLevel++;

            GUILayout.BeginHorizontal();
            RTSCameraInstance.heightAdjustState = (RTSCamera.HeightAdjustState)EditorGUILayout.EnumPopup("Height Adjust State", RTSCameraInstance.heightAdjustState);
            GUILayout.EndHorizontal();

            EditorGUI.indentLevel--;
        }
        EditorGUILayout.EndVertical();

        #endregion

        #region Follow Transform
        EditorGUILayout.BeginVertical("box");

        followBehavFoldout = GUILayout.Toggle(followBehavFoldout, new GUIContent("Follow Transform", "Using this Behaviour you can specify a target to follow or to look at. While following a target you can specify a position offset from the target. eg offset (0, 50, 0) will attempt to place the camera at 50 units above the target (Max and Min height rules still apply). While looking at a target min tilt and max tilt rules still apply."), EditorStyles.foldout);
        if (followBehavFoldout)
        {
            EditorGUI.indentLevel++;

            GUILayout.BeginHorizontal();
            RTSCameraInstance.followTarget = (Transform)EditorGUILayout.ObjectField("Target To Follow", RTSCameraInstance.followTarget, typeof(Transform));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            RTSCameraInstance.followOffset = EditorGUILayout.Vector3Field("Position Offset", RTSCameraInstance.followOffset);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            RTSCameraInstance.shouldFollow = EditorGUILayout.Toggle("Should Follow Target", RTSCameraInstance.shouldFollow);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            RTSCameraInstance.shouldLookAt = EditorGUILayout.Toggle("LookAt Target", RTSCameraInstance.shouldLookAt);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            RTSCameraInstance.movementAdjustsOffset = EditorGUILayout.Toggle("Movement Adjusts Offset", RTSCameraInstance.movementAdjustsOffset);
            GUILayout.EndHorizontal();

            EditorGUI.indentLevel--;
        }
        EditorGUILayout.EndVertical();

        #endregion

        #region Mouse Behaviour
        EditorGUILayout.BeginVertical("box");

        edgeScrollingBehavFoldout = GUILayout.Toggle(edgeScrollingBehavFoldout, "Edge Scrolling", EditorStyles.foldout);
        if (edgeScrollingBehavFoldout)
        {
            EditorGUI.indentLevel++;

            GUILayout.BeginHorizontal();
            RTSCameraInstance.xEdgeSpeed = EditorGUILayout.FloatField(new GUIContent("Scroll Speed X", "The scroll speed for when the mouse move into or past the far Left or the far Right sides of the screen. Set to 0 to disable functionality"), RTSCameraInstance.xEdgeSpeed);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            RTSCameraInstance.yEdgeSpeed = EditorGUILayout.FloatField(new GUIContent("Scroll Speed Y", "The scroll speed for when the mouse move into or past the Top or the Bottom of the screen. Set to 0 to disable functionality"), RTSCameraInstance.yEdgeSpeed);
            GUILayout.EndHorizontal();

            EditorGUI.indentLevel--;
        }
        EditorGUILayout.EndVertical();

        #endregion

        #region Cloud Drawing
        EditorGUILayout.BeginVertical("box");

        cloudBehavFoldout = GUILayout.Toggle(cloudBehavFoldout, "Clouds", EditorStyles.foldout);
        if (cloudBehavFoldout)
        {
            EditorGUI.indentLevel++;

            GUILayout.BeginHorizontal();
            RTSCameraInstance.cloudDrawState = (RTSCamera.CloudDrawState)EditorGUILayout.EnumPopup(new GUIContent("Cloud Draw State", "The behaviour that decides how the clouds should be drawn. Draw At Percent will draw at a percent of the max height ( 100% equals max height). AtHeight will start and end the clouds at specific heights"), RTSCameraInstance.cloudDrawState);
            GUILayout.EndHorizontal();

            switch (RTSCameraInstance.cloudDrawState)
            {
                case RTSCamera.CloudDrawState.PercentOfMaxHeight:
                    GUILayout.BeginHorizontal();
                    RTSCameraInstance.cloudStartAtHeightPercent = EditorGUILayout.FloatField(new GUIContent("Start At Percent", ""), RTSCameraInstance.cloudStartAtHeightPercent);
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    RTSCameraInstance.cloudFinishAtHeightPercent = Math.Min(EditorGUILayout.FloatField(new GUIContent("Finish At Percent", ""), RTSCameraInstance.cloudFinishAtHeightPercent), 100f);
                    GUILayout.EndHorizontal();

                    break;
                case RTSCamera.CloudDrawState.AtHeight:
                    GUILayout.BeginHorizontal();
                    RTSCameraInstance.cloudStartAtHeight = EditorGUILayout.FloatField(new GUIContent("Start At Height", ""), RTSCameraInstance.cloudStartAtHeight);
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    RTSCameraInstance.cloudFinishAtHeight = Mathf.Min(EditorGUILayout.FloatField(new GUIContent("Finish At Height", ""), RTSCameraInstance.cloudFinishAtHeight), RTSCameraInstance.maxHeight);
                    GUILayout.EndHorizontal();
                    break;
            }

            GUILayout.BeginHorizontal();
            RTSCameraInstance.cloudMaxAlpha = Mathf.Clamp(EditorGUILayout.FloatField(new GUIContent("Cloud Max Transparency", "The transparency of the cloud when it reaches the maximum height. Value should be between 0 and 1. Note the transparency will interperlate the transparency from 0 to this number starting at the minimum point and ending at the maximum point."), RTSCameraInstance.cloudMaxAlpha), 0, 1);
            GUILayout.EndHorizontal();


            EditorGUI.indentLevel--;
        }
        EditorGUILayout.EndVertical();

        #endregion

    }

    private void CameraConfigEditor()
    {

        #region Movement
        EditorGUILayout.BeginVertical("box");
        //      speedConfFoldout = GUILayout.Toggle(speedConfFoldout, "Movement", EditorStyles.foldout);
        //       if (speedConfFoldout)
        //       {
        EditorGUI.indentLevel++;

        GUILayout.BeginHorizontal();
        RTSCameraInstance.movementSpeed = EditorGUILayout.FloatField(new GUIContent("Movement Speed", "The movement speed of the camera. This controls speed for Vertical and Horizontal movements"), RTSCameraInstance.movementSpeed);
        GUILayout.EndHorizontal();

        EditorGUI.indentLevel--;
        //        }
        EditorGUILayout.EndVertical();
        #endregion

        #region Rotate

        EditorGUILayout.BeginVertical("box");
        //      rotateConfFoldout = GUILayout.Toggle(rotateConfFoldout, "Rotation", EditorStyles.foldout);
        //     if (rotateConfFoldout)
        //      {
        EditorGUI.indentLevel++;

        GUILayout.BeginHorizontal();
        RTSCameraInstance.rotateSpeed = EditorGUILayout.FloatField(new GUIContent("Rotate Speed", "Camera Rotation speed around the Y axis i.e. rotating left and right"), RTSCameraInstance.rotateSpeed);
        GUILayout.EndHorizontal();

        EditorGUI.indentLevel--;
        //      }
        EditorGUILayout.EndVertical();
        #endregion

        #region Tilt
        EditorGUILayout.BeginVertical("box");
        //     tiltConfFoldout = GUILayout.Toggle(tiltConfFoldout, "Tilt", EditorStyles.foldout);
        //     if (tiltConfFoldout)
        //      {
        EditorGUI.indentLevel++;

        GUILayout.BeginHorizontal();
        RTSCameraInstance.tiltSpeed = EditorGUILayout.FloatField(new GUIContent("Tilt Speed", "The tilt speed i.e. tilting the camera up and down"), RTSCameraInstance.tiltSpeed);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        RTSCameraInstance.lowTilt = EditorGUILayout.FloatField(new GUIContent("Min Tilt", "The minimum tilt of the camera. A tilt of -90 will be facing upwards while a tilt of 90 will be facing downwards"), RTSCameraInstance.lowTilt);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        RTSCameraInstance.highTilt = EditorGUILayout.FloatField(new GUIContent("Max Tilt", "The maxmimum tilt of the camera. A tilt -90 will be facing upwards while a tilt of 90 will be facing downwards"), RTSCameraInstance.highTilt);
        GUILayout.EndHorizontal();

        EditorGUI.indentLevel--;

        //     }
        EditorGUILayout.EndVertical();
        #endregion

        #region Height

        EditorGUILayout.BeginVertical("box");
        //     heightConfFoldout = GUILayout.Toggle(heightConfFoldout, "Height", EditorStyles.foldout);
        //    if (heightConfFoldout)
        //     {
        EditorGUI.indentLevel++;

        GUILayout.BeginHorizontal();
        RTSCameraInstance.minHeightDistance = EditorGUILayout.FloatField(new GUIContent("Min Height", "The minimum height above ground level the camera can be"), RTSCameraInstance.minHeightDistance);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        RTSCameraInstance.maxHeight = EditorGUILayout.FloatField(new GUIContent("Max Height", "The maximum height the camera can go. Note this is not affected by ground level"), RTSCameraInstance.maxHeight);
        GUILayout.EndHorizontal();

        EditorGUI.indentLevel--;
        //    }
        EditorGUILayout.EndVertical();

        #endregion

        #region Misc Details

        EditorGUI.indentLevel++;


        EditorGUILayout.BeginVertical("box");

        EditorGUILayout.BeginHorizontal();
        RTSCameraInstance.useDeltaTimeToOne = EditorGUILayout.Toggle(new GUIContent("Delta Time Ignores TimeScale", "If this is enabled the delta time will not be affected by the TimeScale"), RTSCameraInstance.useDeltaTimeToOne);
        EditorGUILayout.EndHorizontal();


        EditorGUILayout.BeginHorizontal();
        if (RTSCameraInstance.groundMask == 0)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.HelpBox("Ensure that this is properly set to your ground layer to avoid complications", MessageType.Warning);
            EditorGUILayout.EndHorizontal();
        }
        RTSCameraInstance.groundMask = EditorGUILayout.LayerField(new GUIContent("Ground Layer", "The ground layer(s) the camera should interact with"), RTSCameraInstance.groundMask);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.EndVertical();

        EditorGUI.indentLevel--;


        #endregion

    }

}

