using System.Collections.Generic;

public class CoinCollection
{
    private List<Coin> _coins = new ();

    public void Add(Coin coin) => _coins.Add(coin);

    public void Remove(Coin coin)
    {
        if (_coins.Contains(coin))
            _coins.Remove(coin);
    }

    public void RemoveAll()
    {
        foreach (Coin coin in _coins) 
            coin.Destroy();

        _coins.Clear();
    }
}