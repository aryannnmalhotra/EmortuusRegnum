using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    private Queue<Task> pendingTasks = new Queue<Task>();
    private Task currentTask = null;
    public bool HasTakenPreviousShot = true;
    private void Start()
    {
        StartTask(new Task(this));
    }
    public void StartTask(Task task)
    {
        if (task == null)
            return;
        if (currentTask != null && currentTask != task)
        {
            if (currentTask.End())
            {
                currentTask = task;
                currentTask.Start();
            }
            else
                pendingTasks.Enqueue(task);
        }
        else
        {
            currentTask = task;
            currentTask.Start();
        }

    }
    public void EndTask(Task task)
    {
        if (currentTask != null && currentTask == task)
            currentTask.End();
        else
            return;
    }
    public void OnTaskCompleted(Task task)
    {
        if (task != null && task == currentTask)
        {
            Task nextTask;
            if (pendingTasks.Count > 0)
            {
                nextTask = pendingTasks.Dequeue();
                currentTask = nextTask;
                currentTask.Start();
            }
            else
                currentTask = null;
        }
    }
    void Update()
    {

    }
}
