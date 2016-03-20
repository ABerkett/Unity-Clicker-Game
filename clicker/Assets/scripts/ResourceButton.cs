using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

namespace Clicker.Resources
{
    public class ResourceButton : MonoBehaviour
    {
        public Button button;
        public Resource resource;
        public Text text;

        public event EventHandler<ResourceClickedEventArgs> ResourceClicked;

        // Use this for initialization
        void Start()
        {
            resource = new Resource();
            BindResourceClickedEvent();
            button.onClick.AddListener(() => ResourceButtonClicked());
        }

        // Update is called once per frame
        void Update()
        {
            text.text = string.Format(resource.ToString());
        }

        public void BindResourceClickedEvent()
        {
            ResourceClicked += resource.OnResourceClicked;            
        }

        private void ResourceButtonClicked()
        {
            if (ResourceClicked != null)
            {
                ResourceClicked(this, new ResourceClickedEventArgs());
            }
        }
    }
}