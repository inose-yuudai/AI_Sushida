// SushiMover.cs
using UnityEngine;

public class SushiManager : MonoBehaviour
{
    public float speed = 5.0f; // 寿司の移動速度
    private RectTransform rectTransform; // ImageのRectTransform
    private Canvas canvas; // 親のCanvas

    void Start()
    {
        rectTransform = GetComponent<RectTransform>(); // ImageのRectTransformを取得
        canvas = GetComponentInParent<Canvas>(); // 親のCanvasを取得
    }

    void Update()
    {
        // 寿司を右に移動させる
        transform.Translate(speed * Time.deltaTime * 20, 0, 0);

        // スクリーンポイントを取得
        Vector3 screenPoint = RectTransformUtility.WorldToScreenPoint(canvas.worldCamera, rectTransform.position);

        // 画面外に出たかどうかをチェック
        if (screenPoint.x < 0 || screenPoint.x > Screen.width)
        {
            Debug.Log("Imageが画面外に出ました。");
            Destroy(gameObject); // 寿司を破棄
        }
    }
}
