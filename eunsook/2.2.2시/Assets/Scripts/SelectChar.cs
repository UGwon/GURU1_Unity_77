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
        anim = GetComponent<Animator>(); // getcomponent�� Ȱ���� animaotr,spriterenderer�� ����
        sr = GetComponent<SpriteRenderer>();
        if (DataMgr.instance.currentCharacter == character) OnSelect();
        else OnDeSelect();
    }
    private void OnMouseUpAsButton() // ���콺�� �����ٰ� ���� �� ȣ��Ǵ� �Լ�(gui or collider���� ����)
    {
        DataMgr.instance.currentCharacter = character;
        OnSelect();
        for(int i=0; i<chars.Length; i++)
        {
            if (chars[i] != this) chars[i].OnDeSelect(); // ���� ������ ĳ���� �ƴϸ� false ó��
        }
    }

    void OnDeSelect()
    {
        sr.color = new Color(0.5f, 0.5f, 0.5f); // ��Ӱ� �����
    }

    void OnSelect()
    {
        sr.color = new Color(1f, 1f, 1f); // ��� �����
    }
}
