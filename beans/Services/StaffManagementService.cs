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
            ServicesList.SecurityService.CheckPermission(currentStaff, new Job(JobEnum.MemberManagement.ToString()), "write");

            if (member.StaffGroups.Contains(group))
                return;
            member.StaffGroups.Add(group);
            session.Update(member);
        }

        public void RemoveMemberFromStaffGroup(Player currentStaff, Player member, StaffGroup group, ISession session)
        {
            ServicesList.SecurityService.CheckPermission(currentStaff, new Job(JobEnum.MemberManagement.ToString()), "write");

            if (!member.StaffGroups.Contains(group))
                return;

            member.StaffGroups.Remove(group);
            session.Update(member);
        }


        public IList<StaffGroup> GetStaffGroups(Player staff, ISession session)
        {
            ServicesList.SecurityService.CheckPermission(staff, new Job(JobEnum.StaffGroupManagement.ToString()), "read");

            return (from staffGroup in session.Linq<StaffGroup>()
                    select staffGroup).ToList<StaffGroup>();

        }

        public void CreateStaffGroup(Player staff, string name, IList<Permission> permissions, ISession session)
        {
            ServicesList.SecurityService.CheckPermission(staff, new Job(JobEnum.StaffGroupManagement.ToString()), "write");

            StaffGroup staffGroup = new StaffGroup();
            staffGroup.Name = name;
            staffGroup.Permissions = permissions;
            session.Save(staffGroup);
        }

        public void DeleteStaffGroup(Player staff, int staffGroupId, ISession session)
        {
            ServicesList.SecurityService.CheckPermission(staff, new Job(JobEnum.StaffGroupManagement.ToString()), "write");

            try
            {
                StaffGroup staffGroup = session.Load<StaffGroup>(staffGroupId);
                
                session.Delete(staffGroup);
            }
            catch { }
            
        }

        public void SetStaffGroupPermission(Player staff, int staffGroupId, IList<Permission> permissions, ISession session)
        {
            ServicesList.SecurityService.CheckPermission(staff, new Job(JobEnum.StaffGroupManagement.ToString()), "write");

            try
            {
                StaffGroup staffGroup = session.Load<StaffGroup>(staffGroupId);

                staffGroup.Permissions = permissions;

                session.Update(staffGroup);
            }
            catch { }
        }
    }
}
