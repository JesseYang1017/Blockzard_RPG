using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameTaskState{
    Waiting,
    Executing,
    Completed,
    End
}

[CreateAssetMenu()]
public class GameTaskSO : ScriptableObject
{
    public GameTaskState state;
    public string[] dialogue;
    public ItemSO startReward;
    public ItemSO endReward;

    public int enemyCountNeed = 5;
    public int currentEnemyCount = 0;

    public void Start(){
        currentEnemyCount = 0;
        state = GameTaskState.Executing;
        EventCenter.OnEnemyDied += OnEnemyDied;

    }

    private void OnEnemyDied(Enemy enemy){
        if(state == GameTaskState.Completed){
            return;
        }
        currentEnemyCount++;
        if(currentEnemyCount >= enemyCountNeed){
            state = GameTaskState.Completed;
            MessageUI.Instance.Show("Quest completed. Please return to Shadow Knight");
        }

    }

    public void End(){
        state = GameTaskState.End;
        EventCenter.OnEnemyDied -= OnEnemyDied;

    }

}

