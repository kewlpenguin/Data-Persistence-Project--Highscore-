using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float Strafe_Speed = 20;
    public float Walk_Speed = 40;
    public GameObject Camera;
    public float Sprint_Mult = 1;
    private Rigidbody Rigidbody;
    public float Jump_Force = 10;
    private bool On_Ground = true;









    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();






    }
    private void LateUpdate()
    {
        Match_Camera_Rotate();
    }


    private void Move_Player()
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

        Rigidbody.AddForce(transform.forward * vertical_Input,ForceMode.VelocityChange);
        Rigidbody.AddForce(transform.right * Horizontal_Input, ForceMode.VelocityChange);

    }

    private void FixedUpdate()
    {
        Move_Player();
   
    }

    private void Match_Camera_Rotate()
    {
        transform.rotation = Quaternion.Euler(0, Camera.GetComponent<Camera_Mouse_Look>().yRotation, 0);




    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && On_Ground)
        {
            Rigidbody.AddForce(Vector3.up * Jump_Force, ForceMode.Impulse);
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

