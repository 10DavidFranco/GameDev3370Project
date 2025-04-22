using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public SpriteRenderer artworkSprite;
    private int selectedOption = 0;

    void Start()
    {
         if(!PlayerPrefs.HasKey("SelectedOption"))
        {
            selectedOption = 0;
        }
        else
        {
            Load();
        }
        UpdateCharacter(selectedOption);
    }
    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("SelectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("SelectedOption", selectedOption);
    }
}
