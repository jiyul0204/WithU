using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    CardGame_cardtouch,
    main_bgm,   // 메인 화면, 카드 컬렉션 기본 BGM
    main_button_touch,  // 시작, 컬렉션 버튼, 설정, 부모님 계정 확인 버튼 터치 시 출력되는 효과음
    collection_card_touch,  // 획득한 카드 터치 시 출력 사운드
    collection_check_box,   // 게임 종류별 수집한 카드를 확인하는 체크 박스 터치 시 출력되는 효과음
    store_bgm,  // 장난감 가게의 메인 BGM
    store_door_touch,   // 가게 문 버튼 터치 시 출력되는 효과음
    store_enter_guest,  // 손님 진입 시 출력되는 효과음
    multiplication_new_question,    // 게임 시작 후 새로운 문제 생성 시 출력되는 효과음
    multiplication_parts_selection, // 부품 선택 시 출력 효과음
    multiplication_correct, // 정답을 맞춘 경우 출력되는 효과음
    multiplication_incorrect,   // 정답을 맞추지 못한 경우 출력되는 효과음
    multiplication_doll_complete,   // 모든 문제를 풀고 인형 완성 시 출력 효과음
    multiplication_get_doll,    // 난이도가 상승해 인형 획득 시 출력되는 효과음
    division_bgm,   // 인공위성 게임 메인 BGM
    division_enter, // 인공위성 게임 진입 시 출력되는 효과음
    division_correct,   // 정답인 위성을 드래그한 경우 출력되는 효과음
    division_incorrect  // 오답인 위성을 드래그한 경우 출력되는 효과음
}

public class StoreQuestData : IEquatable<StoreQuestData>
{
    public string stg_cd;   // 소주제 코드 (학습에서 현재 진행중인 소주제)
    public string stg_nm;   // 소주제명 (소주제 이름)
    public string dtl_cn;   // 소주제 세부 사항 (소주제에 대한 세부 설명)

    public StoreQuestData(string stg_cd, string stg_nm, string dtl_cn)
    {
        this.stg_cd = stg_cd;
        this.stg_nm = stg_nm;
        this.dtl_cn = dtl_cn;
    }

    public bool Equals(StoreQuestData other)
    {
        // Check whether the compared object is null.
        if (ReferenceEquals(other, null))
        {
            return false;
        }

        // Check whether the compared object references the same data.
        if (ReferenceEquals(this, other))
        {
            return true;
        }

        // Check whether the StoreQuestData's properties are equal.
        return stg_cd.Equals(other.stg_cd);
    }

    // If Equals() returns true for a pair of objects
    // then GetHashCode() must return the same value for these objects.
    public override int GetHashCode()
    {
        // Get hash code for the stg_cd field if it is not null.
        int hashProductName = stg_cd == null ? 0 : stg_cd.GetHashCode();

        // Calculate the hash stg_cd for the StoreQuestData.
        return hashProductName;
    }
}

public class LocalDBService : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
