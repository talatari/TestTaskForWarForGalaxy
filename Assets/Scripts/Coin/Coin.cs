using UnityEngine;

public class Coin : MonoBehaviour
{
    public void Destroy() => 
        Destroy(this.gameObject);
}