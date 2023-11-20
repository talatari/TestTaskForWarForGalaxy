using UnityEngine;

[RequireComponent(
    typeof(CoinSpawner),
    typeof(EnemySpawner))]

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private CoinSpawner _coinSpawner;
    [SerializeField] private EnemySpawner _enemySpawner;
    
    public static Bootstrapper Instance;
    
    private Level _level;

    private void Awake()
    {
        InitializeSingleton();

        CreateLevel();
    }

    private void InitializeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void CreateLevel()
    {
        CoinCollection coinCollection = new CoinCollection();
        EnemyCollection enemyCollection = new EnemyCollection();

        _coinSpawner ??= GetComponent<CoinSpawner>();
        _coinSpawner.Initialize(coinCollection);
        
        _enemySpawner ??= GetComponent<EnemySpawner>();
        _enemySpawner.Initialize(enemyCollection);

        _level = new Level(coinCollection, _coinSpawner, enemyCollection, _enemySpawner);
        _level.Start();
    }
}