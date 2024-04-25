using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayTests {
    GameObject _target, _goal;

    [UnityTest, Order(1)]
    public IEnumerator Start() {
        SceneManager.LoadScene("Game"); 
        yield return null;
        _target = GameObject.Find("Target");
        _goal = GameObject.Find("Goal");
    }

    [Test, Order(2)]
    public void TargetExists() {
        Assert.IsNotNull(_target); 
    }

    [Test, Order(3)]
    public void GoalExists() {
        Assert.IsNotNull(_goal);
    }
}
