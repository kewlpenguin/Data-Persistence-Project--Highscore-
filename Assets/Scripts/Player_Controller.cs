using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using TMPro;
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
    public float Initial_Gravity_Mult = 1.5f;
    public CursorLockMode Cursor_Locked = CursorLockMode.Locked;
    private TextMeshProUGUI Pickup_Text;
    public bool Switch = false;
    public LayerMask Collectable_Layer;
    private Image tentacle;
    private GameObject currentCollectable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Main_Camera = GameObject.Find("Main Camera");
        RB = GetComponent<Rigidbody>();
        Physics.gravity *= Initial_Gravity_Mult;

        Cursor.lockState = Cursor_Locked; // initialize cursor as locked (for now)
       
        Pickup_Text = GameObject.Find("Pickup_Text").GetComponent<TextMeshProUGUI>();
        Pickup_Text.gameObject.SetActive(true);
       
        Collectable_Layer = LayerMask.GetMask("collectables");
       
        tentacle = GameObject.Find("Screen_Middle").GetComponent<Image>();
        tentacle.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

        Jump();
        Pickup_Object();

    }

    private void FixedUpdate()
    {
        Move_Player();
        Match_Camera_Rotate();


    }
    private void LateUpdate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            On_Ground = true;

        }
    }


    private void Move_Player()  //this fucking abomination of a player controller basically gets inputs from axises how you would expect BUT we apply the movement by 
                                //stealing the built in vectors like foward and right and multiply them by our calculated speeds. we then use linearvelocity for snappy movement but to preserve gravity we must first store the current gravity
                                //in its own vector to later apply tothe final movement vector. then we stack all three vectors adding them together combining their effects (including gravity preservation) into one Movement
                                //which we then apply to our rigidbodies linear velocity
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprint_Mult = 1.5f;
        }
        else
        {
            Sprint_Mult = 1;
        }

        float Horizontal_Input = Input.GetAxis("Horizontal") * Strafe_Speed * Time.deltaTime * Sprint_Mult;
        float vertical_Input = Input.GetAxis("Vertical") * Walk_Speed * Time.deltaTime * Sprint_Mult;


        Vector3 Movement_Z = (transform.forward * vertical_Input);
        Vector3 Movement_X = (transform.right * Horizontal_Input);
        Vector3 Gravity = new Vector3(0f, RB.linearVelocity.y, 0f);
        Vector3 Movement = Movement_Z + Movement_X + Gravity;

        RB.linearVelocity = Movement;


    }




    private void Match_Camera_Rotate() // pulls euler angles from main camera and applies them to tyhe player 1 line after moving the player
    {
        Quaternion turnRotation;
        float Main_Y = Main_Camera.transform.eulerAngles.y;

        turnRotation = Quaternion.Euler(0, Main_Y, 0);

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

    private void Pickup_Object()
    {
        bool Presses_E_To_Pickup = Input.GetKeyDown(KeyCode.E);
        RaycastHit Object_In_Range_Info;
        bool Object_In_Range = Physics.Raycast(Camera.transform.position, Camera.transform.forward, out Object_In_Range_Info, 5f, Collectable_Layer);


        if (Switch != Object_In_Range) // whenever objectinrange changes (which will only happen while hovering collectables) we will set the E object active 
        {
            Switch = Object_In_Range;
            Pickup_Text.gameObject.SetActive(!Switch);
            tentacle.gameObject.SetActive(Switch); //shows option to grab object
        }

        if (Object_In_Range_Info.collider != null && Presses_E_To_Pickup) // because this statement will run again after the object has been destroyedwe will run into a null reference exeptrion. but because we still neet to switch back to default state we just check 
                                                                          // if the object pointed at is already null
        {
            Destroy(Object_In_Range_Info.collider.gameObject);

        }
    }

}
   
       
    



