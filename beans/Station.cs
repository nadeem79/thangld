using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace beans
{
    public class Station : IdentityObject
    {

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

        #endregion

        #region Methods
        public Return Return(int spear, 
                            int sword,
                            int axe,
                            int scout,
                            int lightCavalry,
                            int heavyCavalry,
                            int ram,
                            int catapult,
                            int noble,
                            ISession session)
        {
            this.AtVillage.VillageTroopData.SpearInVillage -= spear;
            this.AtVillage.VillageTroopData.SwordInVillage -= sword;
            this.AtVillage.VillageTroopData.AxeInVillage -= axe;
            this.AtVillage.VillageTroopData.ScoutInVillage -= scout;
            this.AtVillage.VillageTroopData.LightCavalryInVillage -= lightCavalry;
            this.AtVillage.VillageTroopData.HeavyCavalryInVillage -= heavyCavalry;
            this.AtVillage.VillageTroopData.RamInVillage -= ram;
            this.AtVillage.VillageTroopData.CatapultInVillage -= catapult;
            this.AtVillage.VillageTroopData.NobleInVillage -= noble;

            this.Spear -= spear;
            this.Sword -= sword;
            this.Axe -= axe;
            this.Scout -= scout;
            this.LightCavalry -= lightCavalry;
            this.HeavyCavalry -= heavyCavalry;
            this.Ram -= ram;
            this.Catapult -= catapult;
            this.Noble -= noble;

            beans.Return returnTroop = new Return();
            returnTroop.Spear = spear;
            returnTroop.Spear = sword;
            returnTroop.Spear = axe;
            returnTroop.Spear = scout;
            returnTroop.Spear = lightCavalry;
            returnTroop.Spear = heavyCavalry;
            returnTroop.Spear = ram;
            returnTroop.Spear = catapult;
            returnTroop.Spear = noble;
            returnTroop.FromVillage = this.AtVillage;
            returnTroop.ToVillage = this.FromVillage;
            returnTroop.StartingTime = DateTime.Now;
            returnTroop.LandingTime = Map.LandingTime(

            bool delete = (this.Spear <= 0 && this.Sword <= 0 && this.Axe <= 0
                && this.Scout <= 0 && this.LightCavalry <= 0 && this.HeavyCavalry <= 0
                && this.Ram <= 0 && this.Catapult <= 0
                && this.Noble <= 0);

            ITransaction transaction = null;
            try
            {
                transaction = session.BeginTransaction();
                session.Update(this.AtVillage.VillageTroopData);
                if (delete)
                    session.Delete(this);
                else
                    session.Update(this);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
            
        }
        #endregion
    }
}