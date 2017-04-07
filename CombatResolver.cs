using System;
using System.Collections.Generic;

public class CombatResolver
{
    private const int DAMAGE = 10;

    private static Random generator = new Random();

    private ArmyManager armies;

    public CombatResolver(ArmyManager armies)
    {
        this.armies = armies;
    }

    public void Engage(Player moving, List<Player> players)
    {
        foreach (var player in players)
        {
            if (player != moving)
            {
                AttackPlayer(moving, player);
            }
        }
    }

    private void AttackPlayer(Player moving, Player player)
    {
        foreach (var attacking in moving.ArmyList)
        {
            foreach (var defending in player.ArmyList)
            {
                if (armies.ArmyPosition(attacking).IsInRange(armies.ArmyPosition(defending), attacking.Range))
                {
                    defending.TakeDamage(generator.Next() % DAMAGE);
                }
            }
        }
    }
}