using System;
using System.Collections.Generic;

namespace DemoProject.Unittests;

public class FakeNavigateService : INavigateService
{
    public bool HasNextBeenCalled { get; set; }
    public void Next(List<NavigableItem> navigableItems)
    {
        Console.WriteLine("fakenext");
        HasNextBeenCalled = true;
    }
}