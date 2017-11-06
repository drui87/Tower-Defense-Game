using UnityEngine;

public class BuildManager : MonoBehaviour {

    //Singleton Pattern allows for only 1 instance for a build manager on the scene and makes it easy to access instance 
    public static BuildManager instance; //stores a reference to itself

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;//the "this" manager is put into the instance and it can be accessed anywhere

    }

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefab;

    public GameObject BuildEffect; 
  
    private TurretBluePrint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }
    // this is a property because it only allows it to get something from the variable but can never bet set

    public void BuildTurretOn(Node node)
    {

        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough Cash to build that!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;

        GameObject effect = (GameObject)Instantiate(BuildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret build! Money Left: " + PlayerStats.Money);

    }
    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
    }

}
