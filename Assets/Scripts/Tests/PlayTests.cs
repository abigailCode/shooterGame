using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayTests
{

    public GameObject explosionable;
    private bool rockExistsBeforeCollision;


    [UnityTest, Order(1)]
    public IEnumerator Inicio()
    {
        SceneManager.LoadScene("Game"); 
        yield return null; 
        explosionable = GameObject.Find("Rock");


    }

    [Test, Order(2)]
    public void ExplosionableExists()
    {
        Assert.IsNotNull(explosionable); 
    }

    [UnityTest, Order(3)]
    public IEnumerator ExplosionableExplodes()
    {
        var projectile = new GameObject("Projectile", typeof(BoxCollider), typeof(Rigidbody));
        projectile.tag = "Projectile";
        projectile.transform.position = explosionable.transform.position;
        
        // Wait for physics to process
        yield return new WaitForSeconds(1);

        // Check if explosionable still exists
        Assert.IsFalse(explosionable.gameObject.activeSelf, "Rock should be inactive after collision with projectile");
    }



}
