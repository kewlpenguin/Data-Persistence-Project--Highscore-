using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Checklist_Tracker : MonoBehaviour
{
    // new objects that want to be able to be instantiated must be declared here


   public GameObject Black_Hole_Mini;
    public GameObject Object_2;
    public GameObject Object_3;
   
 
    
    private int Number_Of_Different_Objects = 0;
    public List<string> All_Possible_Objects;
    public List<string> Checklist_Items_Left;
    public List<GameObject> All_GameObjects;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    



    }


    private void Awake()
    {
        All_Possible_Objects = Assign_GameObjects_And_Create_collectables_List();

        Checklist_Items_Left = Initiate_Checklist();

        All_GameObjects = Assign_GameObjects_to_All_Game_Objects();
    }


    // Update is called once per frame
    void Update()
    {



    }


    private List<string> Assign_GameObjects_And_Create_collectables_List() // adds gameobjects to the list using their names as strings plus clode (because when instantiated their name has clone tacked on
    {
        List<string> Temp_List = new List<string>();
       
        Temp_List.Add(Black_Hole_Mini.name + "(Clone)");
        Number_Of_Different_Objects++;

        Temp_List.Add(Object_2.name + "(Clone)");
        Number_Of_Different_Objects++;

        Temp_List.Add(Object_3.name + "(Clone)");
        Number_Of_Different_Objects++;








        return Temp_List;

    }

    private List<GameObject> Assign_GameObjects_to_All_Game_Objects() // for instantiation inside objectinstantiator script
    {
        List<GameObject> Temp_List = new List<GameObject>();

        Temp_List.Add(Black_Hole_Mini);
       

        Temp_List.Add(Object_2);
        

        Temp_List.Add(Object_3);
        

        return Temp_List;

    }




    private List<string> Initiate_Checklist() // creates a random number of required items checklist requiring random items
    {
        int Number_Of_Items_Needed = Random.Range(3, 8);
        List<string> Temp_List = new List<string>(); ;
        

        for (int i = 0; i <= Number_Of_Items_Needed; i++) // adds between 3 and 8 objects to the global checklist
        {
            Temp_List.Add(All_Possible_Objects[Random.Range(0, Number_Of_Different_Objects)]); //chooses random item from total list of collectables
        }

        return Temp_List;
    }








}
