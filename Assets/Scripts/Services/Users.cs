using System;
using System.Collections.Generic;

/// <summary>
/// ������ �������������.
/// </summary>
[Serializable]
public sealed class UsersData
{
    public List<User> Users;
}

/// <summary>
/// ������ � ������������.
/// </summary>
[Serializable]
public sealed class User
{
    public string Login;

    public string Password;
}
