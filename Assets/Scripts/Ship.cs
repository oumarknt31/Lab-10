using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ship : MonoBehaviour
{
 
    private FishCollector fishInScene;
    private GameObject fishToCollect;
    private Vector3 direction;
    private Rigidbody2D rb;
    private HUD hud;

    // Start is called before the first frame update
    void Start()
    {
        fishInScene = Camera.main.GetComponent<FishCollector>();
        rb = GetComponent<Rigidbody2D>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    // OnMouseDown is called whenever user made a right click on the ship
    IEnumerator OnMouseDown()
    {
        /*-----------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        /* This code is for the ship to go to the oldest fish */
        // Check if there are fish to collect
        while (fishInScene.fishies.Count > 0)
        {
            // Get the next fish to collect from the list
            fishToCollect = fishInScene.fishies.First();

            // Calculate direction to the current fish
            direction = (fishToCollect.transform.position - transform.position).normalized;

            // Move towards the current fish
            rb.AddForce(direction * 5f, ForceMode2D.Impulse);

            // Wait until the ship stops moving
            yield return new WaitUntil(() => rb.velocity.magnitude < 0.1f);

           
            // Nullify the speed of the ship
            rb.velocity = Vector2.zero;
            Debug.Log("Fish collected!");
        }
        /*-----------------------------------------------------------------------------------------------------------------------------------------------------------------------*/

        /*-----------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        /* This code is for the ship to go to the nearest fish*/
        /*
        while (fishInScene.fishies.Count != 0)
        {
            // Logic of going to the nearest fish

            // First fish gameobject in fishList
            fishToCollect = fishInScene.fishies.First(); 
            // Start with the distance of the first fish
            float nearestDistance = Vector3.Distance(transform.position, fishToCollect.transform.position);

            foreach (GameObject fish in fishInScene.fishies)
            {
                // Store the comparing distance of the other fish
                float comparingDistance = Vector3.Distance(transform.position, fish.transform.position);
                // Compare distances between fish and ship
                if (comparingDistance < nearestDistance)
                {
                    // Set the nearestDistance
                    nearestDistance = comparingDistance;
                    // Set new target
                    fishToCollect = fish; 
                }
            }

            // Get direction and go to the location
            direction = (fishToCollect.transform.position - transform.position).normalized; 
            rb.AddForce(direction * 5f, ForceMode2D.Impulse);



            // Wait until boat stops
            yield return new WaitUntil(() => rb.velocity.magnitude < 0.1f);
        */
        /*---------------------------------------------------------------------------------------------------------------------------------------------------------------------*/



    }

    void OnTriggerStay2D(Collider2D col)
    {
        // Check to see if the collider of the ship touched the fish to collect 
        if (col.gameObject == fishToCollect) 
        {
            // Destroys target and remove fish from the list
            //hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
            hud.AddPoints(1);
            Destroy(fishToCollect); 
            fishInScene.fishies.Remove(fishToCollect); 

            // Nullify the speed of the ship;
            rb.velocity = Vector2.zero;
            Debug.Log("Fish collected!");
        }
    }
}