public class Level
{
    private CoinCollection _coinCollection;
    private CoinSpawner _coinSpawner;
    private EnemyCollection _enemyCollection;
    private EnemySpawner _enemySpawner;

    public Level(CoinCollection coinCollection, CoinSpawner coinSpawner, 
        EnemyCollection enemyCollection, EnemySpawner enemySpawner)
    {
        _coinCollection = coinCollection;
        _coinSpawner = coinSpawner;
        _enemyCollection = enemyCollection;
        _enemySpawner = enemySpawner;
    }

    public void Clear()
    {
        _coinCollection.RemoveAll();
        _enemyCollection.RemoveAll();
    }

    public void Start()
    {
        _coinSpawner.Spaw();
        _enemySpawner.Spaw();
    }

    public void Restart()
    {
        Clear();
        Start();
    }
}