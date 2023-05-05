using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;


    [Header("Optional")]
    public GameObject turret;

    

    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    void Start()
    {
       rend = GetComponent<Renderer>();
       startColor = rend.material.color;

       buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        return;
        
        
        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        buildManager.BuildTurretOn(this);

    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        return;
        
        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        } else
        {
            rend.material.color = notEnoughMoneyColor;
        }

    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
