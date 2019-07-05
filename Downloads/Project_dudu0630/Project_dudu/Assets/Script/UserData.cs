using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap;
using Leap.Unity;

public class UserData : MonoBehaviour {

    // 사용자가 오른손잡이인지 왼손잡이인지 구분해줄거임
    public Leap.Hand MainHand; //선택, 잡기
    public Leap.Hand SubHand; // 이동

    bool rightHanded = true; //디폴트로 오른손잡이로 
    bool leftHanded = false;

    public void LeftHandBtn()
    {        
        leftHanded = true;
        rightHanded = false;
    }

    public void RightHandBtn() //버튼 onclick에 연결
    {
        rightHanded = true;
        leftHanded = false;
    }

   
    // Use this for initialization
    void Awake () //씬이동시 죽이면 안됨
    {
        DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (leftHanded) //사용자가 왼손잡이면 
        {
            MainHand = Hands.Left;
            SubHand = Hands.Right;
        }


        if (rightHanded) //사용자가 오른손잡이면 
        {
            MainHand = Hands.Right;
            SubHand = Hands.Left;
        }
            
    }
}
