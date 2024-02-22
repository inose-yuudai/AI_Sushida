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

    private float timeRemaining; // 残り時間
    public bool isSushiActive = false; // 寿司が有効かどうか

    public Image sushiImage; // 寿司の画像を表示するためのImageコンポーネント
    public Sprite[] sushiSprites; // 寿司の画像の配列

    public Text japaneseText; // 日本語名を表示するためのText
    public Text romajiText; // ローマ字名を表示するためのText

    public GameObject imagePrefab; // 寿司イメージのプレファブ
    public Transform spawnPosition; // 寿司が出現する位置

    public ScoreManager scoreManager;

    private GameObject currentSushiGameObject; // 現在の寿司GameObject

    void Start()
    {
        SpawnSushi();
    }
void Update()
{
    if(TimeManager.GameTimeLimit>0){

    if (isSushiActive && currentSushiGameObject != null)
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(keyCode))
                {
                    string keyPressed = keyCode.ToString().ToLower();
                    string currentFirstChar = currentInput.Length > 0 ? currentInput.Substring(0, 1).ToLower() : "";

                    if (keyPressed == currentFirstChar)
                    {
                        // 最初の文字が正しく入力された場合、その文字を削除
                        currentInput = currentInput.Remove(0, 1);

                        // ローマ字テキストを更新
                        romajiText.text = currentInput;

                        // 全ての文字が消えた場合、新しい寿司をスポーン
                        if (string.IsNullOrEmpty(currentInput))
                        {
                           scoreManager.AddScore();
                            DestroySushi();
                            SpawnSushi();
                        }
                        break; // 一致するキーが見つかったらループを抜ける
                    }
                }
            }
        }
    }
    }
}


    public void SpawnSushi()
    {
        if (currentSushiGameObject != null) // 以前の寿司があれば破棄
        {
            Destroy(currentSushiGameObject);
        }

        Sushi selectedSushi = sushis[Random.Range(0, sushis.Length)];
        currentInput = selectedSushi.romanizedName;
        isSushiActive = true;

        // ImagePrefabから新しい寿司イメージをインスタンス化
        currentSushiGameObject = Instantiate(imagePrefab, spawnPosition.position, Quaternion.identity, spawnPosition);
        Image sushiImageComponent = currentSushiGameObject.GetComponent<Image>();

        Sprite selectedSprite = sushiSprites[Random.Range(0, sushiSprites.Length)];
        sushiImageComponent.sprite = selectedSprite;

        japaneseText.text = selectedSushi.japaneseName;
        romajiText.text = selectedSushi.romanizedName;

      
    }
    public  void DestroySushi()
    {
        if (currentSushiGameObject != null)
        {
            Destroy(currentSushiGameObject);
            currentSushiGameObject = null;
        }
        isSushiActive = false;
    }
}
