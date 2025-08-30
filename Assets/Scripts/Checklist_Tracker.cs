using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class NewMonoBehaviourScript : MonoBehaviour
{
   private GameObject Black_Hole_Mini;
    private GameObject Object_2;
    private GameObject Object_3;
    private int Number_Of_Different_Objects = 0;
    List<string> All_Possible_Objects;
    List<string> Cecklist_Items_Left;



















    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        All_Possible_Objects = Assign_GameObjects_And_Create_collectables_List();

        Cecklist_Items_Left = Initiate_Checklist();
        /*
        for(int i = 0; i < All_Possible_Objects.Count;i++)
        {
            Debug.Log(All_Possible_Objects[i]);
        }
       
        for (int i = 0; i < Cecklist_Items_Left.Count; i++)
        {
            Debug.Log(Cecklist_Items_Left[i]);
        }
        */



    }

    // Update is called once per frame
    void Update()
    {



    }


    private List<string> Assign_GameObjects_And_Create_collectables_List()
    {
        List<string> Temp_List = new List<string>();
       
        Black_Hole_Mini = GameObject.Find("Black_Hole_Mini"); Number_Of_Different_Objects++;
        Temp_List.Add(Black_Hole_Mini.name);

        Object_2 = GameObject.Find("Object_2"); Number_Of_Different_Objects++;
        Temp_List.Add(Object_2.name);

        Object_3 = GameObject.Find("Object_3"); Number_Of_Different_Objects++;
        Temp_List.Add(Object_3.name);









        return Temp_List;

    }




    

    private List<string> Initiate_Checklist()
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
