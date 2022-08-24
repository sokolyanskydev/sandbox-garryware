﻿using System.Collections.Generic;
using System.Linq;
using Garryware.Entities;
using Sandbox;

namespace Garryware;

public static class CommonEntities
{
    public static List<OnBoxSpawn> OnBoxSpawns { get; private set; }
    public static ShuffledDeck<OnBoxSpawn> OnBoxSpawnsDeck { get; private set; }

    public static List<AboveBoxSpawn> AboveBoxSpawns { get; private set; } 
    public static ShuffledDeck<AboveBoxSpawn> AboveBoxSpawnsDeck { get; private set; } 
    
    public static List<OnBoxTrigger> OnBoxTriggers { get; private set; }
    
    public static Model Crate;
    public static Model Balloon;
    public static Model Ball;
    public static Model Target;
    
    public static void Precache()
    {
        Crate = Model.Load("models/citizen_props/crate01.vmdl");
        Balloon = Model.Load("models/citizen_props/balloonregular01.vmdl");
        Ball = Model.Load("models/citizen_props/beachball.vmdl");
    }

    public static void PrecacheWorldEntities()
    {
        OnBoxSpawns = Entity.All.OfType<OnBoxSpawn>().ToList();
        Assert.True(OnBoxSpawns.Count > 0);
        
        OnBoxSpawnsDeck = new ShuffledDeck<OnBoxSpawn>();
        OnBoxSpawnsDeck.AddRange(OnBoxSpawns);
        OnBoxSpawnsDeck.Shuffle();
        Assert.True(OnBoxSpawnsDeck.Count > 0);
        
        AboveBoxSpawns = Entity.All.OfType<AboveBoxSpawn>().ToList();
        Assert.True(AboveBoxSpawns.Count > 0);
        
        AboveBoxSpawnsDeck = new ShuffledDeck<AboveBoxSpawn>();
        AboveBoxSpawnsDeck.AddRange(AboveBoxSpawns);
        AboveBoxSpawnsDeck.Shuffle();
        Assert.True(AboveBoxSpawnsDeck.Count > 0);
        
        OnBoxTriggers = Entity.All.OfType<OnBoxTrigger>().ToList();
        Assert.True(OnBoxTriggers.Count > 0);
    }

    public static void ShuffleWorldEntityDecks()
    {
        OnBoxSpawnsDeck.Shuffle();
        AboveBoxSpawnsDeck.Shuffle();
    }
    
}
