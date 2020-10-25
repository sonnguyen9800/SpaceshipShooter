using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;
[RequireComponent(typeof(PlayableDirector))]
public class StoryTeller : MonoBehaviour
{   
    public TextMeshProUGUI textDisplay;
    private PlayableDirector timeline;

    [SerializeField] public GameObject textPrompt;

    public string[] sentences;
    private int index;
    public float typingSpeed;

    bool finishedSentence = false;

    private void Awake() {
        timeline = GetComponent<PlayableDirector>();

        textPrompt.SetActive(false);
        this.finishedSentence = false;
    }

    private void Start() {
        StartCoroutine(Type());
    }

    IEnumerator Type(){
        textPrompt.SetActive(false);
        int length = sentences[index].ToCharArray().Length;
        int counter = 0;
        foreach(char letter in sentences[index].ToCharArray()){
            textDisplay.text += letter;
            counter += 1;
            if (counter == length) {
                this.finishedSentence = true;
                this.textPrompt.SetActive(true);
            }
            yield return new WaitForSeconds(typingSpeed);
            
        }
    }

    // Start is called before the first frame update
    public void NextSentences(){
        if (index < sentences.Length - 1){
            this.textDisplay.text = "";
            index ++;
            StartCoroutine(Type());
        } else {
            this.textDisplay.text = "";
            this.textPrompt.SetActive(false);
            if (this.timeline != null) timeline.Play();
            // SceneManager.LoadScene(SceneEnum.OpeningScene.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.finishedSentence == false ){return;}

        if (Input.anyKey){
            this.finishedSentence = false;
            NextSentences();
        }

        
    }
}
