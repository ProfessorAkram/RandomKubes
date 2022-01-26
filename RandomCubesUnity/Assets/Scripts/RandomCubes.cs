/****
 * Created by: Stu Dent
 * Date Created: Jan 24, 2022
 * 
 * Last Edited by: NA
 * Last Edited: Jan 26, 2022
 * 
 * Description: Spawns multiple cube prefabs into scene.
 ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    /***VARAIBLES***/
    public GameObject cubePrefab; //new gameobject
    public float scalingFactor = 0.95f;
    public int numberOfCubes = 0; 
    [HideInInspector]
    public List<GameObject> gameObjectList; //list for all cubes


    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>();//instatiates the list

    }//end Start()

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++; //add to the number of cubes
        GameObject gObj = Instantiate<GameObject>(cubePrefab); //instatiate the cube

        gObj.name = "Cube" + numberOfCubes; //name property of the object

        gObj.transform.position = Random.insideUnitSphere; //random point inside a sphere radius of 1

        Color randColor = new Color(Random.value, Random.value, Random.value);
        gObj.GetComponent<Renderer>().material.color = randColor ; //assign random color to cube

        gameObjectList.Add(gObj); // add cube to list

        List<GameObject> removeList = new List<GameObject>();//list of game objects to remove

        foreach(GameObject goTemp in gameObjectList)
        {
            float scale = goTemp.transform.localScale.x; //record starting scale
            scale *= scalingFactor; //set scale multipled by scaling factor
            goTemp.transform.localScale = Vector3.one * scale; // transforms the scale

            if(scale <= 0.1f)
            {
                removeList.Add(goTemp); //add to remove list

            }//end if(scale <= 0.1f)

        }//end foreach(GameObject goTemp in gameObjectList)


        foreach(GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp); //remove from gameobject list
            Destroy(goTemp); //destroy object from scene

        }//end foreach(GameObject goTemp in removeList)


    }
}
