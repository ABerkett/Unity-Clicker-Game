using UnityEngine;
using System.Collections;
using System;

namespace Clicker.Resources
{
    public class Generator
    {
        public Resource ParentResource { get; private set; }
        // ResourceType
        public ResourceType Type { get; set; }
        // Number of Generators owned
        public int Quantity { get; set; }
        // How much of a resource is generated in a period
        public decimal PerPeriod { get; set; }
        // How long a period takes
        public float PeriodDuration { get; set; }
        // Time this Generator has used towards creating a resource
        public float TimeAccumulated { get; set; }
        // Name of the Generator
        public string BaseName { get; set; }

        // Events
        public event EventHandler<ResourceGeneratedEventArgs> ResourceGenerated;

        // Update is called once per frame
        public void Update()
        {
            TimeAccumulated += Time.deltaTime;
            if (TimeAccumulated > PeriodDuration)
            {
                decimal amt = Quantity * PerPeriod;
                TimeAccumulated -= PeriodDuration;

                if (ResourceGenerated != null)
                {
                    ResourceGenerated(this, new ResourceGeneratedEventArgs()
                    {
                        AmountGenerated = amt
                    });
                }
            }
        }

        public void UpdateBinding(Resource res)
        {
            ParentResource = res;
            BindResourceGeneratedEvent();
        }

        private void BindResourceGeneratedEvent()
        {
            ResourceGenerated += ParentResource.OnResourceGenerated;
        }
    }
}