using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Level: MonoBehaviour
{
    private GameObject selectedCharacter;
    protected GameObject pauseScreen;
    public static BoxCollider2D selectedCharacterCollider;
    protected GameObject enemyCharacter;
    public static bool isUnlocked;
    public static bool isFinished;
    public static Transform[] listOfPlatforms;
    protected void loadItems()
    {
        Instantiate(enemyCharacter, new Vector3(-2.3f, -3, 0), Quaternion.identity);
        selectedCharacter = CharacterContainer.unlockedCharacters.ElementAt(CharacterContainer.selectedCharacter);
        selectedCharacter = Instantiate(selectedCharacter, new Vector3(0, -3, 0), Quaternion.identity);
        selectedCharacter.AddComponent<PlayerControls>();
        selectedCharacter.AddComponent<Rigidbody2D>();
        selectedCharacterCollider = selectedCharacter.GetComponent<BoxCollider2D>();
        pauseScreen = GameObject.Find("PauseScreen");
        pauseScreen.SetActive(false);
    }
    void Start()
    {
        selectedCharacter = Resources.Load("Assets/Characters/Scientists/Scientist/Scientist") as GameObject;
        enemyCharacter = Resources.Load("Assets/Characters/Enemy") as GameObject;
        loadItems();
        getListOfPlatforms();
    }
    void getListOfPlatforms()
    {
        listOfPlatforms = new Transform[GameObject.Find("Platforms").transform.childCount];
        for (int i=0; i < GameObject.Find("Platforms").transform.childCount - 1; i++) {
            listOfPlatforms[i] = GameObject.Find("Platforms").transform.GetChild(GameObject.Find("Platforms").transform.childCount - 2 - i);
        }
    }
}
