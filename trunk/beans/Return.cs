using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using System.Data;

namespace beans
{
    public class Return:MovingCommand
    {

        #region Properties

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
        public virtual int LightCavalry
        {
            get;
            set;
        }
        public virtual int HeavyCavalry
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
        public virtual int Wood
        {
            get;
            set;
        }
        public virtual int Clay
        {
            get;
            set;
        }
        public virtual int Iron
        {
            get;
            set;
        }
        public virtual int Merchant
        {
            get;
            set;
        }
        public override MoveType Type
        {
            get { return MoveType.Return; }
        }
        #endregion

        #region Methods

        public override void Save(ISession session)
        {
            session.Save(this);
        }

        public override MovingCommand Effect(ISession session)
        {
            this.ToVillage.VillageTroopData.Spear += this.Spear;
            this.ToVillage.VillageTroopData.Sword += this.Sword;
            this.ToVillage.VillageTroopData.Axe += this.Axe;
            this.ToVillage.VillageTroopData.Scout += this.Scout;
            this.ToVillage.VillageTroopData.LightCavalry += this.LightCavalry;
            this.ToVillage.VillageTroopData.HeavyCavalry += this.HeavyCavalry;
            this.ToVillage.VillageTroopData.Ram += this.Ram;
            this.ToVillage.VillageTroopData.Catapult += this.Catapult;
            this.ToVillage.VillageTroopData.Noble += this.Noble;

            this.ToVillage.VillageTroopData.SpearInVillage += this.Spear;
            this.ToVillage.VillageTroopData.SwordInVillage += this.Sword;
            this.ToVillage.VillageTroopData.AxeInVillage += this.Axe;
            this.ToVillage.VillageTroopData.ScoutInVillage += this.Scout;
            this.ToVillage.VillageTroopData.LightCavalryInVillage += this.LightCavalry;
            this.ToVillage.VillageTroopData.HeavyCavalryInVillage += this.HeavyCavalry;
            this.ToVillage.VillageTroopData.RamInVillage += this.Ram;
            this.ToVillage.VillageTroopData.CatapultInVillage += this.Catapult;
            this.ToVillage.VillageTroopData.NobleInVillage += this.Noble;

            this.ToVillage.VillageResourceData.Clay += this.Clay;
            this.ToVillage.VillageResourceData.Wood += this.Wood;
            this.ToVillage.VillageResourceData.Iron += this.Iron;

            ITransaction transaction = null;
            try
            {
                transaction = session.BeginTransaction();
                session.Update(this.ToVillage.VillageTroopData);
                session.Update(this.ToVillage.VillageResourceData);
                session.Delete(this);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            return null;
        }

        public override MovingCommand Cancel(ISession session)
        {
            throw new Exception("HACK!!!");
        }
        #endregion
    }
}
