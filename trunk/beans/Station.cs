using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace beans
{
    public class Station : IdentityObject
    {


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

        public static Station GetById(int id, ISession session)
        {
            return session.Get<Station>(id);
        }

        public Return Return(int spear, 
                            int sword,
                            int axe,
                            int scout,
                            int lightCavalry,
                            int heavyCavalry,
                            int ram,
                            int catapult,
                            int noble,
                            bool isSendback,
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
            returnTroop.Sword = sword;
            returnTroop.Axe = axe;
            returnTroop.Scout = scout;
            returnTroop.LightCavalry = lightCavalry;
            returnTroop.HeavyCavalry = heavyCavalry;
            returnTroop.Ram = ram;
            returnTroop.Catapult = catapult;
            returnTroop.Noble = noble;
            returnTroop.FromVillage = this.AtVillage;
            returnTroop.ToVillage = this.FromVillage;
            returnTroop.StartingTime = DateTime.Now;
            returnTroop.LandingTime = Map.LandingTime(  Map.SlowestSpeed(spear, sword, axe, scout, lightCavalry, heavyCavalry, ram, catapult, noble), 
                                                        this.AtVillage, 
                                                        this.FromVillage, 
                                                        returnTroop.StartingTime);
                
            bool delete = (this.Spear <= 0 && this.Sword <= 0 && this.Axe <= 0
                && this.Scout <= 0 && this.LightCavalry <= 0 && this.HeavyCavalry <= 0
                && this.Ram <= 0 && this.Catapult <= 0
                && this.Noble <= 0);

            Report report = null;
            if (!isSendback)
            {
                report = new SupportWithdawalReport();
                SupportWithdawalReport supportWithdawalReport = (SupportWithdawalReport)report;
                supportWithdawalReport.FromPlayer = this.AtVillage.Player;
                supportWithdawalReport.FromVillage = this.AtVillage;
                supportWithdawalReport.OriginalPlayer = this.FromVillage.Player;
                supportWithdawalReport.OriginalVillage = this.FromVillage;
                supportWithdawalReport.Owner = this.AtVillage.Player;
                supportWithdawalReport.Title = string.Format("{0} rút quân về từ {1} ({2}|{3})", this.FromVillage.Player.Username, this.AtVillage.Name, this.AtVillage.X.ToString("000"), this.AtVillage.Y.ToString("000"));
                supportWithdawalReport.Spear = spear;
                supportWithdawalReport.Sword = sword;
                supportWithdawalReport.Axe = axe;
                supportWithdawalReport.Scout = scout;
                supportWithdawalReport.LightCavalry = lightCavalry;
                supportWithdawalReport.HeavyCavalry = heavyCavalry;
                supportWithdawalReport.Ram = ram;
                supportWithdawalReport.Catapult = catapult;
                supportWithdawalReport.Noble = noble;
            }
            else
            {
                report = new SupportSendbackReport();
                SupportSendbackReport supportSendbackReport = (SupportSendbackReport)report;
                supportSendbackReport.FromPlayer = this.AtVillage.Player;
                supportSendbackReport.FromVillage = this.AtVillage;
                supportSendbackReport.OriginalPlayer = this.FromVillage.Player;
                supportSendbackReport.OriginalVillage = this.FromVillage;
                supportSendbackReport.Owner = this.FromVillage.Player;
                supportSendbackReport.Title = string.Format("{0} gửi quân về từ {1} ({2}|{3})", this.FromVillage.Player.Username, this.AtVillage.Name, this.AtVillage.X.ToString("000"), this.AtVillage.Y.ToString("000"));
                supportSendbackReport.Spear = spear;
                supportSendbackReport.Sword = sword;
                supportSendbackReport.Axe = axe;
                supportSendbackReport.Scout = scout;
                supportSendbackReport.LightCavalry = lightCavalry;
                supportSendbackReport.HeavyCavalry = heavyCavalry;
                supportSendbackReport.Ram = ram;
                supportSendbackReport.Catapult = catapult;
                supportSendbackReport.Noble = noble;
            }
            report.Unread = true;
            report.Time = DateTime.Now;
            

            ITransaction transaction = null;
            try
            {
                transaction = session.BeginTransaction();
                session.Update(this.AtVillage.VillageTroopData);
                session.Save(returnTroop);
                if (delete)
                    session.Delete(this);
                else
                    session.Update(this);
                session.Save(report);
                transaction.Commit();
                return returnTroop;
            }
            catch
            {
                transaction.Rollback();
                return null;
            }
            
        }

        public Return Return(ISession session, bool isSendback)
        {
            return this.Return( this.Spear,
                                this.Sword,
                                this.Axe,
                                this.Scout,
                                this.LightCavalry,
                                this.HeavyCavalry,
                                this.Ram,
                                this.Catapult,
                                this.Noble,
                                isSendback,
                                session);
        }
        

    }
}