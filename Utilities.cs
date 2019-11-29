using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

    //the three methods below allow you to drag an object with your mouse in 3d space. click and drag/draga nd drop
    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }
    //MOUSE DRAGGING ENDS HERE

    //this is for calculating a weighted grade total for a course. it is modular and let's you change the number of
    //assignment categories, their weights, and the individual assignments with grades in those categories
    public void calculateGrades()
    {
        //bool isTest, isHomework, isProject;
        stringArray = new string[inputs.Length];
        for (int i = 0; i < stringArray.Length; i++)
        {
            stringArray[i] = inputs[i].text;
        }
        //store the inputs into an array so that we can reference them easily

        string testStringSplit = stringArray[3];
        string[] elements = testStringSplit.Split(' ');
        foreach (string str in elements)
        {
            Debug.Log(str.ToString());
        }
        string[] homeworkStringSplit = stringArray[4].Split();
        string[] projectStringSplit = stringArray[5].Split();
        //['2','3',' '] char array and 'string'
    }


    //This is a script I made to create an infinite road in a driving game.I have another function which returns random 
    //road 'pieces' aka 3d models.The basics of what are going on here is that index 0 of the array which holds the road pieces is 
    //destroyed, all the road pieces are moved down 1 place in the array, and then the new piece of road is instantiated at 
    //the end of the array.Effectively this makes an infinite road that gets deleted over time (as you drive past it). Okay thank you 
    //for coming to my TED talk.
    void CreateRoad()
    {
        RoadExit = JustSpawned.transform.Find("ExitPoint");
        SpawnPosition.transform.position = RoadExit.transform.position;
        JustSpawned = Instantiate<GameObject>(ReturnRoad());
        JustSpawned.transform.position = SpawnPosition.transform.position;

        Destroy(Roads[0]);
        Roads[0] = null;
        for (int i = 0; i < (Roads.Length - 1); i++)
        {
            if (Roads[i] == null && Roads[i + 1] != null)
            {
                Roads[i] = Roads[i + 1];
                Roads[i + 1] = null;
            }
        }
        Roads[Roads.Length - 1] = JustSpawned;
    }

    public CoinOption[] coins;
    // this takes a collection of 'coin option' which ar stacks of coins that can spawn
    //
    void Start()
    {
        coins = GetComponentsInChildren<CoinOption>();
        foreach (CoinOption coin in coins)
        {
            coin.gameObject.SetActive(false);
            //sets all the objects to inactive, if they aren't already
        }
        //Random rnd = new Random();
        //int num = 
        int num = Random.Range(0, 11);
        int allTheCoins = Random.Range(0, 25);
        //generate a random number

        if (allTheCoins >= 24)
        {
            //Debug.Log("allthecoins");
            foreach (CoinOption coin in coins)
            {
                coin.gameObject.SetActive(true);
                //1 in 25 chance that we spawn ALL the coins. it's like a bonus
            }
        }
        else
        {
            switch (num)
            {
                case 0:
                    coins[0].gameObject.SetActive(true);
                    break;
                case 1:
                    coins[1].gameObject.SetActive(true);
                    break;
                case 2:
                    coins[2].gameObject.SetActive(true);
                    break;
                case 3:
                    coins[3].gameObject.SetActive(true);
                    break;
                case 4:
                    coins[4].gameObject.SetActive(true);
                    break;
                case 5:
                    coins[5].gameObject.SetActive(true);
                    break;
                case 6:
                    coins[6].gameObject.SetActive(true);
                    break;
                case 7:
                    coins[7].gameObject.SetActive(true);
                    break;
                case 8:
                    coins[8].gameObject.SetActive(true);
                    break;
                case 9:
                    coins[9].gameObject.SetActive(true);
                    break;
                case 10:
                    coins[10].gameObject.SetActive(true);
                    break;
                case 11:
                    coins[11].gameObject.SetActive(true);
                    break;
                    //switch case that spawns one of the options based upon the random number
            }
        }
    }
}
