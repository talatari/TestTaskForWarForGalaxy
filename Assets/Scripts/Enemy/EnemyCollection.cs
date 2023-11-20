using System.Collections.Generic;

public class EnemyCollection
{
    private List<Enemy> _enemies = new ();

    public void Add(Enemy enemy) => _enemies.Add(enemy);

    public void Remove(Enemy enemy)
    {
        if (_enemies.Contains(enemy))
            _enemies.Remove(enemy);
    }

    public void RemoveAll()
    {
        foreach (Enemy enemy in _enemies) 
            enemy.Destroy();

        _enemies.Clear();
    }
}