using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerkSystem : MonoBehaviour {

    public List<Perk> perks;

    public void ApllyPerks() {
        for (int i = 0; i < perks.Count; i++)
        {
            perks[i].ImplementPerk();
        }
    }

    public void DeactivatePerks() {
        for (int i = 0; i < perks.Count; i++)
        {
            perks[i].UnimplementPerk();
        }
    }
}
