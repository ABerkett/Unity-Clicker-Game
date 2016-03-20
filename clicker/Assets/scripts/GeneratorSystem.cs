using UnityEngine;
using System.Collections;
using Clicker.Resources;
using System.Collections.Generic;
using System.Linq;

public class GeneratorSystem : Singleton<GeneratorSystem>
{
    public List<Generator> _Generators { get; set; }

    // Use this for initialization
    void Awake()        
    {
        _Generators = new List<Generator>();
    }

    // Update is called once per frame
    void Update()
    {
        _Generators.ForEach(g => g.Update());
    }

    public static Generator AddGenerator(Generator gen)
    {
        GeneratorSystem.Instance._Generators.Add(gen);
        return gen;
    }

    public static List<Generator> Generators()
    {
        return GeneratorSystem.Instance._Generators;
    }
}
