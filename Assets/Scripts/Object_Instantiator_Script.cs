using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class Object_Instantiator_Script : MonoBehaviour
{
    public GameObject Blackhole;
    public GameObject object1;
    public GameObject object2;
    private List<GameObject> Spawn_Locations = new List<GameObject>();
    private GameObject[] temp;
    private int Possible_Spawn_Locations_count;
    public Checklist_Tracker Checklist_Tracker;
    public int Objects_To_Spawn_Count = 10;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Create_Collectables();









    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Create_Collectables()
    {
        temp = GameObject.FindGameObjectsWithTag("object_spawn"); // because this returns an array not list we need to copy paste all elements to a list
        Possible_Spawn_Locations_count = temp.Length;
       
        Debug.Log(Possible_Spawn_Locations_count);

        for (int i = 0; i < Possible_Spawn_Locations_count; i++) // creates list of possible spawn locations
        {
            Spawn_Locations.Add(temp[i]);
        }


        for (int i = 0; i < Objects_To_Spawn_Count; i++)
        {
            Instantiate(Checklist_Tracker.All_GameObjects[Random.Range(0, Checklist_Tracker.All_GameObjects.Count)], Spawn_Locations[Random.Range(0, Possible_Spawn_Locations_count)].transform.position, Quaternion.Euler(0, 0, 0));
            // spawns a random game object from list to a random spwan location in the scene every time it is called
        }
    }

}
