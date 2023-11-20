using UnityEngine;
using UnityEngine.SceneManagement;

public class UIStartGame : MonoBehaviour
{
    private int _currentIndex;
    
    private void Start() => 
        _currentIndex = SceneManager.GetActiveScene().buildIndex;

    public void StartGame() => 
        SceneManager.LoadScene(_currentIndex + 1); 
}