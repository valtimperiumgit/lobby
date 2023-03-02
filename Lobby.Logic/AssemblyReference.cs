using System.Reflection;

namespace Lobby.Logic;
public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}