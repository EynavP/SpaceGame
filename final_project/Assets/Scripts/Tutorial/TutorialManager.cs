using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public List<Tutorial> Tutorials = new List<Tutorial>();

    public Text expText;

    public Button startGame;
    private int currentScene;

    private static TutorialManager instance;
    public static TutorialManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<TutorialManager>();

            if (instance == null)
                Debug.Log("There is no TutorialManager");

            return instance;
        }
    }

    private Tutorial currentTutorial;
    // Start is called before the first frame update
    void Start()
    {
        SetNextTutorial(0);
        startGame.interactable = false;
        currentScene = (SceneManager.GetActiveScene().buildIndex);

    }

    // Update is called once per frame
    void Update()
    {
        if (currentTutorial)
            currentTutorial.CheckIfHappening();
    }

    public void CompletedTutorial()
    {
        SetNextTutorial(currentTutorial.Order + 1);
    }

    public void SetNextTutorial(int currentOrder)
    {
        currentTutorial = getTutorialByOrder(currentOrder);

        if (!currentTutorial)
        {
            CompletedAllTutorials();
            return;
        }

        expText.text = currentTutorial.Explanation;
    }

    public void CompletedAllTutorials()
    {
        expText.text = "You have competed all the tutorials, now to the game";

        startGame.interactable = true;
    }

    public Tutorial getTutorialByOrder(int Order)
    {
        for(int i = 0; i < Tutorials.Count; i++)
        {
            if (Tutorials[i].Order == Order)
                return Tutorials[i];
        }

        return null;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(currentScene+1);
    }
}
