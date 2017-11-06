using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

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

        if (!buildManager.CanBuild)
            return;
        if (turret != null)
        {
            Debug.Log("Can't Do that!!!! - TODO: Display on screen.");
            return;
        }
        buildManager.BuildTurretOn(this);

    }

	// Use this for initialization
	void OnMouseEnter()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        
        // will highlight only if you have a turret to build
        if (!buildManager.CanBuild)
            return;

        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor; 
        }

	}
	
	// Update is called once per frame
	void OnMouseExit()
    {
        rend.material.color = startColor;	
	}
}
