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
    // Start is called before the first frame update
    void Start()
    {
        snapFlag = SnapOrderFlag.INTERACTABLE;
        thisCollider = GetComponent<Collider>();
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
            else if((nextInteractableObject.snapFlag == SnapOrderFlag.INTERACTABLE && !thisCollider.enabled))
            {
                if (thisCollider != null)
                {
                    thisCollider.enabled = true;
                }
            }
        }

    }
}
