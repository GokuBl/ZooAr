using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Obsolete("�������� �������� �� ��������� �� ����������")]
public class ExitPreview : MonoBehaviour
{
    public void OnExitClick() {
        SceneManager.LoadSceneAsync("ProfileScene", LoadSceneMode.Single);
    }
}
