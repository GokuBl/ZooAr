using System;
using System.IO;
using UnityEngine;

public static class SavingService
{
    /// <summary>
    /// ���� ��������� ����� ����������.
    /// </summary>
    public static string filePath = Application.persistentDataPath + "/usersdata.json";

    /// <summary>
    /// ���������� ������ �����������.
    /// </summary>
    /// <param name="data"></param>
    public static void SaveData(UsersData data) {
        try {
            using var stream = new FileStream(filePath, FileMode.Create);
            using var writer = new StreamWriter(stream);

            writer.Write(JsonUtility.ToJson(data, true));
        }
        catch (Exception ex) {
            Debug.LogException(ex);
        }
    }

    /// <summary>
    /// �������� ������ �������������.
    /// </summary>
    /// <returns></returns>
    public static UsersData LoadData() {
        if (!File.Exists(filePath)) {
            return null;
        }

        var dataToLoad = "";

        try {
            using var stream = new FileStream(filePath, FileMode.OpenOrCreate);
            using var reader = new StreamReader(stream);

            dataToLoad = reader.ReadToEnd();
        } catch (Exception ex) {
            Debug.LogException(ex);
        }

        return dataToLoad != "" ? JsonUtility.FromJson<UsersData>(dataToLoad) : null;
    }
}
