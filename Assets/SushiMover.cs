using UnityEngine;

public class SushiMover : MonoBehaviour
{
    public float speed = 5.0f; // 寿司の移動速度
    private RectTransform rectTransform; // ImageのRectTransform
    private Canvas canvas; // 親のCanvas
    private float timer = 0f; // タイマー

    void Start()
    {
        rectTransform = GetComponent<RectTransform>(); // ImageのRectTransformを取得
        canvas = GetComponentInParent<Canvas>(); // 親のCanvasを取得
    }

    void Update()
    {
        // 寿司を右に移動させる
        transform.Translate(speed * Time.deltaTime * 20, 0, 0);

        // タイマーを更新
        timer += Time.deltaTime;

        // 8秒経過したかをチェック
        if (timer >= 7f)
        {
            // 8秒経過したら、GameManagerのDestroySushiとSpawnSushiメソッドを呼び出す
            GameObject.Find("GameManager").SendMessage("DestroySushi");
            GameObject.Find("GameManager").SendMessage("SpawnSushi");

            // タイマーをリセット
            timer = 0f;
        }
    }
}
