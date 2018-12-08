using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Touch : MonoBehaviour , IBeginDragHandler, IDragHandler, IEndDragHandler{

    public GameObject player;
    public Camera cameraMain;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector3 worldPos = cameraMain.ScreenToWorldPoint(eventData.position);
        worldPos.z = 0;
        if (player.GetComponent<Plane>().hitBorderL && worldPos.x < player.transform.position.x)
        {
            worldPos.x = player.transform.position.x;
        }
        if (player.GetComponent<Plane>().hitBorderR && worldPos.x > player.transform.position.x)
        {
            worldPos.x = player.transform.position.x;
        }
        if (player.GetComponent<Plane>().hitBorderD && worldPos.y < player.transform.position.y)
        {
            worldPos.y = player.transform.position.y;
        }
        if (player.GetComponent<Plane>().hitBorderU && worldPos.y > player.transform.position.y)
        {
            worldPos.y = player.transform.position.y;
        }
        player.transform.position = worldPos;
        // Debug.Log("begin" + worldPos);
        //Debug.Log("begin" + eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 worldPos = cameraMain.ScreenToWorldPoint(eventData.position);
        worldPos.z = 0;
        if (player.GetComponent<Plane>().hitBorderL && worldPos.x < player.transform.position.x)
        {
            worldPos.x = player.transform.position.x;
        }
        if (player.GetComponent<Plane>().hitBorderR && worldPos.x > player.transform.position.x)
        {
            worldPos.x = player.transform.position.x;
        }
        if (player.GetComponent<Plane>().hitBorderD && worldPos.y < player.transform.position.y)
        {
            worldPos.y = player.transform.position.y;
        }
        if (player.GetComponent<Plane>().hitBorderU && worldPos.y > player.transform.position.y)
        {
            worldPos.y = player.transform.position.y;
        }
        player.transform.position = worldPos;
        
        // Debug.Log("on" + worldPos);
        //Debug.Log("on" + eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Vector3 worldPos = camera.WorldToScreenPoint(eventData.position);
        //player.transform.position = worldPos;
    }
}
