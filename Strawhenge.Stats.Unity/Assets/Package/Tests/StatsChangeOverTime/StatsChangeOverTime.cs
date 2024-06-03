using NUnit.Framework;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Strawhenge.Stats.Unity.Tests
{
    public class StatsChangeOverTime
    {
        const string Scene = "Assets/Package/Tests/StatsChangeOverTime/StatsChangeOverTime.unity";

        [UnityTest]
        public IEnumerator Stats_should_change_over_time()
        {
            var context = Object.FindObjectOfType<TestContext>();
            var statContainer = context.StatContainer;

            yield return new WaitForEndOfFrame();
            
            var health = AssertMaybe.HasSome(statContainer.FindStat("Health"));
            var lastHealth = health.Value;
            
            var energy = AssertMaybe.HasSome(statContainer.FindStat("Energy"));
            var lastEnergy = energy.Value;
            
            yield return new WaitForSeconds(10);

            Assert.Greater(health.Value, lastHealth);
            lastHealth = health.Value;
           
            Assert.Less(energy.Value, lastEnergy);
            lastEnergy = energy.Value;
            
            yield return new WaitForSeconds(10);
            
            Assert.Greater(health.Value, lastHealth);
            Assert.Less(energy.Value, lastEnergy);
        }

        [UnitySetUp]
        public IEnumerator LoadScene()
        {
            var sceneLoad = EditorSceneManager.LoadSceneAsyncInPlayMode(Scene, new LoadSceneParameters());

            while (!sceneLoad.isDone)
                yield return null;

            Time.timeScale = 10;
        }
    }
}