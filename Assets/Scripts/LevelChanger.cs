using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{

    public Animator animator;
    public Collider2D player;
    public Collider2D door1;
    public string door1destination;
    public Collider2D door2;
    public string door2destination;
    public Collider2D door3;
    public string door3destination;

    private string levelToLoad;

    [SerializeField]
    string input = "";

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            FadeToLevel("Room1-Front");
        }

        if (player != null && door1 != null && Physics2D.IsTouching(player, door1) && Input.GetKeyDown(KeyCode.W))
        {
            FadeToLevel(door1destination);
        }
        else if (player != null && door2 != null && Physics2D.IsTouching(player, door2) && Input.GetKeyDown(KeyCode.W))
        {
            FadeToLevel(door2destination);
        }
        else if (player != null && door3 != null && Physics2D.IsTouching(player, door3) && Input.GetKeyDown(KeyCode.W))
        {
            FadeToLevel(door3destination);
        }


        if (input.Length == 2)  
        {
            if (input != "79")
            {
                input = "";
            }
            else
            {
                SoundManagerScript.PlaySound("win");
                FadeToLevel("End");
            }
        }
    }

    public void FadeToLevel (string Name)
    {
        levelToLoad = Name;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void AddDigit(string digit)
    {
        input += digit;
    }
}
