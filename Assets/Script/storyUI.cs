using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script.Data;
using Script.Managers;
using Script.Utils;

public class storyUI : MonoBehaviour {
   [SerializeField] private thumbnailUI _thumbnailUI;
   public static Story CurrentStory;
   
   public void Update() {
      if (PlayerPrefs.HasKey(properties.Prefs.LoadedStory) && Check(PlayerPrefs.GetString(properties.Prefs.LoadedStory))) {
         Load(PlayerPrefs.GetString(properties.Prefs.LoadedStory));
         PlayerPrefs.DeleteKey(properties.Prefs.LoadedStory);
      }
   }
   
   private void Load(string storyName) {
      CurrentStory = DataManager.StoryLoad(storyName);
      _thumbnailUI.Load(0);
   }
   
   private bool Check(string storyName) {
      return DataManager.CheckStory(storyName);
   }
}
