using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ActionPanel : MonoBehaviour
{

    List<Interactable> interactables;
    public GameObject prefabButton;    
    public GameObject interactivesPickerPanel;
    
    public CurrentInteractive interactablePanel;

    // Use this for initialization
    void Start()
    {
        interactables = new List<Interactable>();
        interactables.Add(new Interactable()
        {
            displayName = "Tree",
            health = new Health() {
                BaseHealth = 1000,
                CurrentHealth = 1000,
                DecayRate = 50
            }
        });
        interactables.Add(new Interactable()
        {
            displayName = "Rock",
            health = new Health()
            {
                BaseHealth = 2000,
                CurrentHealth = 2000,
                DecayRate = 0
            }
        });

        var isFirst = true;

        foreach (var interactable in interactables)
        {
            GameObject aButton = (GameObject)Instantiate(prefabButton);
            aButton.transform.SetParent(interactivesPickerPanel.transform, false);
            aButton.transform.localScale = new Vector3(1, 1, 1);

            Button tempButton = aButton.GetComponent<Button>();
            SetUpButton(tempButton, interactable);

            if (isFirst)
            {
                SetInteractable(interactable);
                isFirst = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ButtonClicked(int buttonNo)
    {
        Debug.Log("Button clicked = " + buttonNo);
    }

    private void SetUpButton(Button but, Interactable inter)
    {        
        but.onClick.AddListener(() => SetInteractable(inter));
        but.GetComponentInChildren<Text>().text = inter.displayName;
    }

    private void SetInteractable(Interactable inter)
    {
        interactablePanel.UpdateInteractable(inter);
    }
}
