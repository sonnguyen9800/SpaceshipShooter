using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;
[RequireComponent(typeof(PlayableDirector))]
public class StoryTeller : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textDisplay;
    private PlayableDirector timeline;

    [SerializeField] private GameObject textPrompt;
    [SerializeField]
    private string[] sentences;
    private int index;
    [SerializeField]
    private float typingSpeed;

    private bool finishedSentence = false;

    private void Awake()
    {
        timeline = GetComponent<PlayableDirector>();

        textPrompt.SetActive(false);
        finishedSentence = false;
    }

    private void Start()
    {
        StartCoroutine(Type());
    }

    private IEnumerator Type()
    {
        textPrompt.SetActive(false);
        int length = sentences[index].ToCharArray().Length;
        int counter = 0;
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            counter += 1;
            if (counter == length)
            {
                finishedSentence = true;
                textPrompt.SetActive(true);
            }
            yield return new WaitForSeconds(typingSpeed);

        }
    }

    // Start is called before the first frame update
    public void NextSentences()
    {
        if (index < sentences.Length - 1)
        {
            textDisplay.text = "";
            index++;
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            textPrompt.SetActive(false);
            if (timeline != null) timeline.Play();
            // SceneManager.LoadScene(SceneEnum.OpeningScene.ToString());
        }
    }
    private void Update()
    {
        if (finishedSentence == false) { return; }
        if (Input.anyKey)
        {
            finishedSentence = false;
            NextSentences();
        }
    }
}
