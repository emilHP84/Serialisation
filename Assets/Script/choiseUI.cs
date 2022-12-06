using System;
using System.Linq;
using Script.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Script.UI {
    public class choiseUI : MonoBehaviour {
        
        [SerializeField] private TextMeshProUGUI _descriptionInputField;
        [SerializeField] private Button _thumbnailLinkButton;

        public void Load(Choice choice, thumbnailUI thumbnailUI) {
            _descriptionInputField.text = choice.Description;
            Thumbnail firstOrDefault = storyUI.CurrentStory.Thumbnails.FirstOrDefault(thumbnail => thumbnail.Guid == choice.ThumbnailGuid);
            if (firstOrDefault == null) Debug.Log("put");
            _thumbnailLinkButton.onClick.AddListener(delegate {
                int index = storyUI.CurrentStory.Thumbnails.IndexOf(firstOrDefault);
                thumbnailUI.Load(index);
            });
            //throw new Exception("Cannot find any thumbnail with guid " + choice.ThumbnailGuid);
        }
        
    }
}
