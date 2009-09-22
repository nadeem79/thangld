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
        public virtual Hero Hero
        {
            get;
            set;
        }
        public override MoveType Type
        {
            get { return MoveType.Return; }
        }


        public override void Save(ISession session)
        {
            this.FromVillage.MovingCommandsFromMe.Add(this);
            this.ToVillage.MovingCommandsToMe.Add(this);
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
            if (this.Merchant > 0)
                this.ToVillage.VillageBuildingData.Merchant += this.Merchant;
            if (this.Hero != null)
            {
                this.Hero.InMovingCommand = null;
                this.Hero.InVillage = this.ToVillage;
                this.ToVillage.Heroes.Add(this.Hero);
                session.Update(this.Hero);
                this.Hero = null;
            }

            this.ToVillage.MovingCommandsToMe.Remove(this);
            this.FromVillage.MovingCommandsFromMe.Remove(this);
            session.Delete(this);
            session.Update(this.ToVillage);
            session.Update(this.FromVillage);

            return null;
        }

        public override MovingCommand Cancel(ISession session)
        {
            throw new Exception("HACK!!!");
        }
    }
}
