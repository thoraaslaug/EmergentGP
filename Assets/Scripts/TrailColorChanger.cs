using UnityEngine;

public class TrailColorChanger : MonoBehaviour
{
    public TrailRenderer trailRenderer;
    public Color newColor = Color.red;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Box"))
        { 
            trailRenderer.startColor = newColor;
            trailRenderer.endColor = newColor;
        }
    }
}