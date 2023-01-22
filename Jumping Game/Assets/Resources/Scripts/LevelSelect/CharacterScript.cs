using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterScript : MonoBehaviour
{
    private GameObject selectedCharacter;
    // Start is called before the first frame update
    void Start()
    {
        selectedCharacter = CharacterContainer.unlockedCharacters.ElementAt(CharacterContainer.selectedCharacter);
        selectedCharacter = Instantiate(selectedCharacter, new Vector3(-1.35f, -2.45f, 0), Quaternion.identity);
        selectedCharacter.AddComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
