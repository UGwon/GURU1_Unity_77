using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Character // 캐릭터 정의
{
    Swuri, Wendy, Usi
}
public class DataMgr : MonoBehaviour
{
    // 싱글톤 패턴
    public static DataMgr instance; 
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != null) return;
        DontDestroyOnLoad(gameObject);
    }

    public Character currentCharacter; // select 씬에서 캐릭터 선택 시 다른 씬에서도 그 캐릭터 사용 
}
