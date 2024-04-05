using UnityEngine;

public class Parallax: MonoBehaviour
{
    public float parallaxSpeed;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float offsetX = Time.time * parallaxSpeed;
        Vector2 offset = new Vector2(offsetX, 0);
        spriteRenderer.material.mainTextureOffset = offset;
    }
}
