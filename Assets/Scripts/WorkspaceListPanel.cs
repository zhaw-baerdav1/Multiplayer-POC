using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Match;

public class WorkspaceListPanel : MonoBehaviour
{

    [SerializeField]
    private JoinWorkspaceButton joinWorkspaceButtonPrefab;

    private void Awake()
    {
        WorkspaceList.OnWorkspaceListChanged += WorkplaceList_OnWorkspaceListChanged;
    }

    private void WorkplaceList_OnWorkspaceListChanged(List<MatchInfoSnapshot> workspaceList)
    {
        RemoveButtons();
        CreateNewJoinWorkspaceButtons(workspaceList);
    }

    private void RemoveButtons()
    {
        var buttons = GetComponentsInChildren<JoinWorkspaceButton>();
        foreach (var button in buttons)
        {
            Destroy(button.gameObject);
        }
    }

    private void CreateNewJoinWorkspaceButtons(List<MatchInfoSnapshot> workspaceList)
    {
        foreach (var workspace in workspaceList)
        {
            if (workspace.currentSize >= workspace.maxSize)
            {
                continue;
            }

            var button = Instantiate(joinWorkspaceButtonPrefab);
            button.Initialize(workspace, transform);
        }
    }
}
