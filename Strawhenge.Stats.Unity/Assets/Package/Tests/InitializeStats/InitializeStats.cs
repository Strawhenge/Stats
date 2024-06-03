using NUnit.Framework;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Strawhenge.Stats.Unity.Tests
{
    public class InitializeStats
    {
        const string Scene = "Assets/Package/Tests/InitializeStats/InitializeStats.unity";

        [UnityTest]
        public IEnumerator Stats_should_have_default_values_set_in_inspector()
        {
            var context = Object.FindObjectOfType<TestContext>();
            var statContainer = context.StatContainer;

            yield return new WaitForEndOfFrame();

            Assert.AreEqual(2, statContainer.Stats.Count);

            statContainer.VerifyStat(StatNames.Health, 50, 100);
            statContainer.VerifyStat(StatNames.Energy, 100, 100);
        }

        [UnitySetUp]
        public IEnumerator LoadScene()
        {
            var sceneLoad = EditorSceneManager.LoadSceneAsyncInPlayMode(Scene, new LoadSceneParameters());

            while (!sceneLoad.isDone)
                yield return null;
        }
    }
}