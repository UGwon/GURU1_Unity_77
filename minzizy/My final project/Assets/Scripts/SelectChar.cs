using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectChar : MonoBehaviour
{
    public Character character;
    Animator anim;
    SpriteRenderer sr;
    public SelectChar[] chars;

    void Start()
    {
        anim = GetComponent<Animator>(); // getcomponent를 활용해 animaotr,spriterenderer에 연결
        sr = GetComponent<SpriteRenderer>();
        if (DataMgr.instance.currentCharacter == character) OnSelect();
        else OnDeSelect();
    }
    private void OnMouseUpAsButton() // 마우스를 눌렀다가 뗐을 때 호출되는 함수(gui or collider에서 반응)
    {
        DataMgr.instance.currentCharacter = character;
        OnSelect();
        for(int i=0; i<chars.Length; i++)
        {
            if (chars[i] != this) chars[i].OnDeSelect(); // 내가 선택한 캐릭터 아니면 false 처리
        }
    }

    void OnDeSelect()
    {
        sr.color = new Color(0.5f, 0.5f, 0.5f); // 어둡게 만들기
    }

    void OnSelect()
    {
        sr.color = new Color(1f, 1f, 1f); // 밝게 만들기
    }
}
