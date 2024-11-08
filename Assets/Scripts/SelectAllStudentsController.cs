using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SelectAllStudentsController : MonoBehaviour
{
    public void Execute(Action<StudentDataModel> OnResult)
    {
        StartCoroutine(SendRequest(OnResult));
    }

    IEnumerator SendRequest(Action<StudentDataModel> OnResult)
    {

        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/prograch242/biblioteca/select_all_students.php"))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError ||
                www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Error");
            }
            else
            {
                OnResult(JsonUtility.FromJson<StudentDataModel>(www.downloadHandler.text));
            }
        }

    }
}
