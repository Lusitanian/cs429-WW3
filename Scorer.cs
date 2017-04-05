using System.Collections.Generic;

public class Scorer
{
    private Dictionary<Player, int> Points = new Dictionary<Player, int>();

    public Scorer(List<Player> players)
    {
        foreach (var player in players)
        {
            Points.Add(player, 0);
        }
    }

    public void UpdateScores(World world)
    {
        foreach (var player in Points.Keys)
        {
            Points[player] = 0;
        }
        for (int i = 0; i < World.WIDTH; i++)
        {
            for (int j = 0; j < World.HEIGHT; j++)
            {
                Province p = world.GetProvinceAt(new Pos(i, j));
                if (p.Owner != null && p.City != null)
                {
                    Points[p.Owner] += p.City.Points;
                }
            }
        }
    }

    public int GetScore(Player player)
    {
        return Points[player];
    }
}