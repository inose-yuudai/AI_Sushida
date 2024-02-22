using UnityEngine;

public class SushiMover : MonoBehaviour
{
    public float speed = 5.0f; // 寿司の移動速度
    private RectTransform rectTransform; // ImageのRectTransform
    private Canvas canvas; // 親のCanvas

 void Start()
{
    // 2階層上のCanvasを取得
    canvas = GetComponentInParent<Canvas>(); // まず直近のCanvasを取得
    if (canvas == null || !canvas.gameObject.name.Equals("Canvas")) // 目的のCanvasでなければさらに上を探す
    {
        Transform parentCanvasTransform = transform.parent.parent; // 2階層上を参照
        canvas = parentCanvasTransform.GetComponent<Canvas>(); // 2階層上のCanvasを取得
    }

    rectTransform = GetComponent<RectTransform>(); // ImageのRectTransformを取得
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
            // 画面外に出たら、GameManagerのDestroySushiとSpawnSushiメソッドを呼び出す
            GameObject.Find("GameManager").SendMessage("DestroySushi");
            GameObject.Find("GameManager").SendMessage("SpawnSushi");
        }
    }
}
