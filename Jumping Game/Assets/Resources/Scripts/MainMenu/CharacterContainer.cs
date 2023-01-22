using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterContainer : MonoBehaviour
{
    public static RectTransform characterContainer;
    private float scrollValue;

    public static int selectedCharacter = 0;
    [SerializeField]
    private GameObject character1;
    [SerializeField]
    private GameObject character2;
    [SerializeField]
    private GameObject character3;
    [SerializeField]
    private GameObject character4;
    [SerializeField]
    private GameObject character5;
    [SerializeField]
    private GameObject characterPanel;
    [SerializeField]
    private GameObject characterInfoButton;

    public static List<GameObject> unlockedCharacters;
    private GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        characterContainer = GetComponent<RectTransform>();
        listOfCharacters();
        characterContainer.sizeDelta = new Vector2(800 * unlockedCharacters.Count, characterContainer.sizeDelta.y);
    }

    void Update()
    {
        characterSelect();
    }

    public void listOfCharacters()
    {
        unlockedCharacters = new List<GameObject>();
        for (int i = 1; i <= 5; i++)
        {
            switch (i)
            {
                case 1:
                    if (Character1.getUnlocked())
                    {
                        unlockedCharacters.Add(character1);
                    }
                    break;
                case 2:
                    if (Character2.getUnlocked())
                    {
                        unlockedCharacters.Add(character2);
                    }
                    break;
                case 3:
                    if (Character3.getUnlocked())
                    {
                        unlockedCharacters.Add(character3);
                    }
                    break;
                case 4:
                    if (Character4.getUnlocked())
                    {
                        unlockedCharacters.Add(character4);
                    }
                    break;
                case 5:
                    if (Character5.getUnlocked())
                    {
                        unlockedCharacters.Add(character5);
                    }
                    break;
            }
        }
        foreach (var unlockedCharacter in unlockedCharacters)
        {
            character = Instantiate(unlockedCharacter, transform.position, Quaternion.identity);
            character.transform.SetParent(characterContainer);
        }
    }

    void characterSelect()
    {
        if (Input.GetMouseButton(0))
        {
            scrollValue = characterContainer.position.x;
        }
        else
        {
            for (int i = 1; i <= 2*unlockedCharacters.Count; i+=2)
            {
                if (scrollValue < -2.31*i && scrollValue > -2.31*(i+1))
                {
                    characterContainer.position = new Vector3(Mathf.Lerp(characterContainer.position.x, (float)(-2.31*i), 0.1f), characterContainer.position.y, characterContainer.position.z);
                }
                else if (scrollValue < -2.31*(i+1) && scrollValue > -2.31*(i+2))
                {
                    characterContainer.position = new Vector3(Mathf.Lerp(characterContainer.position.x, (float)(-2.31*(i+2)), 0.1f), characterContainer.position.y, characterContainer.position.z);
                }
            }
            selectedCharacter = (int)((characterContainer.position.x/(-2.31))/2);
        }
    }
}
