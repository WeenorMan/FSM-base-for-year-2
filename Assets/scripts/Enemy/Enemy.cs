using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PlayerSO playerData;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("="))
        {
            playerData.baseHealth++;
        }

        if (Input.GetKeyDown("-"))
        {
            playerData.baseHealth--;

        }
    }
}
