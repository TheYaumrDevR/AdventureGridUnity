using System.Collections.Generic;

namespace Org.Ethasia.Adventuregrid.Core.Environment.Mapgen
{

    public class CoastlineGenerationListAltenator
    {

        private bool usingFirstPropagationList;
        private List<CoastlineGenerator.CoastLineCreationSectorBoundary> coastLinePropagationSectorsOne;
        private List<CoastlineGenerator.CoastLineCreationSectorBoundary> coastLinePropagationSectorsTwo;      

        public List<CoastlineGenerator.CoastLineCreationSectorBoundary> GetCurrentCoastLinePropagationSectors()
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

        public CoastlineGenerationListAltenator()
        {
            usingFirstPropagationList = true;
            coastLinePropagationSectorsOne = new List<CoastlineGenerator.CoastLineCreationSectorBoundary>();
            coastLinePropagationSectorsTwo = new List<CoastlineGenerator.CoastLineCreationSectorBoundary>();            
        }  

        public void SwitchToNextPropagationList()
        {
            usingFirstPropagationList = !usingFirstPropagationList;
            ClearCurrentPropagationList();
        }        

        public void PutSector(CoastlineGenerator.CoastLineCreationSectorBoundary value)
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

        public bool ContainsSectorInCurrents(CoastlineGenerator.CoastLineCreationSectorBoundary sector)
        {
            List<CoastlineGenerator.CoastLineCreationSectorBoundary> currentSectors = GetCurrentCoastLinePropagationSectors();
            return currentSectors.Contains(sector);
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