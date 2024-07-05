using UnityEngine;

//Raycast callback events
public interface IRayscatEvents
{
    //Called on raycast hit's first time on any collider
    void OnRaycastEnter(RaycastHit hit);

    //Called every time based on frame rate of function if stay in collider
    void OnRaycastStay(RaycastHit hit);

    //Called when left the collider
    void OnRaycastExit(RaycastHit hit);
}