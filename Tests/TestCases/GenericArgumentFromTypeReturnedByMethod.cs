using System;

public class Container<T> {
    public T Value;

    public void Set (T newValue) {
        Value = newValue;
    }
}

public static class Program {
    public static void Main (string[] args) {
        var ic = new Container<int>();
        var sc = new Container<string>();

        MakeClosure<int>(ic, 1)();
        MakeClosure<string>(sc, "throw")();
    }

    private static T InnerFunction<T> (Container<T> container, T arg) {
        return arg;
    }

    public static Action MakeClosure<T> (Container<T> container, T arg) {
        return (Action)(() => {
            container.Set(InnerFunction<T>(container, arg));

            Console.WriteLine("Value: {0}", container.Value);
        });
    }
}