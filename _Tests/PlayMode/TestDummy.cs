using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

public class TestDummy
{
    [UnityTest]
    public IEnumerator TestDummySomething()
    {
        yield return null;
        Assert.Equals(3, 3);
    }
}
