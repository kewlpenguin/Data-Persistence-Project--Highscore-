using UnityEngine;

public class Camera_Mouse_Look : MonoBehaviour
{
    public float Mouse_Sensetivity = 200;
    public GameObject Player;
    public float xRotation = 0f;
    public float yRotation = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.Find("Player");




    }

    // Update is called once per frame
    void Update()
    {
      
       

    }




    private void LateUpdate()
    {
        Adjust_Camera_Rotation();
        Follow_Player();
       
    }
    private void Adjust_Camera_Rotation()
    {



        float mouseX = Input.GetAxis("Mouse X") * Mouse_Sensetivity * Time.deltaTime; // get rotation from mouse and use transform.rotate to use the offset
        float mouseY = Input.GetAxis("Mouse Y") * Mouse_Sensetivity * Time.deltaTime;

        xRotation -= mouseY;                            // calculate change from next rotation offset
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // if offset would yesult in less than or greater than 90 x rotation throw it out, else apply the change
        yRotation += mouseX;


        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);  // setting rotation value instead of using rotate so we cant accidentally go over ort under 90
                           

        
    }
    
    
    
    private void Follow_Player()
    {
        transform.position = Player.transform.position;



    }








}
