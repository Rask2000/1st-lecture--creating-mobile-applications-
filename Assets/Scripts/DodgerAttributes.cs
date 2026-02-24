using UnityEngine;

public class DodgerAttributes
{
    private int _currentHealth;
    private int _maxHealth;
    private int _currentScore;
    
    public DodgerAttributes(int currentHealth, int maxHealth, int currentScore)
    {
        _currentHealth = currentHealth;
        _maxHealth = maxHealth;
        _currentScore = currentScore;
    }
    
    public int CurrentHealth()
    {
        return _currentHealth;
    }

    public int MaxHealth()
    {
        return _maxHealth;
    }  
    public int CurrentScore()
    {
        return _currentScore;
    }  

    public int SetHealth(int health)
    {
        _currentHealth = health;
        return _currentHealth;
    }
    public int SetScore(int score)
    {
        _currentScore = score;
        return _currentScore;
    }
}
