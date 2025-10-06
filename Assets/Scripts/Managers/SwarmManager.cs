using UnityEngine;
using System.Collections.Generic;

public class SwarmManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject AnchovyFab;
    public List<GameObject> SwarmMembers;
    public float moveSpeed = 5f;
    private bool memberAdded = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SwarmMembers.Add(Player);
    }

    // Update is called once per frame
    void Update()
    {
        // DELETE -- FOR TESTING ONLY ========================================
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);

        if(movement.magnitude > 1f)
        {
            movement.Normalize();
        }

        Player.transform.Translate(movement * moveSpeed * Time.deltaTime);

        // ===================================================================
        // Spacebar to add Anchovy for testing purposes
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AddSwarmMember();
        }

        // New Member handling
        if(memberAdded)
        {
            Debug.Log("New Member");
            if (SwarmMembers.Count > 0)
            {

                // temporary test behavior. 
                foreach(GameObject member in SwarmMembers)
                {
                    Debug.Log(member.name);
                }
            }

            // Finish handling new member responsibitilies.
            memberAdded = false;
        }
    }

    void AddSwarmMember()
    {
        // Locate the player position
        Transform playerPosition = GameObject.Find("Player").transform;

        // Create offset from character position to spawn member at
        Vector3 spawnPostion = new Vector3(2, 0, 1);
        
        if (playerPosition != null)
        {
            // Create new instance of anchovy
            GameObject newMember = Instantiate(AnchovyFab, (playerPosition.position - spawnPostion), playerPosition.rotation);
            
            // Add new member to swarm list.
            SwarmMembers.Add(newMember);

            // Acts as signal to handle newMember logic in update loop.
            memberAdded = true;
        }
    }
}
