using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FishCollector : MonoBehaviour
{
    // Store fish in a list
    public List<GameObject> fishies = new List<GameObject>();
    [SerializeField] private GameObject fish;
    private Vector3 MousePosition;
    private Vector3 worldPosition;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            MousePosition = Input.mousePosition;
            MousePosition.z = -Camera.main.transform.position.z;
            worldPosition = Camera.main.ScreenToWorldPoint(MousePosition);

            GameObject newFish = Instantiate<GameObject>(fish);
            newFish.transform.position = worldPosition;
            fishies.Add(newFish);
        }
    }
}