using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void Destroy() => 
        Destroy(this.gameObject);
}