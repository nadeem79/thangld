using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

namespace beans.Services
{
    public class StaffManagementService
    {

        public void AddMemberToStaffGroup(Player currentStaff, Player member, StaffGroup group, ISession session)
        {
            ServicesList.SecurityService.CheckPermission(currentStaff, JobEnum.MemberManagement.ToString(), "write");

            if (member.StaffGroups.Contains(group))
                return;
            member.StaffGroups.Add(group);
            session.Update(member);
        }
        public void AddMemberToStaffGroup(Player currentStaff, string username, StaffGroup group, ISession session)
        {

            Player newStaff = (from player in session.Linq<Player>()
                               where player.Username == username
                               select player).SingleOrDefault<Player>();

            if (newStaff == null)
                return;

            this.AddMemberToStaffGroup(currentStaff, newStaff, group, session);
        }

        public void RemoveMemberFromStaffGroup(Player currentStaff, Player member, StaffGroup group, ISession session)
        {
            ServicesList.SecurityService.CheckPermission(currentStaff, JobEnum.MemberManagement.ToString(), "write");

            if (!member.StaffGroups.Contains(group))
                return;

            member.StaffGroups.Remove(group);
            session.Update(member);
        }


        public IList<StaffGroup> GetStaffGroups(Player staff, ISession session)
        {
            ServicesList.SecurityService.CheckPermission(staff, JobEnum.StaffGroupManagement.ToString(), "read");

            ICriteria criteria = session.CreateCriteria<StaffGroup>();
            IList<StaffGroup> staffGroups = criteria.List<StaffGroup>();

            IList<StaffGroup> distinctGroups = new List<StaffGroup>();
            foreach (StaffGroup staffGroup in staffGroups)
            {
                if (!distinctGroups.Contains(staffGroup))
                    distinctGroups.Add(staffGroup);
                else
                    session.Evict(staffGroup);
            }
            return distinctGroups;
        }

        public IList<Player> GetStaffGroupMembers(Player staff, StaffGroup staffGroup, ISession session)
        {
            ServicesList.SecurityService.CheckPermission(staff, JobEnum.StaffGroupManagement.ToString(), "read");

            return (from player in session.Linq<Player>()
                    where player.StaffGroups.Contains(staffGroup)
                    select player).ToList<Player>();
        }

        public void CreateStaffGroup(Player staff, string name, IList<Permission> permissions, ISession session)
        {
            ServicesList.SecurityService.CheckPermission(staff, JobEnum.StaffGroupManagement.ToString(), "write");

            StaffGroup staffGroup = new StaffGroup();
            staffGroup.Name = name;
            staffGroup.Permissions = permissions;
            session.Save(staffGroup);
        }

        public void DeleteStaffGroup(Player staff, int staffGroupId, ISession session)
        {
            ServicesList.SecurityService.CheckPermission(staff, JobEnum.StaffGroupManagement.ToString(), "write");

            try
            {
                StaffGroup staffGroup = session.Load<StaffGroup>(staffGroupId);
                
                session.Delete(staffGroup);
            }
            catch { }
            
        }

        public void SetStaffGroupPermission(Player staff, int staffGroupId, IList<Permission> permissions, ISession session)
        {
            ServicesList.SecurityService.CheckPermission(staff, JobEnum.StaffGroupManagement.ToString(), "write");

            try
            {
                StaffGroup staffGroup = session.Load<StaffGroup>(staffGroupId);

                IQuery queryDeletePermission = session.CreateQuery("delete from Permission permission where permission.StaffGroup = :staffGroup");
                queryDeletePermission.SetEntity("staffGroup", staffGroup);
                queryDeletePermission.ExecuteUpdate();

                foreach (Permission permission in permissions)
                    permission.StaffGroup = staffGroup;
                staffGroup.Permissions = permissions;

                session.Update(staffGroup);
            }
            catch { throw; }
        }

        public void SetStaffGroupName(Player staff, int staffGroupId, string name, ISession session)
        {
            ServicesList.SecurityService.CheckPermission(staff, JobEnum.StaffGroupManagement.ToString(), "write");

            try
            {
                StaffGroup staffGroup = session.Get<StaffGroup>(staffGroupId);

                if (staffGroup.Name != name)
                {
                    staffGroup.Name = name;

                    session.Update(staffGroup);
                }
            }
            catch { throw; }
        }

    }
}
