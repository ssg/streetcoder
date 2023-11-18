﻿using System;

var b = new B();
var a = new A(b);
a.X();

public interface IB
{
    void Y();
}

public class A(IB b)
{
    public void X()
    {
        Console.WriteLine("X got called");
        b.Y();
    }
}

public class B : IB
{
    public void Y()
    {
        Console.WriteLine("Y got called");
    }
}