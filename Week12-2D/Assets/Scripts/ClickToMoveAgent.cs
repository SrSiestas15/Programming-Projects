using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ClickMode
{
    Mode2d,
    Mode3D
}

public class ClickToMoveAgent : MonoBehaviour
{
    [SerializeField] private Seeker seekerAI;
    [SerializeField] private LayerMask raycastLayer;
    [SerializeField] ClickMode clickMode  = ClickMode.Mode2d;

    public void Awake()
    {
        if (seekerAI == null) seekerAI = GetComponent<Seeker>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            switch (clickMode)
            {
                case ClickMode.Mode2d:
                    Click2D(ray);
                    break;
                case ClickMode.Mode3D:
                    Click3D(ray);
                    break;
            }
        }
    }

    private void Click2D(Ray ray)
    {
        RaycastHit2D hitInfo = Physics2D.GetRayIntersection(ray, Mathf.Infinity, raycastLayer);
        if(hitInfo.collider != null)
        {
            seekerAI.StartPath(transform.position, hitInfo.point, OnPathComplete);
        }
    }

    private void Click3D(Ray ray)
    {
        if(Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, raycastLayer))
            seekerAI.StartPath(transform.position, hitInfo.point, OnPathComplete);
    }

    private void OnPathComplete(Path path)
    {

    }
}
