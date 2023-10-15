using UnityEngine;

/// <summary>
/// ������������ ��������� �� ���� ����������.
/// </summary>
public class MenuRouting : MonoBehaviour
{
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _loginScreen;
    [SerializeField] private GameObject _registerScreen;

    private void Start() {
        _startScreen.SetActive(true);
        _loginScreen.SetActive(false);
        _registerScreen.SetActive(false);
    }

    /// <summary>
    /// ���������� ������� �� ��������� �����.
    /// </summary>
    public void OnStartScreenClick() {
        _startScreen.SetActive(false);
        _loginScreen.SetActive(true);
    }

    /// <summary>
    /// ���������� ������� �� ������ � ������������ �����������.
    /// </summary>
    public void OnRegisterClick() {
        _loginScreen.SetActive(false);
        _registerScreen.SetActive(true);
    }

    /// <summary>
    /// ���������� ������� �� ������ � ������������ ����� � �������.
    /// </summary>
    public void OnLoginClick() {
        _loginScreen.SetActive(true);
        _registerScreen.SetActive(false);
    }
}
