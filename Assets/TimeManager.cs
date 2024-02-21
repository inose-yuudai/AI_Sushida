// TimeManager.cs
using UnityEngine;
using UnityEngine.SceneManagement; // シーン管理に必要
using UnityEngine.UI; // UIシステムを使用

public class TimeManager : MonoBehaviour
{
    public float timeLimit = 60.0f; // 制限時間を60秒に設定
    private float timeElapsed = 0f; // 経過時間を追跡する変数

    public Text timeText; // UIテキストコンポーネントへの参照

    void Update()
    {
        // 経過時間を更新
        timeElapsed += Time.deltaTime;

        // 残り時間を計算
        float timeRemaining = timeLimit - timeElapsed;

        // 残り時間を分:秒の形式に整形してテキストに設定
        timeText.text = string.Format("残り時間: {0:00}:{1:00}", Mathf.FloorToInt(timeRemaining / 60), Mathf.FloorToInt(timeRemaining % 60));

        // 制限時間に達したかを確認
        if (timeElapsed >= timeLimit)
        {
            // "result" シーンに移行
            SceneManager.LoadScene("result");
        }
    }
}

