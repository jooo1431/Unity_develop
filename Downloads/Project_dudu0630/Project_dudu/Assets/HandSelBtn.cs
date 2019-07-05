using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSelBtn : MonoBehaviour {

        UserData user;
    SoundManager soundManager;

    GameObject letter;

    public void LeftBtn()
    {
        user.LeftHandBtn();       
        transform.GetChild(0).gameObject.SetActive(false);
        if (PlayClick())
        {
            letter.SetActive(true);
            letter.GetComponent<Animator>().SetTrigger("start");
            gameObject.SetActive(false); // 손선택화면 안보이게함
        }

    }

    public void RightBtn()
    {
        user.RightHandBtn();       
        transform.GetChild(1).gameObject.SetActive(false); //오른손 버튼클릭하면 왼손버튼 사라짐
        if (PlayClick())
        {
            letter.SetActive(true);
            letter.GetComponent<Animator>().SetTrigger("start");
            gameObject.SetActive(false); // 손선택화면 안보이게함
        }
    }

    public bool PlayClick()
    {
        soundManager.PlaySingle(soundManager.ClickBtn);
        return true;
    }

    // Use this for initialization    
    //시작하면 userData 찾아서 연결해논다
    void Start ()
    {
        user = GameObject.Find("UserData").GetComponent<UserData>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        letter = GameObject.Find("letter").gameObject;
        letter.SetActive(false);
  
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
