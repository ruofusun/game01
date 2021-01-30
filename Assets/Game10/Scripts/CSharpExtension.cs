using System.Collections;
using System.Collections.Generic;

public static class CSharpExtension
{
    public static T PeekAndPop<T>(this Stack<T> stack, T defaultResult = default(T)) {
        if (stack.Count == 0) return defaultResult;
        var result = stack.Peek();
        stack.Pop();
        return result;
    }
}
