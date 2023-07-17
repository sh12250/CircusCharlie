using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static partial class GFunc
{
    // 래핑 : 이미 있는 함수를 사용하기 쉽게 재정의하는 것
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message)
    {
#if DEBUG_MODE
        Debug.Log(message);
#endif
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void LogWarning(object message)
    {
#if DEBUG_MODE
        Debug.LogWarning(message);
#endif
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Assert(bool condition)
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif
    }

    //! Gameobject 받아서 Text 컴포넌트 찾아서 text 필드 값 수정하는 함수
    public static void SetText(this GameObject target, string text)
    {
        Text textComponent = target.GetComponent<Text>();
        // GetComponent<컴포넌트 명>() : 가지고 있는 컴포넌트를 찾는다
        // AddComponent<컴포넌트 명>() : 컴포넌트를 추가해준다
        if (textComponent == null || textComponent == default)
        {
            return;
        }

        textComponent.text = text;
    }

    //! LoadScene 함수 래핑
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //! 현재 씬의 이름을 리턴한다
    public static string GetActiveSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    //! 활성화된 현재 씬의 루트 오브젝트를 서치해서 찾아주는 함수
    public static GameObject GetRootObj(string objName_)
    {
        Scene activeScene_ = SceneManager.GetActiveScene();
        GameObject[] rootObjs_ = activeScene_.GetRootGameObjects();

        GameObject targetObj_ = default;
        foreach(GameObject rootObj_ in rootObjs_)
        {
            if(rootObj_.name.Equals(objName_))
            {
                targetObj_ = rootObj_;
                return targetObj_;
            }
            else
            {
                continue;
            }
        }

    }

    //! e두 벡터를 더한다
    public static Vector2 AddVectors(this Vector3 origin, Vector2 addVector)
    {
        Vector2 result = new Vector2(origin.x, origin.y);
        result += addVector;
        return result;
    }

    //! 컴포넌트가 존재하는지 여부를 체크하는 함수
    public static bool IsValid<T>(this T target) where T : Component
    {
        if (target == null || target == default)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public static bool IsValid<T>(this List<T> target)
    {
        bool isInvalid = (target == null || target == default);
        isInvalid = isInvalid || target.Count == 0;

        if (isInvalid)
        {
            return false;
        }

        return true;
    }
}
