using UnityEngine;
using UnityEngine.SceneManagement; // シーン管理に必要
using UnityEngine.UI; // UIシステムを使用

public class TimeManager : MonoBehaviour
{
    public static float GameTimeLimit;  // 制限時間を60秒に設定（staticを削除）
    public float RTime=20.0f;

    public Text timeText; // UIテキストコンポーネントへの参照

    void Start()
    {
        GameTimeLimit=RTime;
    }

    void Update()
    {
        // 残り時間が0以上の場合のみ時間を減らす
        if (GameTimeLimit > 0)
        {
            // 制限時間を減少させる
            GameTimeLimit -= Time.deltaTime;

            // 残り時間をUIテキストに設定
            timeText.text = string.Format("残り時間: {0:00}:{1:00}", Mathf.FloorToInt(GameTimeLimit / 60), Mathf.FloorToInt(GameTimeLimit % 60));
        }
        else
        {
            // 残り時間が0になった場合（またはそれ以下になった場合）、"result" シーンに移行
            SceneManager.LoadScene("result");
        }
    }
}
