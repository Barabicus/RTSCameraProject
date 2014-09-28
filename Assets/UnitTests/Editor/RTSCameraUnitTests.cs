using UnityEngine;
using System.Collections;
using NUnit.Framework;

namespace RTSTests {
    public class RTSCameraUnitTests
    {

        [Test]
        public void FindDifference()
        {
            float currentPosition = 1005f;
            float minPosition = 1000f;
            float velocity = 20f;

            float posDiff = currentPosition - minPosition;
            float percentDiff = posDiff / velocity;
            float rollBackDiff = velocity - (velocity * percentDiff);

            Debug.Log(rollBackDiff);

        }

    }
}
