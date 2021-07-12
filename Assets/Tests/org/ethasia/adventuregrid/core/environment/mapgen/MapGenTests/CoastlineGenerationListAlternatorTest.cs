using NUnit.Framework;
using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Mapgen.Tests
{
    public class CoastLineGenerationAlternatorTest
    {

        [Test]
        public void TestThatSwitchingPropagationListsWorks()
        {
            CoastlineGenerationListAltenator testCandidate = new CoastlineGenerationListAltenator();

            List<CoastlineGenerator.CoastLineCreationSectorBoundary> firstPropagationList = testCandidate.GetCurrentCoastLinePropagationSectors();
            testCandidate.SwitchToNextPropagationList();
            List<CoastlineGenerator.CoastLineCreationSectorBoundary> secondPropagationList = testCandidate.GetCurrentCoastLinePropagationSectors();
            testCandidate.SwitchToNextPropagationList();
            List<CoastlineGenerator.CoastLineCreationSectorBoundary> thirdPropagationList = testCandidate.GetCurrentCoastLinePropagationSectors();
        
            Assert.That(firstPropagationList, Is.SameAs(thirdPropagationList));
            Assert.That(secondPropagationList, Is.Not.SameAs(thirdPropagationList));
        }

        [Test]
        public void TestThatPuttingSectorsIntoListsWorks()
        {
            CoastlineGenerationListAltenator testCandidate = new CoastlineGenerationListAltenator();

            CoastlineGenerator.CoastLineCreationSectorBoundary sector1 = new CoastlineGenerator.CoastLineCreationSectorBoundary(0, 0, 3, 0, 3);
            CoastlineGenerator.CoastLineCreationSectorBoundary sector2 = new CoastlineGenerator.CoastLineCreationSectorBoundary(0, 0, 1, 0, 1);

            testCandidate.PutSector(sector1);

            List<CoastlineGenerator.CoastLineCreationSectorBoundary> firstPropagationList = testCandidate.GetCurrentCoastLinePropagationSectors();
            Assert.That(testCandidate.ContainsSectorInCurrents(sector1), Is.True);

            testCandidate.SwitchToNextPropagationList();
            testCandidate.PutSector(sector2);

            List<CoastlineGenerator.CoastLineCreationSectorBoundary> secondPropagationList = testCandidate.GetCurrentCoastLinePropagationSectors();
            Assert.That(testCandidate.ContainsSectorInCurrents(sector2), Is.True);
        }   

        [Test]
        public void TestThatSectorIsClearedOnSwitchToIt()
        {
            CoastlineGenerationListAltenator testCandidate = new CoastlineGenerationListAltenator();

            CoastlineGenerator.CoastLineCreationSectorBoundary sector1 = new CoastlineGenerator.CoastLineCreationSectorBoundary(0, 0, 3, 0, 3);
            CoastlineGenerator.CoastLineCreationSectorBoundary sector2 = new CoastlineGenerator.CoastLineCreationSectorBoundary(0, 0, 1, 0, 1);
            CoastlineGenerator.CoastLineCreationSectorBoundary sector3 = new CoastlineGenerator.CoastLineCreationSectorBoundary(0, 2, 3, 0, 1);

            testCandidate.PutSector(sector1);
            testCandidate.SwitchToNextPropagationList();
            testCandidate.PutSector(sector2);
            testCandidate.PutSector(sector3);

            testCandidate.SwitchToNextPropagationList();
            Assert.That(testCandidate.ContainsSectorInCurrents(sector1), Is.False);

            testCandidate.SwitchToNextPropagationList();
            Assert.That(testCandidate.ContainsSectorInCurrents(sector2), Is.False);
            Assert.That(testCandidate.ContainsSectorInCurrents(sector3), Is.False);
        }    
    }
}