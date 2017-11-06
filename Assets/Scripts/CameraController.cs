using UnityEngine;

public class CameraController : MonoBehaviour {

    private bool doMovement = true;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 85.81f;//number set to this max in order to keep the window set properly
    public float minX = 10f;
    public float maxX = 80f;
    public float minZ = -70f;
    public float maxZ = -40f;


	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            doMovement = !doMovement;


        if (!doMovement)
            return;


        if (Input.GetKey("r") )
        {   //using space.world will allow you to access the world coordinates and ignore rotation of camera
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
            
        }
        if (Input.GetKey("e") )
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
           
        }
        if (Input.GetKey("w") )
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
         
        }
        if (Input.GetKey("q") )
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
            
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
       
        transform.position = pos;


    } 
}
