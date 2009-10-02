﻿using beans;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;

namespace TestProject1
{
    
    
    /// <summary>
    ///This is a test class for AttackTest and is intended
    ///to contain all AttackTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AttackTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for Effect
        ///</summary>
        [TestMethod()]
        public void EffectTest()
        {
            Attack target = new Attack(); // TODO: Initialize to an appropriate value
            ISession session = NHibernateHelper.CreateSession(); // TODO: Initialize to an appropriate value
            TribalWarsEngine.Start(session);
            ITransaction trans = session.BeginTransaction();
            Village v = session.Get<Village>(24);
            Attack a = v.VillageTroopMethods.CreateAttack(session, 47, 53, 0, 0, 500, 0, 500, 0, 500, 0, session.Load<Hero>(32768), BuildingType.NoBuiding);

            trans.Commit();
            MovingCommand expected = null; // TODO: Initialize to an appropriate value
            MovingCommand actual;
            actual = a.Effect(session);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
            session.Close();
        }
    }
}