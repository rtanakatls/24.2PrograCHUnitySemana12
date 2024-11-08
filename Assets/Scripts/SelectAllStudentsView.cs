using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SelectAllStudentsView : MonoBehaviour
{
    private SelectAllStudentsController controller;
    [SerializeField] private GameObject dataContainerPrefab;
    [SerializeField] private GameObject container;


    private void Awake()
    {
        controller = GetComponent<SelectAllStudentsController>();
    }
    public void Execute()
    {
        controller.Execute(OnResult);
    }


    private void OnResult(StudentDataModel studentDataModel)
    {
        foreach(Transform t in container.GetComponentInChildren<Transform>())
        {
            if (t != container)
            {
                Destroy(t.gameObject);
            }
        }

        foreach(StudentModel studentModel in studentDataModel.data)
        {
            GameObject obj = Instantiate(dataContainerPrefab,container.transform);
            obj.GetComponent<DataContainer>().SetText($"Nombre: {studentModel.name}\nApellido: {studentModel.lastname}");
        }
    }

}
