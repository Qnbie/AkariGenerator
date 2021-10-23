using System.Collections;
using System.Collections.Generic;
using Algorithms;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Utils.Enums;
using Utils.StaticClasses;

namespace Tests
{
    [TestFixture]
    public class FirebaseControllerTest
    {
        private FirebaseController _firebaseController;

        [SetUp]
        public void SetUpTets()
        {
            _firebaseController = new FirebaseController();
        }

        [Test]
        public void AddPuzzleTest()
        {
         }
    }
}
