using Script.Managers;
using Script.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class storyBrowserUI : MonoBehaviour
{
    public GameObject ButtonPrefab;
    public GameObject ScrollContent;

    private void OnEnable() {
        foreach (string fileName in DataManager.StoryFiles) {
            Button storyFileButton = Instantiate(ButtonPrefab, ScrollContent.transform).GetComponent<Button>();
            string localName = fileName;
            storyFileButton.onClick.AddListener(delegate {
                PlayerPrefs.SetString(properties.Prefs.LoadedStory, localName);
                Scene scene = SceneManager.GetActiveScene();
            });
            storyFileButton.GetComponentInChildren<TextMeshProUGUI>().text = fileName;
        }
    }

    private void OnDisable() {
        foreach (Transform child in ScrollContent.transform) { 
            Destroy(child.gameObject);
        }
    }
}

