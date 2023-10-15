using TMPro;
using UnityEngine;
using Vuforia;

/// <summary>
/// ������������ ��������� ������ ������������.
/// </summary>
[RequireComponent(typeof(ImageTargetBehaviour), typeof(DefaultObserverEventHandler))]
public class TrackDistance : MonoBehaviour
{
    [SerializeField] private TMP_Text _worldText;
    [SerializeField] private Canvas _worldCanvas;
    [SerializeField] private GameObject _popup;
    [SerializeField] private TMP_Text _popupText;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _prefabObject;

    private GameObject _instantiateObject;
    private Transform _cahcedTransform;
    private bool _objectActive = false;

    /// <summary>
    /// �������� ������� ����� ������� ��������.
    /// </summary>
    public void OnTargetFound() {
        if (_instantiateObject == null) InstantiatePrefab();

        _worldCanvas.gameObject.SetActive(true);
        _popup.SetActive(true);
        _popupText.text = "T-Rex\n�������� ���������� ����� ������ ���������, ����� �� ����� ������� "
            + "�������������� ��������� � ����� �� ����� ������� ������� �������� �� ��� ������� �����";
    }

    /// <summary>
    /// ������ �������, ����� �������� ������� �� ���� ������.
    /// </summary>
    public void OnTargetLost() {
        if (_instantiateObject == null) return;

        _instantiateObject.SetActive(false);
        _worldCanvas.gameObject.SetActive(false);
        _popup.SetActive(false);

        _objectActive = false;
    }

    private void Start() {
        _cahcedTransform = GetComponent<Transform>();
        _worldCanvas.transform.SetParent(_cahcedTransform);
        _worldCanvas.gameObject.SetActive(false);

        _popup.SetActive(false);
        _popupText.text = string.Empty;
    }

    private void Update() {
        if (_objectActive) {
            var distance = Vector3.Distance(_camera.transform.position, _instantiateObject.transform.position);
            _worldText.text = $"Distance between camera and model is {distance}";
        }
    }

    /// <summary>
    /// ������� �� ����� ������.
    /// </summary>
    private void InstantiatePrefab() {
        if (_prefabObject != null) {
            _instantiateObject = Instantiate(_prefabObject, _cahcedTransform);
            _instantiateObject.SetActive(true);
            _objectActive = true;
        }
    }
}
