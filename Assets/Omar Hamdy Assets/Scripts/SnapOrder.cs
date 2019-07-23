using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SnapOrderFlag
{
    INTERACTABLE,
    SNAPPED
}
public enum MySnapAreas
{
    TurnedOn,
    TurnedOff
}
public class SnapOrder : MonoBehaviour
{

    public SnapOrderFlag snapFlag;
    public MySnapAreas snapAreasState;
    public SnapOrder nextInteractableObject;
    protected Collider thisCollider;
    public List<GameObject> snapZones;
    // Start is called before the first frame update
    void Start()
    {
        snapFlag = SnapOrderFlag.INTERACTABLE;
        thisCollider = GetComponent<Collider>();
        SwitchSnapAreasOff();
    }
    // Update is called once per frame
    void Update()
    {
        if (nextInteractableObject)
        {
            if (nextInteractableObject.snapFlag == SnapOrderFlag.SNAPPED && thisCollider.enabled)
            {
                if (thisCollider != null)
                {
                    thisCollider.enabled = false;
                }
            }
            else if ((nextInteractableObject.snapFlag == SnapOrderFlag.INTERACTABLE && !thisCollider.enabled))
            {
                if (thisCollider != null)
                {
                    thisCollider.enabled = true;
                }
            }
        }
        if (this.snapFlag == SnapOrderFlag.SNAPPED)
        {
            SwitchSnapAreasOn();
        }
        else if (this.snapFlag == SnapOrderFlag.INTERACTABLE)
        {
            SwitchSnapAreasOff();
        }

    }

    protected void SwitchSnapAreasOn()
    {
        if (snapAreasState != MySnapAreas.TurnedOn)
        {

            foreach (var snapAreaObj in snapZones)
            {
                snapAreaObj.GetComponent<Collider>().enabled = true;
            }
            snapAreasState = MySnapAreas.TurnedOn;
        }
    }

    protected void SwitchSnapAreasOff()
    {
        if (snapAreasState != MySnapAreas.TurnedOff)
        {
            foreach (var snapAreaObj in snapZones)
            {
                snapAreaObj.GetComponent<Collider>().enabled = false;
            }
            snapAreasState = MySnapAreas.TurnedOff;
        }
    }
}
