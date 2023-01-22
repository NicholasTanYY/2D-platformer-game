using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LoadLevels : MonoBehaviour
{
    public GameObject levelHolder;
    public GameObject levelButton;
    private int levelQty = 10;
    private int levelUnlocked;
    public Sprite scienceLab, futuristicCity, constructionSite, underWater, demonLair;

    private void Start(){
        for(int i=1; i<=levelQty; i++){
            loadButtons(i);
        }
    }
    private void loadButtons(int i){
        levelUnlocked = HighestLevelData.getHighestLevel();
        GameObject newButton = Instantiate(levelButton, levelHolder.transform) as GameObject;
        if(i <= levelUnlocked){
            newButton.name = "Level-" + i;
            newButton.GetComponentInChildren<TextMeshProUGUI>().SetText("Level-" + i);
            newButton.GetComponent<Button>().interactable = true;
            Debug.Log("Level-" + i + "-Unlocked");
            newButton.GetComponent<Button>().onClick.AddListener(()=>SceneManager.LoadScene("Level" + i));
        }else{
            newButton.name = "Level-" + i + "-Locked";
            newButton.GetComponentInChildren<TextMeshProUGUI>().SetText("Locked\n\n" + "Level-" + i);
            newButton.GetComponent<Button>().interactable = false;
            Debug.Log("Level-" + i + "-Locked");
        }
        loadImage(i, newButton);
    }
    private void loadImage(int i, GameObject newButton){
        int interval = Mathf.FloorToInt(levelQty / 5);
        if(1<=i && i<=interval){
            newButton.GetComponent<Image>().sprite = demonLair;
        }
        if(interval+1<=i && i<=(interval*2)){
            newButton.GetComponent<Image>().sprite = underWater;
        }
        if(((interval*2)+1)<=i && i<=(interval*3)){
            newButton.GetComponent<Image>().sprite = scienceLab;
        }
        if(((interval*3)+1)<=i && i<=(interval*5)){
            newButton.GetComponent<Image>().sprite = constructionSite;
        }
        if(((interval*4)+1)<=i && i<=levelQty){
            newButton.GetComponent<Image>().sprite = futuristicCity;
        }
    }
}