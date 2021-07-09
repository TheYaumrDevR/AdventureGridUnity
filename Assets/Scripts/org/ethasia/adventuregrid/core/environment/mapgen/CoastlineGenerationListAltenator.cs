using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Mapgen
{

    internal class CoastlineGenerationListAltenator
    {

        private bool usingFirstPropagationList;
        private List<CoastlineGenerator.CoastLineCreationSectorBoundary> coastLinePropagationSectorsOne;
        private List<CoastlineGenerator.CoastLineCreationSectorBoundary> coastLinePropagationSectorsTwo;      

        internal List<CoastlineGenerator.CoastLineCreationSectorBoundary> GetCurrentCoastLinePropagationSectors()
        {
            if (usingFirstPropagationList)
            {
                return coastLinePropagationSectorsOne;
            }
            else
            {
                return coastLinePropagationSectorsTwo;
            }
        }      

        internal CoastlineGenerationListAltenator()
        {
            usingFirstPropagationList = true;
            coastLinePropagationSectorsOne = new List<CoastlineGenerator.CoastLineCreationSectorBoundary>();
            coastLinePropagationSectorsTwo = new List<CoastlineGenerator.CoastLineCreationSectorBoundary>();            
        }  

        internal bool ContainsSectorInCurrents(CoastlineGenerator.CoastLineCreationSectorBoundary sector)
        {
            List<CoastlineGenerator.CoastLineCreationSectorBoundary> currentSectors = GetCurrentCoastLinePropagationSectors();
            return currentSectors.Contains(sector);
        }

        internal void PutSector(CoastlineGenerator.CoastLineCreationSectorBoundary value)
        {
            if (usingFirstPropagationList)
            {
                coastLinePropagationSectorsOne.Add(value);
            }
            else
            {
                coastLinePropagationSectorsTwo.Add(value);
            }
        }

        internal void SwitchToNextPropagationList()
        {
            usingFirstPropagationList = !usingFirstPropagationList;
            ClearCurrentPropagationList();
        }

        private void ClearCurrentPropagationList()
        {
            if (usingFirstPropagationList)
            {
                coastLinePropagationSectorsOne.Clear();
            }
            else
            {
                coastLinePropagationSectorsTwo.Clear();
            }            
        }
    }
}