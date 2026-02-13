using UnityEngine;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public TextMeshProUGUI userText;
    public TextMeshProUGUI ballText;

    public GameObject userBubble;
    public GameObject ballBubble;

    public float lineDuration = 3f;
    public bool Texting {get; private set;}

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayFromJson(string fileName, string id)
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Dialogues/" + fileName);

        if (jsonFile == null)
        {
            Debug.LogError("Json 파일 없음");
            return;
        }

        DialogueCollection collection = JsonUtility.FromJson<DialogueCollection>(jsonFile.text);
        foreach (var entry in collection.dialogues)
        {
            if (entry.id == id)
            {
                StartCoroutine(PlayRoutine(entry.lines));
            }
        }        
    }

    IEnumerator PlayRoutine(DialogueLine[] lines)
    {
        Texting = true;

        foreach(var line in lines)
        {
            if (line.speaker == "주인공")
            {
                userBubble.SetActive(true);
                userText.text = line.text;
            }
            else if (line.speaker == "공")
            {
                ballBubble.SetActive(true);
                ballText.text = line.text;   
            }
            yield return new WaitForSeconds(lineDuration);
        }

        userBubble.SetActive(false);
        ballBubble.SetActive(false);

        Texting = false;
    }
}
