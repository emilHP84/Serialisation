using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FullSerializer;
using System.Runtime.Serialization;
using Script.Data;
using UnityEngine;


namespace Script.Managers {
   public class DataManager : MonoBehaviour {
      private static readonly fsSerializer Serializer = new fsSerializer();
      private static readonly string StoryPath = Application.streamingAssetsPath;
      public static List<string> StoryFiles => Directory.GetFiles(StoryPath, "*.sty").Select(Path.GetFileName).ToList();

      public static Story StoryLoad(string storyNameWithExtension) {
         string path = StoryPath + Path.DirectorySeparatorChar + storyNameWithExtension;
         if (File.Exists(path)) File.OpenRead(path);
         else Debug.LogError("document introuvable...");
         string fileJson = File.ReadAllText(path);
         return Deserialize(typeof(Story), fileJson) as Story;
      }
      
      public static bool CheckStory(string storyNameWithExtension) {
         string path = StoryPath + Path.DirectorySeparatorChar + storyNameWithExtension;
         return File.Exists(path);
      }

      private static object Deserialize(Type type, string serializedState) {
         fsData data = fsJsonParser.Parse(serializedState);

         object deserialized = null;
         Serializer.TryDeserialize(data, type, ref deserialized).AssertSuccessWithoutWarnings();
         return deserialized;
      }
   }
}