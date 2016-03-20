using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractableInfo : MonoBehaviour
{
    public Text text;
    public Image health;

    public void UpdateInfo(Interactable inter)
    {
        text.text = inter.displayName;
        health.fillAmount = inter.health.HealthPercent;
    }
}
