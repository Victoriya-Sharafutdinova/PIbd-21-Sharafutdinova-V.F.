using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsCars
{
    class MultiLevelWharf
    {
        List<Wharf<ITransport>> parkingStages;
        private const int countPlaces = 20; 
        public MultiLevelWharf(int countStages, int pictureWidth, int pictureHeight)
        {
            parkingStages = new List<Wharf<ITransport>>();
            for(int i =0; i< countStages; ++i)
            {
                parkingStages.Add(new Wharf<ITransport>(countPlaces, pictureWidth, pictureHeight));
            }
        }
        public Wharf<ITransport> this[int ind]
        {
            get
            {
                if(ind>-1 && ind < parkingStages.Count)
                {
                    return parkingStages[ind];
                }
                return null;
            }
        }
    }
}
