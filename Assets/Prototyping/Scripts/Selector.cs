using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Selector : MonoBehaviour
{
    public GameObject Chase;
    public GameObject Ember;
    public GameObject Lea;
    public GameObject Leo;
    public GameObject Bree;
    public GameObject Neo;

    private Vector3 CharacterPosition;
    private Vector3 CharacterOffScreen;
    private int CharacterInt = 1;
    private SpriteRenderer ChaseRenderer, EmberRenderer, LeaRenderer, LeoRenderer, BreeRenderer;

    private readonly string selectedCharacter = "SelectedCharacter";

    public string levelToLoad;

    private void Awake()
    {
        CharacterPosition = Ember.transform.position;
        CharacterOffScreen = Lea.transform.position;
        ChaseRenderer = Chase.GetComponent<SpriteRenderer>();
        EmberRenderer = Ember.GetComponent<SpriteRenderer>();
        LeaRenderer = Lea.GetComponent<SpriteRenderer>();
        LeoRenderer = Leo.GetComponent<SpriteRenderer>();
        BreeRenderer = Bree.GetComponent<SpriteRenderer>();


    }

    public void NextCharacter()
    {
        switch(CharacterInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectedCharacter, 1);
                EmberRenderer.enabled = false;
                Ember.transform.position = CharacterOffScreen;
                Chase.transform.position = CharacterPosition;
                ChaseRenderer.enabled = true;
                CharacterInt++;
                break;
            case 2:
                PlayerPrefs.SetInt(selectedCharacter, 2);
                ChaseRenderer.enabled = false;
                Chase.transform.position = CharacterOffScreen;
                Lea.transform.position = CharacterPosition;
                LeaRenderer.enabled = true;
                CharacterInt++;
                break;
            case 3:
                PlayerPrefs.SetInt(selectedCharacter, 3);
                LeaRenderer.enabled = false;
                Lea.transform.position = CharacterOffScreen;
                Leo.transform.position = CharacterPosition;
                LeoRenderer.enabled = true;
                CharacterInt++;
                break;
            case 4:
                PlayerPrefs.SetInt(selectedCharacter, 4);
                LeoRenderer.enabled = false;
                Leo.transform.position = CharacterOffScreen;
                Bree.transform.position = CharacterPosition;
                BreeRenderer.enabled = true;
                CharacterInt++;
                break;
            case 5:
                PlayerPrefs.SetInt(selectedCharacter, 5);
                BreeRenderer.enabled = false;
                Bree.transform.position = CharacterOffScreen;
                Ember.transform.position = CharacterPosition;
                EmberRenderer.enabled = true;
                CharacterInt++;
                ResetInt();
                break;
            default:
                ResetInt();
                break;
        }
    }

    public void PreviousCharacter()
    {
        switch (CharacterInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectedCharacter, 4);
                EmberRenderer.enabled = false;
                Ember.transform.position = CharacterOffScreen;
                Bree.transform.position = CharacterPosition;
                BreeRenderer.enabled = true;
                CharacterInt--;
                ResetInt();
                break;
            case 2:
                PlayerPrefs.SetInt(selectedCharacter, 5);
                ChaseRenderer.enabled = false;
                Chase.transform.position = CharacterOffScreen;
                Ember.transform.position = CharacterPosition;
                EmberRenderer.enabled = true;
                CharacterInt--;
                break;
            case 3:
                PlayerPrefs.SetInt(selectedCharacter, 1);
                LeaRenderer.enabled = false;
                Lea.transform.position = CharacterOffScreen;
                Chase.transform.position = CharacterPosition;
                ChaseRenderer.enabled = true;
                CharacterInt--;
                break;
            case 4:
                PlayerPrefs.SetInt(selectedCharacter, 2);
                LeoRenderer.enabled = false;
                Leo.transform.position = CharacterOffScreen;
                Lea.transform.position = CharacterPosition;
                LeaRenderer.enabled = true;
                CharacterInt--;
                break;
            case 5:
                PlayerPrefs.SetInt(selectedCharacter, 3);
                BreeRenderer.enabled = false;
                Bree.transform.position = CharacterOffScreen;
                Leo.transform.position = CharacterPosition;
                LeoRenderer.enabled = true;
                CharacterInt--;
                break;
            default:
                ResetInt();
                break;
        }
    }

    private void ResetInt()
    {
        if(CharacterInt >= 5)
        {
            CharacterInt = 1;
        }
        else
        {
            CharacterInt = 5;
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void back(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
