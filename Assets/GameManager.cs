using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Sushi
{
    public string japaneseName; // 寿司の日本語名
    public string romanizedName; // 寿司のローマ字名
}

public class GameManager : MonoBehaviour
{
    public Sushi[] sushis; // 寿司の配列
    private string currentInput; // 現在の寿司のローマ字名
    public float timeLimit = 10f; // 制限時間
    private float timeRemaining; // 残り時間
    public bool isSushiActive = false; // 寿司が有効かどうか

    public Image sushiImage; // 寿司の画像を表示するためのImageコンポーネント
    public Sprite[] sushiSprites; // 寿司の画像の配列

    public Text japaneseText; // 日本語名を表示するためのText
    public Text romajiText; // ローマ字名を表示するためのText

    private GameObject currentSushiGameObject; // 現在の寿司GameObject

    void Start()
    {
        SpawnSushi();
    }

    void Update()
    {
        if (isSushiActive && currentSushiGameObject == null)
        {
            // 寿司が破棄されたら、新しい寿司をスポーンする

            Debug.Log(1);
        }
    }

    public void SpawnSushi()
    {
        Sushi selectedSushi = sushis[Random.Range(0, sushis.Length)];
        currentInput = selectedSushi.romanizedName;
        timeRemaining = timeLimit;
        isSushiActive = true;

        Sprite selectedSprite = sushiSprites[Random.Range(0, sushiSprites.Length)];
        sushiImage.sprite = selectedSprite; // Imageコンポーネントのスプライトを更新

        japaneseText.text = selectedSushi.japaneseName; // 日本語名をテキストに設定
        romajiText.text = selectedSushi.romanizedName; // ローマ字名をテキストに設定


    }

    public void DestroySushi()
    {
        if (currentSushiGameObject != null)
        {
            Destroy(currentSushiGameObject); // 寿司GameObjectを破棄
            currentSushiGameObject = null; // 参照をクリア
        }
        isSushiActive = false;
    }
}
