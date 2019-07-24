using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SnapOrderFlag
{
    INTERACTABLE,
    SNAPPED
}

public class SnapOrder : MonoBehaviour
{

    public SnapOrderFlag snapFlag;
    public SnapOrder nextInteractableObject;
    protected Collider thisCollider;
    protected SnapOrder AssemblyBase;
    public List<SnapOrder> snapOrderObjects;
    public List<GameObject> snapZones;
    public GameObject MySnapZone;
    // Start is called before the first frame update
    void Start()
    {
        snapFlag = SnapOrderFlag.INTERACTABLE;
        thisCollider = GetComponent<Collider>();
        SwitchSnapAreasOff();
        AssemblyBase = snapOrderObjects[0];
        AssemblyBase.SwitchSnapAreasOn();
    }
    //Update is called once per frame
    void Update()
    {
        //if (nextInteractableObject)
        //{
        //    if (nextInteractableObject.snapFlag == SnapOrderFlag.SNAPPED && thisCollider.enabled)
        //    {
        //        if (thisCollider != null)
        //        {
        //            thisCollider.enabled = false;
        //        }
        //    }
        //    else if ((nextInteractableObject.snapFlag == SnapOrderFlag.INTERACTABLE && !thisCollider.enabled))
        //    {
        //        if (thisCollider != null)
        //        {
        //            thisCollider.enabled = true;
        //        }
        //    }
        //}
        //if (this.snapFlag == SnapOrderFlag.SNAPPED)
        //{
        //    SwitchSnapAreasOn();
        //}
        //else if (this.snapFlag == SnapOrderFlag.INTERACTABLE)
        //{
        //    SwitchSnapAreasOff();
        //}
        //   
        if (snapFlag == SnapOrderFlag.SNAPPED)
        {
            int thisSnapOrderIndex = snapOrderObjects.IndexOf(this);

            //if (MySnapZone)
            //{
            //    this.transform.position = MySnapZone.transform.position;
            //    this.transform.rotation = MySnapZone.transform.rotation;
            //}
        }
    }

    protected void SwitchSnapAreasOn()
    {
        foreach (var snapAreaObj in snapZones)
        {
            snapAreaObj.GetComponent<Collider>().enabled = true;
        }
    }

    protected void SwitchSnapAreasOff()
    {
        foreach (var snapAreaObj in snapZones)
        {
            snapAreaObj.GetComponent<Collider>().enabled = false;
        }
    }
    public void OnSnappingThis()
    {
        if (this != AssemblyBase)
        {
            snapFlag = SnapOrderFlag.SNAPPED;
            int thisSnapOrderIndex = snapOrderObjects.IndexOf(this);
            if (snapOrderObjects[thisSnapOrderIndex - 1] != AssemblyBase)
            {
                snapOrderObjects[thisSnapOrderIndex - 1].thisCollider.enabled = false;
            }

            this.MySnapZone.GetComponent<Collider>().enabled = false;
            //transform.parent = snapOrderObjects[thisSnapOrderIndex - 1].transform;
            SwitchSnapAreasOn();
        }

    }
    public void OnUnSnappingThis()
    {
        if (this != AssemblyBase)
        {
            snapFlag = SnapOrderFlag.INTERACTABLE;
            int thisSnapOrderIndex = snapOrderObjects.IndexOf(this);
            if (snapOrderObjects[thisSnapOrderIndex - 1] != AssemblyBase)
            {
                snapOrderObjects[thisSnapOrderIndex - 1].thisCollider.enabled = true;
            }
            this.MySnapZone.GetComponent<Collider>().enabled = true;

            //transform.parent = AssemblyBase.transform.parent;
            SwitchSnapAreasOff();
        }
    }
}
