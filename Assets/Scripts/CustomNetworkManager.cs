using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class CustomNetworkManager : NetworkManager
{
    private float nextRefreshTime;

    public void StartHosting()
    {
        StartMatchMaker();
        matchMaker.CreateMatch("Test Workspace", 2, true, "", "", "", 0, 0, OnWorkspaceCreate);
    }

    private void OnWorkspaceCreate(bool success, string extendedInfo, MatchInfo responseData)
    {
        base.StartHost(responseData);
    }

    private void Update()
    {
        if (Time.time >= nextRefreshTime)
        {
            RefreshWorkspaceList();
        }
    }

    private void RefreshWorkspaceList()
    {
        nextRefreshTime = Time.time + 5f;

        if (matchMaker == null)
        {
            StartMatchMaker();
        }

        matchMaker.ListMatches(0, 10, "", true, 0, 0, HandleListWorkspacesComplete);
    }

    private void HandleListWorkspacesComplete(bool success, string extendedinfo, List<MatchInfoSnapshot> responseData)
    {
        WorkspaceList.HandleWorspaceList(responseData);
    }

    public void JoinWorkspace(MatchInfoSnapshot workspace)
    {
        if (matchMaker == null)
        {
            StartMatchMaker();
        }

        matchMaker.JoinMatch(workspace.networkId, "", "", "", 0, 0, HandleJoinWorkspace);
    }

    private void HandleJoinWorkspace(bool success, string extendedInfo, MatchInfo responseData)
    {
        StartClient(responseData);
    }


}
