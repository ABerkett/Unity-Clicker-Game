using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentInteractive : MonoBehaviour
{
    public Interactable current;
    public Button image;
    public InteractableInfo info;

    void Start()
    {
        image.onClick.AddListener(() => DealDamage());
    }

    public void UpdateInteractable(Interactable inter)
    {
        current = inter;
        info.UpdateInfo(inter);
    }

    private void DealDamage()
    {
        if (current != null)
        {
            current.Damage(100);
            info.UpdateInfo(current);
        }
    }
}
