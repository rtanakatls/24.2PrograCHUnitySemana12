using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class InsertStudentController : MonoBehaviour
{
    public void Execute(string name, string lastName, Action<MessageModel> OnResult)
    {
        StartCoroutine(SendRequest(name, lastName,OnResult));
    }

    IEnumerator SendRequest(string name, string lastName, Action<MessageModel> OnResult)
    {
        WWWForm form = new WWWForm();
        form.AddField("name", name);
        form.AddField("lastname", lastName);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/prograch242/biblioteca/insert_student.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError ||
                www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.Log("Error");
            }
            else
            {
                OnResult(JsonUtility.FromJson<MessageModel>(www.downloadHandler.text));
            }
        }
    }
}
