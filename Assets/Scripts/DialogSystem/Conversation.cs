using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;
 using UnityEngine.UI;

public class Conversation : MonoBehaviour
{   
    [SerializeField] private PlayableDirector timeline;

    [System.Serializable]
    public class Talk{

        [SerializeField]
        public string text;

        [SerializeField]
        public string Speaker;

        [SerializeField]
        public Sprite image;

    }

    [SerializeField] float delay = 0.1f;

    [SerializeField]
    private Talk[] talks; // Talks list
    private int currentTalk = 0;

    [SerializeField] private TextMeshProUGUI textfield;
    [SerializeField] private Image imageDisplayer;

    [SerializeField] private TextMeshProUGUI speaker;

    [SerializeField] public GameObject textPrompt;
    bool finishedSentence = false;



    // Timeline Object


    private void Start() {
        StartCoroutine(Talking());
    }



    public IEnumerator Talking(){
        textPrompt.SetActive(false);

        if (timeline != null) timeline.Pause();

        if (speaker.text != null) speaker.text = talks[currentTalk].Speaker; // Set new Speaker name

        if (talks[currentTalk].image != null) {
            imageDisplayer.sprite = talks[currentTalk].image; // Set new image
            } else {
                imageDisplayer.sprite = null;
        }
        //textfield.text = talks[currentTalk].text;

        string sentence = talks[currentTalk].text;
        int length = sentence.ToCharArray().Length;
        int counter = 0;

    
        foreach(char letter in sentence){
           // Debug.Log(letter);
            textfield.text += letter;
            counter += 1;

            if (counter == length){
                this.finishedSentence = true;
                this.textPrompt.SetActive(true);
            }
            yield return new WaitForSeconds(delay);

        }

       // yield return new WaitForSeconds(delay);
        
    }

    public void NextSentences(){
        if (currentTalk < talks.Length - 1){
            this.textfield.text = "";
            currentTalk ++;
            StartCoroutine(Talking());
        } else {
            this.textPrompt.SetActive(false);

            if (timeline != null) {
                timeline.Resume();
            }
            Destroy(gameObject);

            // SceneManager.LoadScene(SceneEnum.OpeningScene.ToString());
        }
    }
    void Update()
    {
        if (this.finishedSentence == false ){return;}

        if (Input.anyKey){
            this.finishedSentence = false;
            NextSentences();
        }

        
    }
    

}
