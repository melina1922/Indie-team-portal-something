﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextualPosition : MonoBehaviour
{

    [SerializeField]
    private int myOwnPortal;
    [SerializeField]
    private PortalSwitcher portalSwitchManager;

    private GameObject myAssignedObject;
    private BoxCollider myOwnCollider;



    //a script for locations that collect pickups to be placed.

        //if the object placed is a diorama, arrange it in its appropriate position and switch the portals to accomidate 
        //the new appropriate position.
        
        //deactivate your own collider and if the object you contain is picked up then deactivate and deactivate the portals associated.
    // Start is called before the first frame update
    void Start()
    {
        myOwnCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttachToDioramaObject(GameObject Target)
    {
        myAssignedObject = Target;
        PickupObjectScript targetScript = Target.GetComponent<PickupObjectScript>();
        portalSwitchManager.BeginSwitch(myOwnPortal, targetScript.myAssociatedPortal);
        myOwnCollider.enabled = false;
    }
    public void DetachToDioramaObject()
    {
        PickupObjectScript targetScript = myAssignedObject.GetComponent<PickupObjectScript>();
        portalSwitchManager.RevertPortal(targetScript.myAssociatedPortal);
        myAssignedObject = null;
        portalSwitchManager.RevertPortal(myOwnPortal);
        myOwnCollider.enabled = true;
    }
}
