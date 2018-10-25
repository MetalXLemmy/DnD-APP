using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SpellEffect : LinkedEffect
{
    public SpellEffect()
    {
        DataLocation = DataLocation + "Effect/Spell/";
    }

    protected override LinkedEffect GetNewItem()
    {
        return new SpellEffect();
    }
}