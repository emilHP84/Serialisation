using System;
using System.Collections.Generic;
using System.Linq;
using Script.Data;
using Script.Managers;
using Script.UI;
using Script.Utils;
using TMPro;
using UnityEngine;

public class thumbnailUI : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI TitleInputField;
    [SerializeField] private TextMeshProUGUI DescriptionInputField;
    [SerializeField] private Transform ChoiceContent;
    [SerializeField] private GameObject ChoicePrefab;
    
    private string _guid = Guid.NewGuid().ToString();
    private List<choiseUI> ChoiceUIs => ChoiceContent.GetComponentsInChildren<choiseUI>().ToList();
    private Story CurrentStory => storyUI.CurrentStory;
    
    public void Reset() {
        _guid = Guid.NewGuid().ToString();
        TitleInputField.text = string.Empty;
        DescriptionInputField.text = string.Empty;
        ChoiceUIs.ForEach(component => Destroy(component.gameObject));
    }
    public void Load(int index) {
        Reset();
        Thumbnail thumbnail = CurrentStory.Thumbnails[index];
        _guid = thumbnail.Guid;
        TitleInputField.text = thumbnail.Title;
        DescriptionInputField.text = thumbnail.Description;
        foreach (Choice choice in thumbnail.Choices) {
            GameObject instantiate = Instantiate(ChoicePrefab, ChoiceContent);
            choiseUI choiceUI = instantiate.GetComponent<choiseUI>();
            choiceUI.Load(choice, this);
        }
    }
}
