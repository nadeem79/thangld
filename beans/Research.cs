using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;

namespace beans
{

    public class ResearchPrice
    {
        private int _wood;
        private int _clay;
        private int _iron;
        private int _time;
        private string _name;

        public int Wood
        {
            get { return this._wood; }
        }
        public int Clay
        {
            get { return this._clay; }
        }
        public int Iron
        {
            get { return this._iron; }
        }
        public int Time
        {
            get { return this._time; }
        }
        public string Name
        {
            get { return this._name; }
        }

        public override string ToString()
        {
            return this._name;
        }

        public ResearchPrice(string name, int time, int wood, int clay, int iron)
        {
            this._name = name;
            this._time = time;
            this._wood = wood;
            this._clay = clay;
            this._iron = iron;
        }

    }

    public enum ResearchableStatus
    {
        NotEnoughIron,
        NotEnoughWood,
        NotEnoughClay,
        RequirementNotMet,
        JustDoIt
    }

    public class ResearchableStatusFactory
    {
        public static string ToString(ResearchableStatus status)
        {
            switch (status)
            {
                case ResearchableStatus.NotEnoughWood:
                    return "Không đủ gỗ";
                case ResearchableStatus.NotEnoughClay:
                    return "Không đủ gạch";
                case ResearchableStatus.NotEnoughIron:
                    return "Không đủ kim loại";
                case ResearchableStatus.JustDoIt:
                    return "Nghiên cứu";
                case ResearchableStatus.RequirementNotMet:
                    return "Chưa đủ điều kiện nghiên cứu";
                default:
                    return "";
            }
        }

    }

    public class Research:IdentityObject
    {
        #region Static Members
        protected static ResearchPrice rSpear = new ResearchPrice("Spear", 4580, 2560, 2240, 2960);
        protected static ResearchPrice rSword = new ResearchPrice("Sword", 6800, 3600, 3200, 3120);
        protected static ResearchPrice rAxe = new ResearchPrice("Axe", 5950, 2800, 3360, 3280);
        protected static ResearchPrice rScout = new ResearchPrice("Scout", 4210, 2240, 1920, 1920); 
        protected static ResearchPrice rLight = new ResearchPrice("Light", 8600, 8800, 9600, 8000);
        protected static ResearchPrice rHeavy = new ResearchPrice("Heavy", 17260, 12000, 9600, 8000);
        protected static ResearchPrice rRam = new ResearchPrice("Ram", 25730, 4800, 6400, 3200);
        protected static ResearchPrice rCatapult = new ResearchPrice("Catapult", 38600, 6400, 8000, 4800);
        protected static Dictionary<int, ResearchPrice> _dictionary = new Dictionary<int, ResearchPrice>();

        public static ResearchPrice Spear
        {
            get
            {
                return rSpear;
            }
        }
        public static ResearchPrice Sword
        {
            get
            {
                return rSword;
            }
        }
        public static ResearchPrice Axe
        {
            get
            {
                return rAxe;
            }
        }
        public static ResearchPrice Scout
        {
            get
            {
                return rScout;
            }
        }
        public static ResearchPrice Light
        {
            get
            {
                return rLight;
            }
        }
        public static ResearchPrice Heavy
        {
            get
            {
                return rHeavy;
            }
        }
        public static ResearchPrice Ram
        {
            get
            {
                return rRam;
            }
        }
        public static ResearchPrice Catapult
        {
            get
            {
                return rCatapult;
            }
        }
        public static Dictionary<int, ResearchPrice> PriceDictionary
        {
            get { return Research._dictionary; }
        }

        public static ResearchPrice GetPrice(TroopType troop)
        {
            switch (troop)
            {
                case TroopType.Spear:
                    return Research.Spear;
                    break;
                case TroopType.Sword:
                    return Research.Sword;
                    break;
                case TroopType.Axe:
                    return Research.Axe;
                    break;
                case TroopType.Scout:
                    return Research.Scout;
                    break;
                case TroopType.Light:
                    return Research.Light;
                    break;
                case TroopType.Heavy:
                    return Research.Heavy;
                    break;
                case TroopType.Ram:
                    return Research.Ram;
                    break;
                case TroopType.Catapult:
                    return Research.Catapult;
                    break;
                default:
                    throw new Exception("Báo động: HACK!!!");
                    break;
            }
        }
        public static ResearchPrice GetPrice(TroopType troop, int level, int smithy)
        {
            if (level <= 1)
                return Research.GetPrice(troop);

            int key = (smithy * 1000000) + (level * 10000) + (int)troop;
            if (Research.PriceDictionary.ContainsKey(key))
                return Research.PriceDictionary[key];

            ResearchPrice basePrice = Research.GetPrice(troop);
            int time = basePrice.Time, wood = basePrice.Wood, clay = basePrice.Clay, iron = basePrice.Iron;

            for (int i = 1; i < level; i++)
            {
                time *= 2;
                wood *= 4;
                clay *= 4;
                iron *= 4;
            }
            for (int i = 1; i < smithy; i++)
                time -= (int)(time * 0.2);
            ResearchPrice price = new ResearchPrice(basePrice.Name, time, wood, clay, iron);
            Research.PriceDictionary.Add(key, price);
            return price;
        }
        #endregion

        #region Variables
        DateTime end = new DateTime();
        #endregion

        #region Properties
        public Village Village
        {
            get;
            set;
        }
        public TroopType Type
        {
            get;
            set;
        }
        public int Level
        {
            get;
            set;
        }
        public DateTime Start
        {
            get;
            set;
        }
        public DateTime End
        {
            get
            {
                if (end != new DateTime())
                    return end;
                ResearchPrice price = Research.GetPrice(this.Type, this.Level, this.Village[BuildingType.Smithy]);
                TimeSpan t = TimeSpan.FromSeconds(price.Time);
                end = this.Start + t;
                return end;
            }
        }
        #endregion

        #region Methods
        public bool Expense(DateTime time)
        {
            ResearchPrice price = Research.GetPrice(this.Type, this.Level, this.Village[BuildingType.Smithy]);
            TimeSpan t = TimeSpan.FromSeconds(price.Time);

            if ((this.Start + t) > time)
                return false;

            switch (this.Type)
            {
                case TroopType.Spear:
                    this.Village.Research.ResearchSpear++;
                    break;
                case TroopType.Sword:
                    this.Village.Research.ResearchSword++;
                    break;
                case TroopType.Axe:
                    this.Village.Research.ResearchAxe++;
                    break;
                case TroopType.Scout:
                    this.Village.Research.ResearchScout++;
                    break;
                case TroopType.Light:
                    this.Village.Research.ResearchLight++;
                    break;
                case TroopType.Heavy:
                    this.Village.Research.ResearchHeavy++;
                    break;
                case TroopType.Ram:
                    this.Village.Research.ResearchRam++;
                    break;
                case TroopType.Catapult:
                    this.Village.Research.ResearchCatapult++;
                    break;
                default:
                    break;
            }
            return true;
        }
        public void Cancel(ISession session)
        {
            ResearchPrice price = Research.GetPrice(this.Type, this.Level, this.Village[BuildingType.Smithy]);

            this.Village.Resources.Wood += (int)(price.Wood * 0.8);
            this.Village.Resources.Clay += (int)(price.Clay * 0.8);
            this.Village.Resources.Iron += (int)(price.Iron * 0.8);

            ICriteria criteria = session.CreateCriteria(typeof(Research));
            criteria.Add(Expression.Eq("Village", this.Village));
            criteria.Add(Expression.Eq("Type", this.Type));
            criteria.Add(Expression.Gt("ID", this.ID));
            IList<Research> lstResearchs = criteria.List<Research>();
            foreach (Research research in lstResearchs)
                research.Level--;

            session.Delete(this);
        }
        #endregion
    }


}
