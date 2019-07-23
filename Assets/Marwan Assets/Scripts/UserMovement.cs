using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class UserMovement : MonoBehaviour
{
    VRTK_ControllerEvents eventHandler;
    VRTK_Pointer pointerHandler;
    VRTK_StraightPointerRenderer cursorSelectPointer;
    VRTK_BezierPointerRenderer teleportPointer;
    VRTK_InteractUse useSetting;
    VRTK_InteractGrab grabSetting;

    void Start()
    {
        eventHandler = GetComponent<VRTK_ControllerEvents>();
        pointerHandler = GetComponent<VRTK_Pointer>();
        cursorSelectPointer = GetComponent<VRTK_StraightPointerRenderer>();
        teleportPointer = GetComponent<VRTK_BezierPointerRenderer>();
        useSetting = GetComponent<VRTK_InteractUse>();
        grabSetting = GetComponent<VRTK_InteractGrab>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (eventHandler.touchpadPressed)
        {
            useSetting.enabled = false;
            grabSetting.enabled = false;
            teleportPointer.enabled = true;
            pointerHandler.activationButton = VRTK_ControllerEvents.ButtonAlias.TouchpadPress;
            pointerHandler.selectionButton = VRTK_ControllerEvents.ButtonAlias.TouchpadPress;
            pointerHandler.enableTeleport = true;
            pointerHandler.pointerRenderer = teleportPointer;
            pointerHandler.interactWithObjects = false;
            cursorSelectPointer.enabled = false;

        }
        else
        {
            useSetting.enabled = true;
            grabSetting.enabled = true;
            pointerHandler.activationButton = VRTK_ControllerEvents.ButtonAlias.TriggerPress;
            pointerHandler.selectionButton = VRTK_ControllerEvents.ButtonAlias.TriggerPress;
            pointerHandler.enableTeleport = false;
            pointerHandler.interactUse = useSetting;
            pointerHandler.pointerRenderer = cursorSelectPointer;
            pointerHandler.interactWithObjects = true;
            cursorSelectPointer.enabled = true;
            teleportPointer.enabled = false;
        }
    }


}
