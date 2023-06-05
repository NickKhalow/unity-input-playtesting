#nullable enable
using System.Diagnostics.CodeAnalysis;
using Extensions;
using Inputs;
using UnityEngine;
using UnityEngine.Assertions;

namespace PlayTests
{
    [SuppressMessage("ReSharper", "Unity.InefficientPropertyAccess")]
    public class CharacterTest
    {
        [NUnit.Framework.Test]
        public void CharacterTestSimplePasses()
        {
            var character = Character();
            var start = character.Health;
            var damage = Random.Range(10, 20);
            character.Damage(damage);
            Assert.IsTrue(character.Health == start - damage);
        }

        // A UnityTest behaves like a coroutine in PlayMode
        // and allows you to yield null to skip a frame in EditMode
        [UnityEngine.TestTools.UnityTest]
        public System.Collections.IEnumerator CharacterTestWithEnumeratorPasses()
        {
            var character = Character();
            var constInput = character.gameObject.AddComponent<ConstInput>().EnsureNotNull();
            character.Construct((constInput, speed: 10, health: null));
            constInput.Construct(Vector2.up);
            Assert.IsTrue(character.transform.position == Vector3.zero);
            yield return new WaitForSeconds(1);
            Debug.Log($"Position is {character.transform.position.z}");
            Assert.IsTrue((int)character.transform.position.z == 10);
        }

        private Character Character()
        {
            var prefab = (Resources.Load("Character") as GameObject).EnsureNotNull();
            var gameObject = Object.Instantiate(prefab, Vector3.zero, Quaternion.identity).EnsureNotNull();
            return gameObject.GetComponent<Character>().EnsureNotNull();
        }
    }
}