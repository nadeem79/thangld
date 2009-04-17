using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    public class VillageResourcesData:IdentityObject
    {
        private int _wood, _clay, _iron;

        #region Properties.Resources

        public virtual int Wood
        {
            get { return this._wood; }
            set
            {
                //int max = this.Village.MaxResources;
                //if (value > max)
                //    this._wood = max;
                //else if (value < 0)
                //    this._wood = 0;
                //else
                    this._wood = value;
            }
        }
        public virtual int Clay
        {
            get { return this._clay; }
            set
            {
                //int max = this.Village.MaxResources;
                //if (value > max)
                //    this._clay = max;
                //else if (value < 0)
                //    this._clay = 0;
                //else
                    this._clay = value;
            }
        }
        public virtual int Iron
        {
            get { return this._iron; }
            set
            {
                //int max = this.Village.MaxResources;
                //if (value > max)
                //    this._iron = max;
                //else if (value < 0)
                //    this._iron = 0;
                //else
                    this._iron = value;
            }
        }

        #endregion
        public virtual Village Village
        {
            get;
            set;
        }
    }
}
