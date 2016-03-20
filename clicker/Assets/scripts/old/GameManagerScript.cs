using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;
using System.Linq;

public class GameManagerScript : MonoBehaviour
{

    List<PlayerResource> resources;
    public PlayerResource currentResource;
    public UnityEngine.UI.Text myLabel;

    // Use this for initialization
    void Start()
    {
        resources = new List<PlayerResource>();
        resources.Add(new PlayerResource()
        {
            ResourceId = 1,
            Quantity = 0,
            SystemName = "resource_1_rock_blah",
            Name = "Rock"
        });
        resources.Add(new PlayerResource()
        {
            ResourceId = 2,
            Quantity = 12,
            SystemName = "resource_2_cheese",
            Name = "Cheese"
        });

        currentResource = resources[0];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateMyLabel()
    {
        var test = string.Format("{0} ({1}): {2}", currentResource.SystemName, currentResource.Name, currentResource.Quantity);
        Debug.Log(test);
        myLabel.text = test;
    }

    public void NewGameClicked()
    {
        currentResource.Quantity++;
        UpdateMyLabel();
    }

    public void LoadClicked()
    {
        var resourceIndex = resources.IndexOf(currentResource);
        currentResource = resourceIndex + 1 < resources.Count ? resources[resourceIndex + 1] : resources[0];
        UpdateMyLabel();
    }
}
