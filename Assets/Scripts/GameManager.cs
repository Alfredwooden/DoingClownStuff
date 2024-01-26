using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float happiness;

    // Start is called before the first frame update
    void Start()
    {
        happiness = 0;
    }

    // Update is called once per frame
    void Update()
    {

        // Win Condition
        if (happiness >= 100)
        {
            Time.timeScale = 0;
            Debug.Log("You Win");
        }
    }
}
