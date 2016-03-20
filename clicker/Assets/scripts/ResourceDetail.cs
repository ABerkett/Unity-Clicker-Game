using UnityEngine;
using System.Collections;

namespace Clicker.Resources
{
    public class ResourceDetail
    {
        public ResourceType Type { get; set; }
        public decimal Quantity { get; set; }
        public decimal PerClick { get; set; }
        public string Name { get; set; }

        public void Clicked()
        {
            Quantity += PerClick;
        }

        public void Add(decimal val)
        {
            Quantity += val;
        }
    }
}