using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;
using System.Collections;
public class Player_Controller : MonoBehaviour
{
    public float Strafe_Speed = 20;
    public float Walk_Speed = 40;
    public GameObject Camera;
    public float Sprint_Mult = 1;
    private Rigidbody RB;
    public float Jump_Force = 10;
    private bool On_Ground = false;
    private GameObject Main_Camera;

   
   





    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Main_Camera = GameObject.Find("Main Camera");
        RB = GetComponent<Rigidbody>();

        
    }


    // Update is called once per frame
    void Update()
    {
      
        Jump();
      

    }


    private void LateUpdate()
    {
     
    }


    private void Move_Player()  //this fucking abomination of a player controller basically gets inputs from axises how you would expect BUT we apply the movement by 
                                //stealing the built in vectors like foward and right and multiply them by our calculated speeds. we then use linearvelocity for snappy movement but to preserve gravity we must first store the current gravity
                                //in its own vector to later apply tothe final movement vector. then we stack all three vectors adding them together combining their effects (including gravity preservation) into one Movement
                                //which we then apply to our rigidbodies linear velocity
    {
        if (Input.GetKey(KeyCode.LeftShift)) {
            Sprint_Mult = 1.5f;
                }
        else
        {
            Sprint_Mult = 1;
        }

        float Horizontal_Input = Input.GetAxis("Horizontal") * Strafe_Speed * Time.deltaTime * Sprint_Mult;
        float vertical_Input = Input.GetAxis("Vertical") * Walk_Speed * Time.deltaTime * Sprint_Mult;


        Vector3 Movement_Z = (transform.forward * vertical_Input) ;
        Vector3 Movement_X = (transform.right * Horizontal_Input);
        Vector3 Gravity = new Vector3(0f, RB.linearVelocity.y, 0f);
        Vector3 Movement = Movement_Z + Movement_X + Gravity;

        RB.linearVelocity = Movement;

    
    }


    private void FixedUpdate()
    {
        Move_Player();
        Match_Camera_Rotate();




    }

    private void Match_Camera_Rotate()
    {
        Quaternion turnRotation;
        float Main_Y = Main_Camera.transform.eulerAngles.y;

        turnRotation = Quaternion.Euler(0, Main_Y, 0); // idk why but taking a rotate value and turning it into a float makes it range from -1 to 1 so just mult by 180 to return it to form
        

        transform.rotation = turnRotation;

      


    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && On_Ground)
        {
            RB.AddForce(Vector3.up * Jump_Force, ForceMode.Impulse);
            On_Ground = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground")){
            On_Ground = true;

        }
    }


    

}

