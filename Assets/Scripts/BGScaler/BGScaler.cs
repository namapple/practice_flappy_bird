using UnityEngine;

public class BGScaler : MonoBehaviour
{
    
    private void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        //Current scale of background
        Vector3 tempScale = transform.localScale;
        //Get the bound of background
        float height = sr.bounds.size.y;
        float width = sr.bounds.size.x;

        //Get the size of camera
        float worldHeight = Camera.main.orthographicSize * 2f;
        float worldWidth = worldHeight * Screen.width / Screen.height;

        tempScale.y = worldHeight / height;
        tempScale.x = worldWidth / width;

        transform.localScale = tempScale;
    }
}