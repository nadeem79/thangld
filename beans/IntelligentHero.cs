using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace beans
{
    class IntelligentHero:Hero
    {
        protected override void CalculateHeroAtribute()
        {
            throw new NotImplementedException();
            
        }

        public override HeroType Type
        {
            get { return HeroType.Intelligent; }
        }
    }
}
