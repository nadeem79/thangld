using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    //public delegate void ResourceChangeHandler(Village village, ResourcesType type, int value);
    public delegate void ResourceChangeHandler(ResourcesType type, int value, int max);

    public class VillageResourcesData:IdentityObject
    {
        private int _wood, _clay, _iron;
        #region Properties.Resources

        public virtual int Wood
        {
            get { return this._wood; }
            set
            {
                this._wood = value;
            }
        }
        public virtual int Clay
        {
            get { return this._clay; }
            set
            {
                    this._clay = value;
            }
        }
        public virtual int Iron
        {
            get { return this._iron; }
            set
            {
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
