using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrendasDayCare_Lib
{
    public class TeacherRepository
    {
        private readonly List<Teacher> _teacherDB = new List<Teacher>();
        private int _count;

        public bool AddTeacher(Teacher teacher)
        {
            if (teacher is null)
            {
                return false;
            }
            else
            {
                _count++;
                teacher.ID = _count;
                _teacherDB.Add(teacher);
                return true;
            }
        }
        public List<Teacher> GetTeachers()
        {
            return _teacherDB;
        }
        public Teacher GetTeacher(int id)
        {
            foreach (var teacher in _teacherDB)
            {
                if (teacher.ID==id)
                {
                    return teacher;
                }
            }
            return null;
        }
        public bool UpdateTeacher(int id, Teacher updatedTeacherValues)
        {
            var teacher = GetTeacher(id);
            if (teacher != null)
            {
                teacher.FirstName = updatedTeacherValues.FirstName;
                teacher.LastName = updatedTeacherValues.LastName;
                return true;
            }
            return false;
        }
        public bool RemoveTeacher(int id)
        {
            foreach (var teacher in _teacherDB)
            {
                if (teacher.ID==id)
                {
                    _teacherDB.Remove(teacher);
                    return true;
                }
            }
            return false;
        }
    }
}
