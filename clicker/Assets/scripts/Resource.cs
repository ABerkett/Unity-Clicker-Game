using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Clicker.Resources
{
    public class Resource
    {
        public ResourceDetail Details { get; set; }
        public List<Generator> Generators { get; set; }
        //public List<Upgrade> Upgrades { get; set; }
        //public ResourceButton ResourceButton { get; set; }

            /*
                New Goals:
                Add a panel for storing Generators (display and purchase)
                Panel should be maintained by a System
                System stores a list of added Generators (we have this as GeneratorSystem)
                When a new Generator is added, put it in the store
                Sort by buy price (we need a buy price)
                Fade/Disable/Something when we don't have enough of the required resources
                Enable when we do
                On Click, add to the right kind of Generator
            */

        public Resource()
        {
            Details = new ResourceDetail()
            {
                Type = ResourceType.Gold,
                Quantity = 0,
                PerClick = 1,
                Name = "Gold"
            };

            Generators = new List<Generator>();

            Generators.Add(GeneratorSystem.AddGenerator(new Generator()
            {
                Type = ResourceType.Gold,
                Quantity = 1,
                PerPeriod = 0.1M,
                PeriodDuration = 1,
                TimeAccumulated = 0,
                BaseName = "Pickaxe"
            }));

            Generators.Add(GeneratorSystem.AddGenerator(new Generator()
            {
                Type = ResourceType.Gold,
                Quantity = 1,
                PerPeriod = 1,
                PeriodDuration = 1,
                TimeAccumulated = 0,
                BaseName = "Miner"
            }));

            BindGenerators();

        }

        override public string ToString()
        {
            return string.Format("{0}: {1}", Details.Name, Details.Quantity.ToString("G"));
        }

        // Bindings
        public void BindGenerators()
        {
            foreach (var gen in Generators)
            {
                gen.UpdateBinding(this);
            }
        }

        // Events
        public void OnResourceClicked(object source, ResourceClickedEventArgs args)
        {
            Details.Clicked();
        }

        public void OnResourceGenerated(object source, ResourceGeneratedEventArgs args)
        {
            Details.Add(args.AmountGenerated);
        }
    }
}