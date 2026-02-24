using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
   
    [SerializeField] float spawnRate;
    [SerializeField] TextMeshProUGUI startText;

    [SerializeField] BaseBrick[] enemyPrefabArray;
  
    bool gameStarted = false;
    int score = 0;

    DodgerAttributes playerAttributes;
    Vector2 screenPos;

    [SerializeField] TextMeshProUGUI scoreText;
    
    void Start()
    {
        score=playerAttributes.CurrentScore();
        
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefabArray.Length);

        float randomX = Random.Range(0f, 1f);

        Vector2 viewPortPos = new Vector2(randomX, 1f);

        Vector2 worldPos = Camera.main.ViewportToWorldPoint(viewPortPos);

        
        Instantiate(enemyPrefabArray[randomIndex], worldPos, Quaternion.identity); 

        score++;

        UpdateText(score);
    }    

    void StartSpawning()
    {
        InvokeRepeating("SpawnEnemy", 0.5f, spawnRate);
    }

    private void Update()
    {
        if(transform.GetComponent<InputSystem>().IsPressing(out screenPos) && !gameStarted)
        {
            StartSpawning();
            gameStarted = true;
            startText.gameObject.SetActive(false);
        }

        Debug.Log("Current Score:" + score);
      
    }

    void UpdateText(int score)
    {
        scoreText.text = score.ToString();
    }

   
}
