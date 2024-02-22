using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0; // 現在のスコア
    public  Text scoreText; // スコアを表示するためのUIテキスト

    void Start()
    {
        scoreText.text = "Score: " + score;
    }

    // スコアを加算するメソッド
    public void AddScore()
    {
    
        score += 100;
        
        // スコアテキストの更新
        scoreText.text = "Score: " + score;
    }

    public void RestartButton(){
        score=0;
        SceneManager.LoadScene("Main");
    }
}
