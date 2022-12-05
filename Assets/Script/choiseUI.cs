using System;
using System.Linq;
using Script.Data;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Script.UI {
    public class choiseUI : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _descriptionInputField;
        public void Load(Choice choice) {
            _descriptionInputField.text = choice.Description;
            Thumbnail firstOrDefault = storyUI.CurrentStory.Thumbnails.FirstOrDefault(thumbnail => thumbnail.Guid == choice.ThumbnailGuid);
            if (firstOrDefault == null) throw new Exception("Cannot find any thumbnail with guid " + choice.ThumbnailGuid);
        }
    }
}
