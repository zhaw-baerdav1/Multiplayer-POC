using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking.Match;

public class JoinWorkspaceButton : MonoBehaviour
{
    private Text buttonText;
    private MatchInfoSnapshot workspace;

    private void Awake()
    {
        buttonText = GetComponentInChildren<Text>();

        GetComponent<Button>().onClick.AddListener(JoinWorkspace);
    }

    public void Initialize(MatchInfoSnapshot workspace, Transform panelTransform)
    {
        this.workspace = workspace;
        buttonText.text = workspace.name;

        transform.SetParent(panelTransform);
        transform.localScale = Vector3.one;
        transform.localRotation = Quaternion.identity;
        transform.localPosition = Vector3.zero;
    }

    public void JoinWorkspace()
    {
        FindObjectOfType<CustomNetworkManager>().JoinWorkspace(workspace);
    }

}
