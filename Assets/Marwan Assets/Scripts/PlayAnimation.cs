using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{

    public Animator anim;
    bool isplay = true;
    public GameObject showInforamtionObject;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Play_animator()
    {
        Debug.Log("play animation for motor");
        if (isplay)
        {
            print("conditation if");
            anim.enabled = true;
            anim.Play("MK2_Animated_disassembly_open");
            anim.SetTrigger("x");
            StartCoroutine(ShowInformation());
        }
        else
        {
            anim.Play("TESTANIM");
            anim.enabled = true;
        }

        isplay = !isplay;
    }

    IEnumerator ShowInformation()
    {
        yield return new WaitForSeconds(7f);
        showInforamtionObject.SetActive(true);
    }

}
