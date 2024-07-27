using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/*
public class ConnectToSand : RuleTile<ConnectToSand.Neighbor> {
    public class Neighbor : RuleTile.TilingRule.Neighbor {
        public const int Other = 3;
    }

    public override bool RuleMatch(int neighbor, TileBase tile) {
        switch (neighbor) {
            case Neighbor.Other: return tile != this && tile != null;
        }
        return base.RuleMatch(neighbor, tile);
    }
}
*/
public class ExampleSiblingRuleTile : RuleTile
{

    public enum SiblingGroup
    {
        Sand,
        Grass
    }
    public SiblingGroup siblingGroup;

    public class Neighbor : RuleTile<ExampleSiblingRuleTile.Neighbor> {
        public const int Sibling = 3;
    }

    public override bool RuleMatch(int neighbor, TileBase other)
    {
        if (other is RuleOverrideTile)
            other = (other as RuleOverrideTile).m_InstanceTile;

        switch (neighbor)
        {
            case TilingRule.Neighbor.This:
                {
                    return Check_This(other);
                    
                    //other is ExampleSiblingRuleTile
                    //    && (other as ExampleSiblingRuleTile).siblingGroup == this.siblingGroup;
                }
            case TilingRule.Neighbor.NotThis:
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
            return tile is ExampleSiblingRuleTile;
        } else if (siblingGroup == SiblingGroup.Grass) {
            return tile is ExampleSiblingRuleTile && (tile as ExampleSiblingRuleTile).siblingGroup == SiblingGroup.Grass;
        }

        return false;
    }

    bool Check_NotThis(TileBase tile) {
        return !Check_This(tile);
    }

    bool Check_Sibling(TileBase tile) {
        if (siblingGroup == SiblingGroup.Sand) {
            return true;
        } else if (siblingGroup == SiblingGroup.Grass) {
            return tile is ExampleSiblingRuleTile && (tile as ExampleSiblingRuleTile).siblingGroup == SiblingGroup.Sand;
        }

        return false;
    }
}
