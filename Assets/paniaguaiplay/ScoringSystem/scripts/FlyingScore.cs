using UnityEngine;
public class FlyingScore : MonoBehaviour
{
    private int score;
    private int scoreLength;
    private bool hasValue = false;
    [SerializeField]
    private string resourceFolderName;
    [SerializeField]
    private string digitPrefix;
    [SerializeField]
    [Range(0, 2)]
    private float speed;
    [SerializeField]
    [Range(0, 2)]
    private float alphaSpeed;
    private SpriteRenderer[] spritesRenderer;
    private void Update()
    {
        if (!hasValue) {
            Debug.LogError("Use SetScoreValue to set value");
            return;
        }
        if (spritesRenderer.Length<scoreLength){
            Debug.LogError("Not enought digit sprites.");
            return;
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        Color nc = spritesRenderer[0].color;
        nc.a = nc.a - alphaSpeed * Time.deltaTime;
        for(int i=0;i<scoreLength;i++){
            spritesRenderer[i].color = nc;
        }
        if (nc.a<=0) Destroy(gameObject);
    }
    public void SetScoreValue(int _score){
        hasValue=true;
        this.score = _score;
        scoreLength = score.ToString().Length;
        spritesRenderer = GetComponentsInChildren<SpriteRenderer>(); 
        if (spritesRenderer.Length<scoreLength){
            Debug.LogError("Not enought digit sprites.");
            return;
        }
        for (int i=0;i<scoreLength;i++){
            spritesRenderer[i].sprite = Resources.Load<Sprite>(
                resourceFolderName+"/" + digitPrefix + score.ToString().Substring(i, 1));
        }
        for (int i=scoreLength;i<spritesRenderer.Length;i++){
            spritesRenderer[i].gameObject.SetActive(false);
        }
    }
}
