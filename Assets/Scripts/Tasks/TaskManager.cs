using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TaskManager : Task
{
    [SerializeField] private TaskSystem taskManager;
    public int quality;
    public TaskSO taskSO;
    public TaskManager(string name) : base(name)
    {
        

    }



    private void Start()
    {
         taskManager.tasks[0].Description= taskSO.Description ;
        taskManager.UpdateUI(taskManager.tasks[0]);

    }
    
    
    private void Update()
    {
        
        // Kiểm tra việc hoàn thành Task khi nhấn nút chữ "C"
        if (Input.GetKeyDown(KeyCode.C))
        {
            
            if (taskManager.tasks.Count > 0)
            {
                CompleteCurrentTask(taskManager.tasks[0]);

            }
            else
            {
               // Debug.Log("Task null");
                if (taskManager.Tasks.Count > 0)
                {
                    for (int i = 0; i < taskManager.Tasks.Count; i++)
                    {
                        taskManager.tasks.Add((Task)taskManager.Tasks[i]);
                      taskManager.Tasks.Remove(taskManager.Tasks[i]);
                        return;
                    }
                }
                else
                {
                    Debug.Log("Task null");

                }
            }
        }
    }

    private void CompleteCurrentTask(Task task)
    {

        // Kiểm tra xem Task hiện tại có tồn tại và chưa được hoàn thành hay không
        if (taskManager.IsTaskCompleted(taskName))
        {
            Debug.Log(taskName + " is already completed!");
           // Task  task = taskManager.tasks.Find(t => t.taskName == taskName);
            if (task != null)
            {
                
                taskManager.tasks.Remove(task);
            }
        }
        else
        {
            // Hoàn thành Task và cập nhật trạng thái
            taskManager.CompleteTask(task);
        }
    }

    public override bool SetTask(Task task)
    {
        //quality += 1;
        //if (quality > 4)
        //{
        //    return task.isCompleted;
        //}
        //else
        //{
        //    return false;
        //}
        task = taskManager.tasks[0];
        task.Quality += 1;
      return taskSO.Set(taskManager.tasks[0]);
    }


}

