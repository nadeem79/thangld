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
        public event ResourceChangeHandler ResourceChanged;
        #region Properties.Resources

        public virtual int Wood
        {
            get { return this._wood; }
            set
            {
                this._wood = value;
                if (this.ResourceChanged!=null)
                    this.ResourceChanged(ResourcesType.Wood, value, this.Village.MaxResources);
            }
        }
        public virtual int Clay
        {
            get { return this._clay; }
            set
            {
                    this._clay = value;
                    if (this.ResourceChanged != null)
                        this.ResourceChanged(ResourcesType.Clay, value, this.Village.MaxResources);
            }
        }
        public virtual int Iron
        {
            get { return this._iron; }
            set
            {
                    this._iron = value;
                    if (this.ResourceChanged != null)
                        this.ResourceChanged(ResourcesType.Iron, value, this.Village.MaxResources);
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
