using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SiblingRuleTile : RuleTile<SiblingRuleTile.Neighbor>
{

    public enum SiblingGroup
    {
        Sand,
        Grass
    }
    public SiblingGroup siblingGroup;

    public class Neighbor : RuleTile.TilingRule.Neighbor {
        public const int Sibling = 3;
    }

    public override bool RuleMatch(int neighbor, TileBase other)
    {
        if (other is RuleOverrideTile)
            other = (other as RuleOverrideTile).m_InstanceTile;

        switch (neighbor)
        {
            case Neighbor.This:
                {
                    return Check_This(other);
                    
                    //other is ExampleSiblingRuleTile
                    //    && (other as ExampleSiblingRuleTile).siblingGroup == this.siblingGroup;
                }
            case Neighbor.NotThis:
                {
                    return Check_NotThis(other);
                }
            case Neighbor.Sibling:
                {
                    return Check_Sibling(other);
                }
        }

        return base.RuleMatch(neighbor, other);
    }

    bool Check_This(TileBase tile) {
        if (siblingGroup == SiblingGroup.Sand) {
            return tile is SiblingRuleTile;
        } else if (siblingGroup == SiblingGroup.Grass) {
            return tile is SiblingRuleTile && (tile as SiblingRuleTile).siblingGroup == SiblingGroup.Grass;
        }

        return false;
    }

    bool Check_NotThis(TileBase tile) {
        return tile is not SiblingRuleTile;
    }

    bool Check_Sibling(TileBase tile) {
        if (siblingGroup == SiblingGroup.Sand) return true;
        
        if (siblingGroup == SiblingGroup.Grass) {
            return tile is SiblingRuleTile && (tile as SiblingRuleTile).siblingGroup == SiblingGroup.Sand;
        }

        return false;
    }
}
