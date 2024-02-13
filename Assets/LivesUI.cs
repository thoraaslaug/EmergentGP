using TMPro;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    public CharacterController2D character; // Reference to the character whose lives are displayed
    private TMP_Text livesText;

    void Start()
    {
        livesText = GetComponent<TMP_Text>();
        UpdateLivesText();
    }

    void Update()
    {
        UpdateLivesText();
    }

    void UpdateLivesText()
    {
        livesText.text = "Lives: " + character.lives.ToString();
    }
}