﻿using System.Reflection;

namespace Lobby.Extensions;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}