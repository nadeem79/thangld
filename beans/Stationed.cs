using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace beans
{
    public class Stationed : IdentityObject
    {
        #region Variables
        
        #endregion

        #region Properties

        public virtual Village FromVillage
        {
            get;
            set;
        }
        public virtual Village AtVillage
        {
            get;
            set;
        }

        public virtual int Spear
        {
            get;
            set;
        }
        public virtual int Sword
        {
            get;
            set;
        }
        public virtual int Axe
        {
            get;
            set;
        }
        public virtual int Scout
        {
            get;
            set;
        }
        public virtual int Light
        {
            get;
            set;
        }
        public virtual int Heavy
        {
            get;
            set;
        }
        public virtual int Ram
        {
            get;
            set;
        }
        public virtual int Catapult
        {
            get;
            set;
        }
        public virtual int Noble
        {
            get;
            set;
        }

        #endregion

        #region Constructors
        public Stationed()
        {

        }

        #endregion

        #region Methods
        public void Delete(ISession session)
        {
            this.AtVillage.Troop.TotalSpear -= this.Spear;
            this.AtVillage.Troop.TotalSword -= this.Sword;
            this.AtVillage.Troop.TotalAxe -= this.Axe;
            this.AtVillage.Troop.TotalScout -= this.Scout;
            this.AtVillage.Troop.TotalLight -= this.Light;
            this.AtVillage.Troop.TotalHeavy -= this.Heavy;
            this.AtVillage.Troop.TotalRam -= this.Ram;
            this.AtVillage.Troop.TotalCatapult -= this.Catapult;
            this.AtVillage.Troop.TotalNoble -= this.Noble;

            session.Update(this.AtVillage);
            session.Delete(this);
            
        }
        #endregion
    }
}