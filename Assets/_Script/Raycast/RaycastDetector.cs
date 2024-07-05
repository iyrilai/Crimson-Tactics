using Unity.VisualScripting;
using UnityEngine;

//This class used to call raycast event based 'IRaycastEvents'
public class RaycastDetector
{
    RaycastHit oldRaycastHit;

    //Detect Raycast on every frames and callback 'IRaycastEvents' methods
    public virtual void DetectRaycast(Ray ray, float maxDistance, IRayscatEvents events)
    {
        //Get the Hit
        if (Physics.Raycast(ray, out RaycastHit raycastHit, maxDistance))
        {
            //Call 'IRaycastEvents.OnRaycastEnter' when we entered ray entered collider
            if (oldRaycastHit.collider != raycastHit.collider) 
            {
                //Call 'IRaycastEvents.OnRaycastExit' if last collider exites
                if (oldRaycastHit.collider != null) events.OnRaycastExit(oldRaycastHit);

                events.OnRaycastEnter(raycastHit); 
            }

            //cache the current hit in 'oldRaycastHit' for next frame use.
            oldRaycastHit = raycastHit;
            

            //Called every frame when raycast is stayed
            events.OnRaycastStay(raycastHit);
            return;
        }

        //Call 'IRaycastEvents.OnRaycastExit' if last collider exites
        if (oldRaycastHit.collider != null) events.OnRaycastExit(oldRaycastHit);
        oldRaycastHit = default; //Reset 'oldRaycastHit'
    }    
}
