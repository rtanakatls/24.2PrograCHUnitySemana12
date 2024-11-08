using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InsertStudentView : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private TMP_InputField lastNameInputField;
    [SerializeField] private Button executeButton;
    private InsertStudentController controller; 
    private SelectAllStudentsView selectAllStudentsView;

    private void Awake()
    {
        controller = GetComponent<InsertStudentController>();
        selectAllStudentsView = GetComponent<SelectAllStudentsView>();
        executeButton.onClick.AddListener(Execute);
    }

    private void Execute()
    {
        controller.Execute(nameInputField.text, lastNameInputField.text,OnResult);
    }

    private void OnResult(MessageModel message)
    {
        if (message.message == "success")
        {
            selectAllStudentsView.Execute();
        }
        else
        {

        }
    }


}
