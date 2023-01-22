using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class CharacterInfo : MonoBehaviour
{
    private int charNum = 0;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(()=>SceneManager.LoadScene(CharacterContainer.unlockedCharacters.ElementAt(0).gameObject.name + "Info"));
    }

    // Update is called once per frame
    void Update()
    {
        if(charNum != CharacterContainer.selectedCharacter)
        {
            charNum = CharacterContainer.selectedCharacter;
            GetComponent<Button>().onClick.RemoveAllListeners();
            GetComponent<Button>().onClick.AddListener(()=>SceneManager.LoadScene(CharacterContainer.unlockedCharacters.ElementAt(charNum).gameObject.name + "Info"));
            Debug.Log(CharacterContainer.unlockedCharacters.ElementAt(CharacterContainer.selectedCharacter).gameObject.name + "Info");
        }
    }
}
