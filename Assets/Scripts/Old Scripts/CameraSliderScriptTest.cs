using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using Unity.VisualScripting;
using System.ComponentModel.Design;

public class CameraSliderScriptTest : MonoBehaviour, IPointerUpHandler
{
    public CameraPathFollow cameraScript;


    //cameraScript.changingCameraValue = true;
    
    public void OnSelect(BaseEventData eventData)
    {
        //Debug.Log(this.gameObject.name + " was selected");
        Debug.Log("Sliding started SELECT");
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Sliding started DRAG");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Sliding started POINTER");
    }

    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        Debug.Log("Sliding started ON INIT");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Sliding finished");
        //cameraScript.SetPositionToSlider();
        Debug.Log("Camera Pos:" + cameraScript.gameObject.transform.position);
    }
    
    

}