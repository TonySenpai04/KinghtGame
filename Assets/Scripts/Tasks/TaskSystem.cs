using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]

 public class TaskSystem : MonoBehaviour
{

    public List<Task> tasks = new List<Task>();
    public List<Task> Tasks = new List<Task>();
    public TextMeshProUGUI TitleTask;
    public TextMeshProUGUI DescriptionTask;
    public GameObject panelTask;
    public bool isActive=true;
    public void AddTask(Task task)
    {
       // Task task = new Task();
        tasks.Add(task);
    }
    public void UpdateUI(Task task)
    {  
            TitleTask.text = task.taskName;
            DescriptionTask.text = task.Description;
    }
    private void Update()
    {
        if(Input.GetKey(KeyCode.M))
        {
            if (isActive)
            {
                panelTask.SetActive(true);
                isActive=false;
            }
            else
            {
                panelTask.SetActive(false);
                isActive = true;
            }
            
        }
    }
    public void CompleteTask(Task task)
    {
        if (tasks.Count > 0)
        {
           // Task task = tasks.Find(t => t.taskName == taskName);
            if (task != null)
            {
                task.isCompleted = true;

                Debug.Log("Task completed: " + task.taskName);


            }
            else
            {
                Debug.Log("Task not found: " +task. taskName);
            }
        }
    }

    public bool IsTaskCompleted(string taskName)
    {
        if (tasks.Count > 0)
        {
            Task task = tasks.Find(t => t.taskName == taskName);

            if (task != null)
            {
                return task.SetTask(task);
                //return task.isCompleted;
            }
            else
            {
                Debug.Log("Task not found: " + taskName);
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    ////[SerializeField] private List<Task> tasks;

    //// private void Start()
    //// {
    ////     tasks = new List<Task>();
    //// }

    //// public void AddTask(Task task)
    //// {
    ////     tasks.Add(task);
    //// }

    //// public void RemoveTask(Task task)
    //// {
    ////     tasks.Remove(task);
    //// }

    //// private void Update()
    //// {

    ////         foreach (Task task in tasks)
    ////         {
    ////             if (task != null)
    ////             {
    ////                 task.UpdateTask();
    ////             return;

    ////             }
    ////             else
    ////             {
    ////                 Debug.Log("Task null");
    ////             }
    ////         }

    //// }
}



