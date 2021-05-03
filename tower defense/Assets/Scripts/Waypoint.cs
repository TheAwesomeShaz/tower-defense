using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] GameObject towerPrefab;
    // public Material transparentBlue;
    // public Material transparentRed;
    // public Material originalMaterial;


    [SerializeField] bool isPlaceable;
    public bool IsPlaceable { get { return isPlaceable; } }

    bool hasTower;

    private void Start()
    {
        //originalMaterial = towerPrefab.GetComponent<Renderer>().material;
    }

    void OnMouseOver()
    {
        if (isPlaceable && !hasTower)
        {
            // towerPrefab.GetComponentInChildren<Renderer>().material = transparentBlue;
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(towerPrefab, transform.position, Quaternion.identity);
                isPlaceable = false;
            }
        }
        // else
        // {
        //     towerPrefab.GetComponent<Renderer>().material = transparentRed;
        // }
    }
}
