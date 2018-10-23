using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class ItemEffect : LinkedEffect {

    public ItemEffect()
    {
        DataLocation = DataLocation + "Item/";
    }

    protected override LinkedEffect GetNewItem()
    {
        return new ItemEffect();
    }
}